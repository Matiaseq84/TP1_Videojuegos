using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private EnemyHealth health;
    private BossShooting shooting;

    [SerializeField] private GameObject explosionPrfb;

    [Header("Movimiento")]
    [SerializeField] private float entrySpeed = 3f;
    [SerializeField] private float targetY = 8f;

    [Header("Combate")]
    [SerializeField] private float moveAmplitude = 3f;
    [SerializeField] private float moveFrequency = 1f;

    [Header("Timing")]
    [SerializeField] private float startDelay = 1.5f;

    private bool isEntering = true;
    private bool isFighting = false;
    private float timer = 0f;

    void Start()
    {
        health = GetComponent<EnemyHealth>();
        shooting = GetComponent<BossShooting>();

        health.setHealth(2000);
                
        shooting.enabled = false;
    }

    void Update()
    {
        if (isEntering)
        {
            Enter();
        }
        else if (!isFighting)
        {
            WaitBeforeFight();
        }
        else
        {
            Fight();
        }
    }

    void Enter()
    {
        transform.position += Vector3.down * entrySpeed * Time.deltaTime;

        Debug.Log(transform.position.y);

        if (transform.position.y <= targetY)
        {
            isEntering = false;
        }
    }

    void WaitBeforeFight()
    {
        timer += Time.deltaTime;

        if (timer >= startDelay)
        {
            isFighting = true;
            shooting.enabled = true; 
        }
    }

    void Fight()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Sin(Time.time * moveFrequency) * moveAmplitude;

        transform.position = pos;
    }

    public void OnBossDeath()
    {
        StartCoroutine(DeathRoutine());
    }

    IEnumerator DeathRoutine()
    {
        
        shooting.enabled = false;

        
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomOffset = Random.insideUnitCircle * 1.5f;
            Instantiate(explosionPrfb, transform.position + randomOffset, Quaternion.identity);

            yield return new WaitForSeconds(0.3f);
        }

        
        Instantiate(explosionPrfb, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1f);

        
        GameManager.Instance.Victory();

        Destroy(gameObject);
    }

}