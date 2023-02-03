using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    

    private void Update()
    {
        ProcessInputs();
        
    }

    private void FixedUpdate()
    {
        // Move();
        
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.right * moveX * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * moveY * moveSpeed * Time.deltaTime, Space.World);

    }
    
}
