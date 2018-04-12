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

    Player pancake;

    public AudioSource aSource;

    public AudioClip bgMusic;
    public AudioClip jumpClip;
    public AudioClip damageClip;
    public AudioClip pUpClip;
    public AudioClip NPCClip;
    public AudioClip coinClip;

    public void Start()
	{
        aSource = GetComponent<AudioSource>();

        bgMusic = (AudioClip)Resources.Load<AudioClip>("Sound/Allstar");

        jumpClip = (AudioClip)Resources.Load<AudioClip>("Sound/Jump");
        damageClip = (AudioClip)Resources.Load<AudioClip>("Sound/Damage");
        pUpClip = (AudioClip)Resources.Load<AudioClip>("Sound/PowerUp");
        NPCClip = (AudioClip)Resources.Load<AudioClip>("Sound/NPC");
        coinClip = (AudioClip)Resources.Load<AudioClip>("Sound/Coin");

        aSource.clip = jumpClip;

        //aSource.PlayOneShot(bgMusic);

    }

    public void Update()
    {
        if (Input.GetKeyDown("u"))
            PlayFx(SoundType.NPC);
    }

    public int PlayMusic(SoundType music)
	{
        aSource.PlayOneShot(bgMusic);
        return 1;
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
