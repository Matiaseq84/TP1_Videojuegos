    using UnityEngine;

    public class EnemyBehaviour : MonoBehaviour
    {
        private float enemySpeed;

        private bool movingLeft;

        private Camera cam;

        private EnemyShooting shoot;

        private float shootTimer;

        private float shootInterval = 1f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            cam = Camera.main;
            shoot = GetComponent<EnemyShooting>();

            enemySpeed = Random.Range(2f, 6f);

            movingLeft = transform.position.x > 0;  
        }

        // Update is called once per frame
        void Update()
        {
            float direction = movingLeft ? -1f : 1f;
            transform.Translate(Vector2.right * direction * enemySpeed * Time.deltaTime);

            CheckBounds();

            shootTimer += Time.deltaTime;

            if(shootTimer > shootInterval )
            {
                shoot.Shoot();
                shootTimer = 0f;
                shootInterval = ShootRandomly();
            }
        }

    void CheckBounds()
    {
        Vector3 pos = transform.position;
        Vector3 screenPos = cam.WorldToViewportPoint(pos);

        if (screenPos.x < 0f)
        {
            pos.x = cam.ViewportToWorldPoint(new Vector3(0f, 0, 0)).x;
            movingLeft = false;
        }
        else if (screenPos.x > 1f)
        {
            pos.x = cam.ViewportToWorldPoint(new Vector3(1f, 0, 0)).x;
            movingLeft = true;
        }

        transform.position = pos;
    }

    float ShootRandomly()
        {
            shootInterval = Random.Range(1f, 2f);
            return shootInterval;
        }
    }
