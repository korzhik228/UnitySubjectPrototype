using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel1()
    {
        Time.timeScale = 1; // Убираем паузу
        SceneManager.LoadScene("Level1");
        SceneManager.UnloadSceneAsync("Menu");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1; // Убираем паузу
        SceneManager.LoadScene("menu");
        SceneManager.UnloadSceneAsync("Menu");
    }
}

