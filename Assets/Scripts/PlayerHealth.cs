using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= (int)damage;

        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            LoseLife();
        }
    }

    void LoseLife()
    {
        GameManager.Instance.LoseLife();

        if (GameManager.Instance.GetLives() > 0)
        {
            Respawn();
        }
        else
        {
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }
    }

    void Respawn()
    {
        currentHealth = maxHealth;

        transform.position = GameManager.Instance.GetRespawnPoint();
    }
}