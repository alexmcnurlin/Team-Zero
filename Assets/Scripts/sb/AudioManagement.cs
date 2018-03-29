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
		BG_MUSIC
	}

    Player pancake;

    public AudioSource aSource;

    public AudioClip bgMusic;
    public AudioClip jumpClip;
    public AudioClip damageClip;
    public AudioClip pUpClip;

    public bool midjump = false;
    public bool falling = false;

    public void Start()
	{
        aSource = GetComponent<AudioSource>();

        //bgMusic = (AudioClip)Resources.Load<AudioClip>("Sound/Allstar");

        jumpClip = (AudioClip)Resources.Load<AudioClip>("Sound/Jump");
        damageClip = (AudioClip)Resources.Load<AudioClip>("Sound/Damage");
        pUpClip = (AudioClip)Resources.Load<AudioClip>("Sound/PowerUp");

        aSource.clip = jumpClip;

        aSource.PlayOneShot(bgMusic);

        pancake = GameObject.Find("SadPancakeBody").GetComponent<Player>();
    }

    public void Update()
    {


        if (pancake.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            if (falling)
            {
                PlayFx(SoundType.DAMAGE);
            }

            falling = false;
            midjump = false;
        }

        if (pancake.GetComponent<Rigidbody2D>().velocity.y > 3 && !midjump )
        {
            PlayFx(SoundType.JUMP);
            midjump = true;
        }
        if (pancake.GetComponent<Rigidbody2D>().velocity.y < -1 && !midjump)
        {
            falling = true;
        }
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
        }
	}
}
