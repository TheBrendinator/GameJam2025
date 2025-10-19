using Unity.VisualScripting;
using UnityEngine;

public class inventoryMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject inventoryMenuUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        inventoryMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }


    void Pause()
    {
        inventoryMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
}
