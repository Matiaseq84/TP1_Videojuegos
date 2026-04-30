using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float enemyHealth = 40;


    public void setHealth(float health)
    {
        enemyHealth = health;
    }

    public float getHealth()
    {
        return this.enemyHealth;
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        Debug.Log("Enemy took damage. Current health: " + enemyHealth);

        GameManager.Instance.AddScore((int)damage);

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
 
        if (CompareTag("Boss"))
        {
            BossController boss = GetComponent<BossController>();
            if (boss != null)
            {
                boss.OnBossDeath();
                return; 
            }
        }

        Destroy(gameObject);

    }
}
