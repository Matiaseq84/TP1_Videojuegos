using UnityEngine;
using UnityEngine.UIElements;

public class BossSpawnerZone : MonoBehaviour
{
    [SerializeField] private GameObject bossPrfb;

    private bool spawned = false;

    public void SpawnBoss()
    {
        if (spawned) return;

        Vector3 spawnPos = transform.position;

        Instantiate(bossPrfb, spawnPos, Quaternion.identity);

        spawned = true;

        Debug.Log("Boss Spawned!");
    }
}
