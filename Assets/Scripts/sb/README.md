The AudioManagement script is used to control all audio in the Sad Pancake game.

The script is fairly simple and uses AudioSource and AudioClip variables to store and play the sound files.

Sounds are loaded in from the Assets/Resources/Sound folder using the unity function, Resources.Load

There are 2 main functions in the script, PlayFx and PlayMusic.
These functions take SoundType arguments and play the corresponding sound effect or music.

The script follows a singleton pattern so as long as the object is created in one scene it should be able to 
carry over between scenes.

The 'm' and 'n' keys are used to change background music and pause music respectively.

Additional sounds can be added using the following steps:
1. Place the sound clip in the Assets/Resources folder
2. In the Start() function, load the sound file into an AudioClip variable
3. Add a trigger to the PlayFx or PlayMusic functions