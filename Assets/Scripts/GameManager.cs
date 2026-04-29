using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }

    [SerializeField] private int currentZone = 0;

    [SerializeField] private int lives = 3;

    private Vector3 respawnPoint;

    [Header("Estadísticas del Juego")]
    [SerializeField] private int score = 0;
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        // Implementación del patrón Singleton
        if (Instance == null)
        {
            Instance = this;
            // Opcional: Hace que el GameManager persista entre cambios de escena
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            // Si ya existe una instancia, destruimos esta para evitar duplicados
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Puntuación actualizada: " + score);

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString("D4");
        }

    }

    /// <summary>
    /// Método para obtener la puntuación actual.
    /// </summary>
    public int GetCurrentScore()
    {
        return score;
    }

    public int GetCurrentZone()
    {
        return currentZone;
    }

    public void AdvanceZone()
    {
        currentZone++;
        Debug.Log("Zona actual: " + currentZone);
    }

    //Vidas
    public int GetLives()
    {
        return lives;
    }

    public void LoseLife()
    {
        lives--;

        Debug.Log("Vidas restantes: " + lives);

        UIManager.Instance.UpdateHearts(lives);
    }

    //Respawn point
    public void SetRespawnPoint(Vector3 point)
    {
        respawnPoint = point;
    }

    public Vector3 GetRespawnPoint()
    {
        return respawnPoint;
    }

    //GameOver
    public void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game_Over_2");
    }

    public void Victory()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
    }
}
