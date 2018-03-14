using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManagement : MonoBehaviour
{

	public enum SoundType
	{
		ENEMY_COLLISION,
		PLAYER_JUMP,
		BG_MUSIC
	}

    Player pancake;

	public AudioClip bgMusic;
	public AudioSource bgSource;

    public AudioSource jumpSource;
    public AudioClip jumpClip;

    public float nextSoundTime = 0;

    public bool midjump = false;

    public void Start()
	{
		bgSource = GetComponent<AudioSource>();
        jumpSource = GetComponent<AudioSource>();

        bgMusic = (AudioClip)Resources.Load<AudioClip>("Sound/Background");
        jumpClip = (AudioClip)Resources.Load<AudioClip>("Sound/jump");

        jumpSource.clip = jumpClip;

        pancake = GameObject.Find("SadPancakeBody").GetComponent<Player>();
    }

    public void Update()
    {
        if (!bgSource.isPlaying)
            bgSource.PlayOneShot(bgMusic);

        if (pancake.GetComponent<Rigidbody2D>().velocity.y == 0)
            midjump = false;

        if(pancake.GetComponent<Rigidbody2D>().velocity.y > 1 && !midjump )
        {
            PlayFx("jump");
            midjump = true;
        }
    }

    public int PlayMusic(SoundType music)
	{
		return 0;
	}

	public void PlayFx(string fx)
	{
        if (fx == "Jump" || fx == "jump")
        {
            jumpSource.Play();
        }
	}

}
