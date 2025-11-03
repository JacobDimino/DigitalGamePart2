using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float maxSpeed = 200f;
    public float accelerationRate = 20f;
    public float decelerationRate = 0.2f;
    private float currentSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed += accelerationRate * Time.deltaTime;
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentSpeed -= accelerationRate * Time.deltaTime;
            if (currentSpeed < (-1 * maxSpeed))
            {
                currentSpeed = (-1 * maxSpeed);
            }
        }

        //decelerate
        else
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= decelerationRate * Time.deltaTime;
            }
            if (currentSpeed < 0)
            {
                currentSpeed += decelerationRate * Time.deltaTime;
            }

        }

        transform.Rotate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
