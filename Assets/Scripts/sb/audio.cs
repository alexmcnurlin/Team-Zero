using System.Media;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	
	public enum SoundType 
	{
		ENEMY_COLLISION = "lol.mp3",
		PLAYER_JUMP = "jump.mp3"
						
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
	
	}
	
	public int PlayFx(SoundType fx)
	{
		
	}
	
}