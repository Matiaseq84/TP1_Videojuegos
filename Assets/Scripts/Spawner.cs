using UnityEngine;

public class EnemySpawnerZone : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrfb;

    [Header("Wave config")]
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private float spawnDelay = 0.5f;

    private int spawned = 0;

    public void StartWave()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnDelay);
    }

    void SpawnEnemy()
    {
        if (spawned >= enemyCount)
        {
            CancelInvoke(nameof(SpawnEnemy));
            return;
        }

        // Spawn alrededor del spawner
        Vector3 spawnPos = transform.position + new Vector3(
            Random.Range(-2f, 2f),
            Random.Range(-2f, 2f),
            0
        );

        GameObject enemy = Instantiate(enemyPrfb, spawnPos, Quaternion.identity);

        EnemyHealth eh = enemy.GetComponent<EnemyHealth>();
        if (eh != null) {
            int zone = GameManager.Instance.GetCurrentZone();
            eh.setHealth(eh.getHealth() * zone);
            Debug.Log(eh.getHealth());
        }

        spawned++;
    }
}