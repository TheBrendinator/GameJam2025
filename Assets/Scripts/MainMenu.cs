using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void ControlsScreen()
    {
        SceneManager.LoadScene("ControlScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
