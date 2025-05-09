using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance; //instance of music manager
    private AudioSource audioSource; //reference to the audiosource
    public AudioClip backgroundMusic; //background music clip
   

    private void Awake(){ //called when script instance is loaded
        if(Instance == null){ //implements singleton pattern ensuring only one instance exists
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);

        }
        else{
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       if(backgroundMusic != null){ //automatically play background music if assigned
        PlayBackgroundMusic(false, backgroundMusic);
       } 
    }

    public static void SetVolume(float volume){ //static method to adjust music volume
        Instance.audioSource.volume = volume;
    }

    public void PlayBackgroundMusic(bool resetSong, AudioClip audioClip = null){ //method to play background music
        if(audioClip != null){ //assign new clip if provided
            audioSource.clip = audioClip;
        }
        if(audioSource.clip != null){ //if a valid audio clip is set, play it
            if(resetSong){
                audioSource.Stop();
            }
            audioSource.Play(); //starts playing the music
        }
    }

    public void PauseBackgroundMusic(){ //method to pause current playing song
        audioSource.Pause();
    }

    public AudioClip deathMusic; //music clip to be played upon player death

    public void PlayDeathMusic() //method to stop current music and play death music
    {
        if (deathMusic != null){

            audioSource.Stop();
            audioSource.clip = deathMusic;
            audioSource.Play();
        }
    }

}
