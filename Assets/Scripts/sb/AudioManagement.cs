using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManagement : MonoBehaviour
{

    public static AudioManagement gameAudio;

    //Type used to allow easier calling of sounds
    public enum SoundType
    {
        DAMAGE,
        JUMP,
        POWERUP,
        NPC,
        BG_MUSIC,
        COIN,
        TOKEN,
        STOP,
        INVINCIBILITY,
        MENU,
        DEATH
    }
    public static AudioManagement instance = null; 

    //Keep track of background music for pausing
    public bool bgIsPlaying = true;

    //Two sources, one to play bg music and one to play effects
    public AudioSource aSource;
    public AudioSource bgSource;

    //Background clips
    public AudioClip allstar;
    public AudioClip spaceCave;
    public AudioClip lake;
    public AudioClip menu;

    //Effects Clips
    public AudioClip jumpClip;
    public AudioClip damageClip;
    public AudioClip pUpClip;
    public AudioClip npcClip;
    public AudioClip coinClip;
    public AudioClip tokenClip;
    public AudioClip invincibility;
    public AudioClip deathClip;

    public int bgMusicCounter = 0;

    //Initialize all of the sound assets
    public void Start()
    {

        //All audio files are loaded from the Resources/Sound Directory
        //Music clips for background and menu
        allstar = (AudioClip)Resources.Load<AudioClip>("Sound/Allstar");
        spaceCave = (AudioClip)Resources.Load<AudioClip>("Sound/SpaceCave");
        lake = (AudioClip)Resources.Load<AudioClip>("Sound/Path to Lake Land");
        menu = (AudioClip)Resources.Load<AudioClip>("Sound/Menu");

        //Effects clips for actions, status effects and collectables
        tokenClip = (AudioClip)Resources.Load<AudioClip>("Sound/TokenSound");
        jumpClip = (AudioClip)Resources.Load<AudioClip>("Sound/Jump");
        damageClip = (AudioClip)Resources.Load<AudioClip>("Sound/Damage");
        pUpClip = (AudioClip)Resources.Load<AudioClip>("Sound/PowerUp");
        npcClip = (AudioClip)Resources.Load<AudioClip>("Sound/NPC");
        coinClip = (AudioClip)Resources.Load<AudioClip>("Sound/Coin");
        invincibility = (AudioClip)Resources.Load<AudioClip>("Sound/Invincibility");
        deathClip = (AudioClip)Resources.Load<AudioClip>("Sound/Death");

        //Begin background music
        PlayMusic(SoundType.BG_MUSIC);

    }


    //The following function has been integrated from 
    //https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/audio-and-sound-manager
    void Awake()
    {
            //Check if there is already an instance of SoundManager
            if (instance == null)
                //if not, set it to this.
                instance = this;
            //If instance already exists:
            else if (instance != this)
                //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
                Destroy(gameObject);

            //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
            DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {

        //Used to test new sounds
        if (Input.GetKeyDown("u"))
            PlayFx(SoundType.DEATH);

        //Allow user to cycle through background music options
        if (Input.GetKeyDown("m"))
        {
            bgMusicCounter++;
            if (bgMusicCounter == 3)
                bgMusicCounter = 0;
            PlayMusic(SoundType.BG_MUSIC);
        }

        //Allow user to pause and resume background music
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
        //Called by menu to play the menu music
        if (music == SoundType.MENU)
        {
            bgSource.clip = menu;
            bgSource.Play();
        }
        //Play requested background music
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
        //Check for requested effect and play accordingly
        switch (fx)
        {
            case SoundType.TOKEN:
                aSource.PlayOneShot(tokenClip);
                break;
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
                aSource.PlayOneShot(npcClip);
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
            case SoundType.DEATH:
                aSource.PlayOneShot(deathClip);
                break;
        }
    }
}
