using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManagement : MonoBehaviour
{

    public enum SoundType
    {
        DAMAGE,
        JUMP,
        POWERUP,
        NPC,
        BG_MUSIC,
        COIN,
        STOP,
        INVINCIBILITY,
        MENU
    }

    public bool bgIsPlaying = true;

    public AudioSource aSource;
    public AudioSource bgSource;

    public AudioClip allstar;
    public AudioClip spaceCave;
    public AudioClip lake;
    public AudioClip menu;

    public AudioClip jumpClip;
    public AudioClip damageClip;
    public AudioClip pUpClip;
    public AudioClip NPCClip;
    public AudioClip coinClip;
    public AudioClip invincibility;

    public int bgMusicCounter = 0;

    public void Start()
    {

        allstar = (AudioClip)Resources.Load<AudioClip>("Sound/Allstar");
        spaceCave = (AudioClip)Resources.Load<AudioClip>("Sound/SpaceCave");
        lake = (AudioClip)Resources.Load<AudioClip>("Sound/Path to Lake Land");
        menu = (AudioClip)Resources.Load<AudioClip>("Sound/Menu");

        jumpClip = (AudioClip)Resources.Load<AudioClip>("Sound/Jump");
        damageClip = (AudioClip)Resources.Load<AudioClip>("Sound/Damage");
        pUpClip = (AudioClip)Resources.Load<AudioClip>("Sound/PowerUp");
        NPCClip = (AudioClip)Resources.Load<AudioClip>("Sound/NPC");
        coinClip = (AudioClip)Resources.Load<AudioClip>("Sound/Coin");
        invincibility = (AudioClip)Resources.Load<AudioClip>("Sound/Invincibility");

        bgSource.clip = spaceCave;
        PlayMusic(SoundType.BG_MUSIC);

    }

    public void Update()
    {
        if (Input.GetKeyDown("u"))
            PlayMusic(SoundType.MENU);
        if (Input.GetKeyDown("i"))
            PlayMusic(SoundType.BG_MUSIC);

        if (Input.GetKeyDown("m"))
        {
            bgMusicCounter++;
            if (bgMusicCounter == 3)
                bgMusicCounter = 0;
            PlayMusic(SoundType.BG_MUSIC);
        }
        if (Input.GetKeyDown("n"))
        {
            if (bgIsPlaying == true)
            {
                bgSource.Pause();
                bgIsPlaying = false;
            }
            else
            {
                bgSource.UnPause();
                bgIsPlaying = true;
            }
        }
    }

    public void PlayMusic(SoundType music)
	{
        if (music == SoundType.MENU)
        {
            bgSource.clip = menu;
            bgSource.Play();
        }
        else if (music == SoundType.BG_MUSIC)
        {
            switch (bgMusicCounter)
            {
                case 0:
                    bgSource.clip = spaceCave;
                    bgSource.Play();
                    break;
                case 1:
                    bgSource.clip = lake;
                    bgSource.Play();
                    break;
                case 2:
                    bgSource.clip = allstar;
                    bgSource.Play();
                    break;
            }
        }
    }

	public void PlayFx(SoundType fx)
	{
        switch(fx)
        {
            case SoundType.DAMAGE:
                aSource.PlayOneShot(damageClip);
                break;
            case SoundType.JUMP:
                aSource.PlayOneShot(jumpClip);
                break;
            case SoundType.POWERUP:
                aSource.PlayOneShot(pUpClip);
                break;
            case SoundType.NPC:
                aSource.PlayOneShot(NPCClip);
                break;
            case SoundType.COIN:
                aSource.PlayOneShot(coinClip);
                break;
            case SoundType.INVINCIBILITY:
                bgSource.Pause();
                aSource.PlayOneShot(invincibility);
                break;
            case SoundType.STOP:
                aSource.Stop();
                bgSource.UnPause();
                break;
        }
	}
}
