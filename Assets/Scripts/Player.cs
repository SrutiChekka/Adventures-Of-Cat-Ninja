using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float gravity;
    [SerializeField] float groundHeight = 10f;
    [SerializeField] bool isGrounded = false;

    [SerializeField] float jumpVelocity = 20f;
    [SerializeField] Vector2 velocity;

    void Start()
    {
        
    }

    void Update()
    {
        if(isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
            }   
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if(!isGrounded)
        {
            pos.y += velocity.y * Time.fixedDeltaTime;
            velocity.y += gravity * Time.fixedDeltaTime;

            if(pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
            }

            transform.position = pos; 
        }
    }
}
