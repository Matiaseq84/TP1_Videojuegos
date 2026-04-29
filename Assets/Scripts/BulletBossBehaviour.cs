using UnityEngine;

public class BossBulletBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float damage = 40f;
    [SerializeField] private float lifeTime = 3f;

    private Vector2 direction;

    void Start()
    {
        Destroy(gameObject, lifeTime);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {               
            direction = (player.transform.position - transform.position).normalized;
        }
        else
        {
            
            direction = Vector2.down;
        }
    }

    void Update()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}