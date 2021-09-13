using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float gravity;
    [SerializeField] float groundHeight = 10f;
    [SerializeField] bool isGrounded = false;

    [SerializeField] Vector2 velocity;
    [SerializeField] float acceleration = 10f;
    [SerializeField] float maxAcceleration = 10f;
    [SerializeField] float jumpVelocity = 20f;
    [SerializeField] float maxXVelocity = 100f;

    [SerializeField] float distance = 0f;
    [SerializeField] int distanceInt;
    [SerializeField] Text distanceText;

    void Start()
    {
        distanceInt = (int)distance;
        distanceText.text = distanceInt.ToString();
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
        }
        else
        {
            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);

            velocity.x += acceleration * Time.fixedDeltaTime;
            if (velocity.x >= maxXVelocity)
            {
                velocity.x = maxXVelocity;
            }
        }

        distance += velocity.x * Time.fixedDeltaTime;
        distanceInt = (int)distance;
        distanceText.text = distanceInt.ToString();

        transform.position = pos;
    }
}
