using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {
	
	public enum SoundType 
	{
		ENEMY_COLLISION,
		PLAYER_JUMP,
	}
	
	private bool musicPlaying = false;
	private bool fxPlaying = false;
	private bool isMusted = false;
	private bool isInit = false;
	
	
	public void Start ()
	{
		
	}

	public void Update()
	{
		
	}

	public int PlayMusic(SoundType music)
	{
		return 0;
	}
	
	public int PlayFx(SoundType fx)
	{
		return 0;
	}
	
}