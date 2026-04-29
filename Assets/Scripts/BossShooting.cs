using UnityEngine;

public class BossShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrfb;
    [SerializeField] private Transform[] nozzles;

    private float shootRate = 1f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= shootRate)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        foreach (Transform nozzle in nozzles)
        {
            GameObject bullet = Instantiate(bulletPrfb);
            bullet.transform.position = nozzle.transform.position;
        }
    }

    
}
