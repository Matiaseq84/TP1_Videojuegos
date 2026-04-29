using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed = 10f;

    [SerializeField]
    private float damage = 20f;

    [SerializeField]
    private float lifeTime = 2f;


    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }


    void Update()
    {
        transform.Translate(new Vector3 (0, 1, 0) * bulletSpeed * Time.deltaTime);      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("Bullet hits an enemy!");
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

        }

        Destroy(gameObject);
    }
}
