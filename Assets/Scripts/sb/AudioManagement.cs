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
        COIN
    }

    public AudioSource aSource;

    public AudioClip allstar;
    public AudioClip spaceCave;
    public AudioClip lake;

    public AudioClip jumpClip;
    public AudioClip damageClip;
    public AudioClip pUpClip;
    public AudioClip NPCClip;
    public AudioClip coinClip;

    public int bgMusicCounter = 0;

    public void Start()
    {
        aSource = GetComponent<AudioSource>();

        allstar = (AudioClip)Resources.Load<AudioClip>("Sound/Allstar");
        spaceCave = (AudioClip)Resources.Load<AudioClip>("Sound/SpaceCave");
        lake = (AudioClip)Resources.Load<AudioClip>("Sound/Path to Lake Land");

        jumpClip = (AudioClip)Resources.Load<AudioClip>("Sound/Jump");
        damageClip = (AudioClip)Resources.Load<AudioClip>("Sound/Damage");
        pUpClip = (AudioClip)Resources.Load<AudioClip>("Sound/PowerUp");
        NPCClip = (AudioClip)Resources.Load<AudioClip>("Sound/NPC");
        coinClip = (AudioClip)Resources.Load<AudioClip>("Sound/Coin");

        aSource.clip = spaceCave;
        PlayMusic(SoundType.BG_MUSIC);

    }

    public void Update()
    {
        if (Input.GetKeyDown("u"))
            PlayFx(SoundType.NPC);
        if (Input.GetKeyDown("m"))
        {
            bgMusicCounter++;
            if (bgMusicCounter == 3)
                bgMusicCounter = 0;
            PlayMusic(SoundType.BG_MUSIC);
        }
        if (Input.GetKeyDown("n"))
            aSource.Stop();
    }

    public void PlayMusic(SoundType music)
	{
        switch (bgMusicCounter)
        {
            case 0:
                aSource.clip = spaceCave;
                aSource.Play();
                break;
            case 1:
                aSource.clip = lake;
                aSource.Play();
                break;
            case 2:
                aSource.clip = allstar;
                aSource.Play();
                break;
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

        }
	}
}
