using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    public float speed = 1.0f;
    public float maxAcceleration = 10.0f;
    public float maxRotation = 0.0f;
    public float orientation = 0.0f;
    public Vector3 displacment = Vector3.zero;
    public Vector3 velocity = Vector3.zero;

    protected SteeringOutput steeringOutput = new SteeringOutput();

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displacment = (velocity * Time.deltaTime);
        transform.Translate(displacment, Space.World);


       //transform.position = postion;
    }

    void LateUpdate()
    {
        velocity += steeringOutput.linear * Time.deltaTime;
        orientation += steeringOutput.angular * Time.deltaTime;

        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized;
            velocity *= speed;
        }

    }


    public void setSteering(SteeringOutput steeringOut)
    {
        steeringOutput = steeringOut;
    }
}
