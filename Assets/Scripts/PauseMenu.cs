using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] AudioSource backgroundMusic;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
        }
    }

    public void Menu()
    {

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

    public void Options()
    {

    }
}
