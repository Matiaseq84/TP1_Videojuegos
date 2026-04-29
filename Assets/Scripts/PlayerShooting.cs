using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrfb;

    [SerializeField]
    private Transform nozzle;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrfb);
            bullet.transform.position = nozzle.transform.position;
        }
        
    }
}
