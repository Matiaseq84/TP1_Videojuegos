using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Retry()
    {
        
        SceneManager.LoadScene("Level_1");
    }

    /*public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }*/
}