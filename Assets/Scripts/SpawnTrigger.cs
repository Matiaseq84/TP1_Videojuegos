using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] private EnemySpawnerZone spawner;
    [SerializeField] private BossSpawnerZone bossSpawner;

    [SerializeField] private GameObject doorBlock;

    [SerializeField] bool isBossZone = false;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated) return;

        if (collision.CompareTag("Player"))
        {
            activated = true;

            GameManager.Instance.AdvanceZone();

            GameManager.Instance.SetRespawnPoint(transform.position);

            int zone = GameManager.Instance.GetCurrentZone();

            if (zone == 1)
                UIManager.Instance.ShowStage("STAGE 1");
            else if (zone == 2)
                UIManager.Instance.ShowStage("STAGE 2");
            else if (zone == 3)
                UIManager.Instance.ShowStage("FINAL STAGE");

            if (doorBlock != null)
            {
                doorBlock.SetActive(true);
            }

            if (isBossZone)
            {
                bossSpawner.SpawnBoss();
            } else
            {
                spawner.StartWave();
            }
        }
    }
}