using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    public bool isSprinting;
    public bool sprintable = true;
    public float sprintMultiplier;
    public float sprintTime;
    public float maxSprintTime = 5f;
    
    private float totalSpeed;
    public float countUpTime;

    private void Start()
    {
        sprintTime = maxSprintTime;
        countUpTime = maxSprintTime;
    }

    private void Update()
    {
        Sprint();
        ProcessInputs();
        
    }

    private void Sprint()
    {
        if (countUpTime < 0)
        {
            sprintable = true;
            countUpTime = maxSprintTime;
            sprintTime = maxSprintTime;
        }
        if (isSprinting && sprintTime > 0 && sprintable == true)
        {
            sprintTime -= Time.deltaTime;
            totalSpeed = moveSpeed * sprintMultiplier;
        }
        else
        {
            totalSpeed = moveSpeed;
        }

        if (sprintTime < 0)
        {
            sprintable = false;
            countUpTime -= Time.deltaTime;
        }
        
    }

    private void ProcessInputs()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
        
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.right * moveX * totalSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * moveY * totalSpeed * Time.deltaTime, Space.World);

    }
    
}
