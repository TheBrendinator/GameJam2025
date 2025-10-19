using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("DayNightCycle");
    }

    public void ControlsScreen()
    {
        SceneManager.LoadScene("Controls");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
