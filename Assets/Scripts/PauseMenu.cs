using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu; //reference to pause menu UI GameObject
    [SerializeField] AudioSource backgroundMusic; //reference to background music AudioSource

    public void Pause() //called when game is paused
    {
        pauseMenu.SetActive(true); //enable the UI
        Time.timeScale = 0; //freezes game

        if (backgroundMusic != null && backgroundMusic.isPlaying) //pauses background music if playing
        {
            backgroundMusic.Pause();
        }
    }

    public void Menu() //placeholder for menu
    {

    }

    public void Resume() //called when game is resumed
    {
        pauseMenu.SetActive(false); //disable the UI
        Time.timeScale = 1; //resumes the game time

        if (backgroundMusic != null && !backgroundMusic.isPlaying) //resumes background music if not playing
        {
            backgroundMusic.Play();
        }
    }

    public void Options() //placeholder for options
    {

    }
}
