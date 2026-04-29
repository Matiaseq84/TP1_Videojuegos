using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float camWidth;

    
    Vector2 hBound;

    
    
    void Start()
    {
        camWidth = 5.2f;

        

        hBound = new Vector2(-camWidth / 2, camWidth /2);
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 5;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * 5;

        float clampedX = Mathf.Clamp(transform.position.x + moveX, hBound.x, hBound.y);
        float newY = transform.position.y + moveY;

        transform.position = new Vector3(clampedX, newY, 0);
    }
}
