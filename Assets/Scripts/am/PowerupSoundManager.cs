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
            // Note, if there are any other FX playing, this will stop it
            Debug.Log("Stopping existing powerup music");
            aSource.PlayFx(AudioManagement.SoundType.STOP);
            isPlayingSound = false;
        }

        // Play the appropriate sound based on what powerup is given
        if (powerupType == Modifier.INVINCIBLE)
        {
            aSource.PlayFx(AudioManagement.SoundType.INVINCIBILITY);
        }
        else if (powerupType == Modifier.JUMPHEIGHT)
        {
            aSource.PlayFx(AudioManagement.SoundType.POWERUP);
        }
        else if (powerupType == Modifier.SPEED)
        {
            aSource.PlayFx(AudioManagement.SoundType.POWERUP);
        }
        else
        {
            Debug.Log("Powerup type has no sound!");
            return;
        }
        isPlayingSound = true;

    }

    public void StopAudio()
    {
        aSource.PlayFx(AudioManagement.SoundType.STOP);
        isPlayingSound = false;
    }
}
