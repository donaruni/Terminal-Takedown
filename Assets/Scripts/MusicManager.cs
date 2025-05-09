using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    private AudioSource audioSource;
    public AudioClip backgroundMusic;
   

    private void Awake(){
        if(Instance == null){
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
       if(backgroundMusic != null){
        PlayBackgroundMusic(false, backgroundMusic);
       } 
    }

    public static void SetVolume(float volume){
        Instance.audioSource.volume = volume;
    }

    public void PlayBackgroundMusic(bool resetSong, AudioClip audioClip = null){
        if(audioClip != null){
            audioSource.clip = audioClip;
        }
        if(audioSource.clip != null){
            if(resetSong){
                audioSource.Stop();
            }
            audioSource.Play();
        }
    }

    public void PauseBackgroundMusic(){
        audioSource.Pause();
    }

    public AudioClip deathMusic;

    public void PlayDeathMusic()
    {
        if (deathMusic != null){

            audioSource.Stop();
            audioSource.clip = deathMusic;
            audioSource.Play();
        }
    }

}
