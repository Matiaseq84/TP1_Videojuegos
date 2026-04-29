using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrfb;

    public float spawnRate = 2f;

    private Camera cam;

    [SerializeField]
    private int maxSpawns = 20;

    private int totalSpawned = 0;

    void Start()
    {
        cam = Camera.main;
        
            InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    void SpawnEnemy()
    {

        if (totalSpawned >= maxSpawns)
        {
            CancelInvoke("SpawnEnemy");
            return;
        }


        float spawnX = cam.ViewportToWorldPoint(new Vector3(1.1f, 0, 0)).x;

        float randomY = cam.ViewportToWorldPoint(new Vector3(0, Random.Range(0.7f, 0.95f), 0)).y;

        Vector3 spawnPos = new Vector3(spawnX, randomY, 0);


        Instantiate(enemyPrfb, spawnPos, Quaternion.identity);


        totalSpawned++;

        Debug.Log("Spawned: " + totalSpawned);

    }
    
}
