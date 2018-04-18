using System;
using UnityEngine;

public class PowerupSoundManager
{
    private static PowerupSoundManager instance;
    private static bool isPlayingSound = false;
    public  static AudioManagement aSource;

    private PowerupSoundManager() {}

    // Use the singleton pattern to manage playing audio for powerups.
    // This allows us to keep track of whether audio is playing, and stop the existing audio if it is
    // Right now, this doesn't actually stop playing music, since the audio manager doesn't support it.
    //     This should change in the future though.
	public static PowerupSoundManager getInstance() {
        if (instance == null)
        {
            instance = new PowerupSoundManager();
            aSource = GameObject.Find("AudioManagement").GetComponent<AudioManagement>();
        }
        return instance;
	}

    public void PlayAudio(Modifier powerupType)
    {
        if (isPlayingSound)
        {
            // Stop playing the sound
            Debug.Log("TODO: stop existing powerup sound");
            isPlayingSound = false;
        }
    
        if (powerupType == Modifier.INVINCIBLE)
        {
            isPlayingSound = true;
            aSource.PlayFx(AudioManagement.SoundType.POWERUP);
        }
        else if (powerupType == Modifier.JUMPHEIGHT)
        {
            isPlayingSound = true;
            aSource.PlayFx(AudioManagement.SoundType.POWERUP);
        }
        else if (powerupType == Modifier.SPEED)
        {

            isPlayingSound = true;
            aSource.PlayFx(AudioManagement.SoundType.POWERUP);
        }
        else
        {
            Debug.Log("Powerup type has no sound!");
        }
    }
}
