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

	/*
    The following vars will be used in the
    future but cause warnings right now
    so they have been commented out
	
	//private bool musicPlaying = false;
	//private bool fxPlaying = false;
	//private bool isMusted = false;
	//private bool isInit = false;
    */


	public AudioClip backgroundMusic;
	public AudioSource source;


	public void Start ()
	{
		source = GetComponent<AudioSource> ();

		backgroundMusic = (AudioClip)Resources.Load<AudioClip> ("Sound/Background");

	}

	public void Update ()
	{
		if (!source.isPlaying)
			source.PlayOneShot (backgroundMusic);
	}

	public int PlayMusic (SoundType music)
	{
		return 0;
	}

	public int PlayFx (SoundType fx)
	{
		return 0;
	}
	
}