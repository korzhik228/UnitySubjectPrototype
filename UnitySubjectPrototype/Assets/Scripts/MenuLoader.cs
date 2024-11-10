using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadMenuScene(); 
        }
    }

    private void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}