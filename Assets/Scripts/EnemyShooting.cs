using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrfb;

    [SerializeField]
    private Transform nozzle;

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrfb);
        bullet.transform.position = nozzle.transform.position;
        
    }
    
}
