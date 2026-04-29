using UnityEngine;

public class BulletEnemyBehaviour : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed = 5f;
    private float damage = 20f;
    private float lifeTime = 2f;

    
    void Start()
    {
        Destroy(gameObject, lifeTime);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * bulletSpeed * 1 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bullet hits Player");
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null) {
                playerHealth.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
