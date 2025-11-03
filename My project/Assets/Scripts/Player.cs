using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*
  [SerializeField]
  public float turnSpeed;


  [SerializeField]
  public float acceleration = 0f;

  [SerializeField]
  public float accelSpeed = .5f;

  float maxaccel = 1f;
  float minaccel = -1f;
  */
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
            currentSpeed -= accelerationRate * Time.deltaTime;
            if (currentSpeed < (-1 * maxSpeed))
            {
                currentSpeed = (-1 * maxSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentSpeed += accelerationRate * Time.deltaTime;
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
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



    // Update is called once per frame
    /*
    void Update()
    {
        
        //left
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            acceleration -= accelSpeed;
        }

        //right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            accelSpeed += accelSpeed;
        }

        if (acceleration > maxaccel)
        {
            accelSpeed = maxaccel;
        }
        else if (acceleration < minaccel)
        {
            accelSpeed = minaccel;
        }
        


        transform.Rotate(Vector3.forward * turnSpeed *  Input.GetAxisRaw("Horizontal") * Time.deltaTime);


    }
    */
}
