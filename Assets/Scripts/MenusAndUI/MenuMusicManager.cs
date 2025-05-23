using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    public static MenuMusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        // Make sure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep across scenes
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
}

