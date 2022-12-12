using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : Seek
{
    public float prediction;
    public float maxPrediction;
    GameObject targetPrediction;
    float distance;
    Vector3 direction;
    Bear targetBear;
    float targetSpeed;

    public override void Start()
    {
        base.Start();
        //targetBear = GetComponent<Bear>();
        //targetBear.transform.position = new Vector3(0.0f, targetBear.transform.position.y, 0.0f);
        //targetPrediction = target;
        //target = new GameObject();
        //target.transform.position = new Vector3(0.0f, targetBear.transform.position.y, 0.0f);
    }

    public override SteeringOutput getSteering()
    {
        //targetBear = target.GetComponent<Bear>();
        
        //prediction = Time.deltaTime;


        print("Bear is pursuing");
        SteeringOutput result = new SteeringOutput();

        direction = target.transform.position - character.transform.position;
        distance = direction.magnitude;

        // Work out current speed
        targetSpeed = character.velocity.magnitude;

        if (targetSpeed <= (distance / maxPrediction))
        {
            prediction = maxPrediction;
        }
        else
        {
            prediction = (distance / targetSpeed);
        }

        //target  = targetPrediction;
        //target.transform.position = character.transform.position;

        //base.target.transform.position = target.transform.position;

        //transform.position += character.velocity * prediction;
        //base.target.transform.position += target.GetComponent<Rigidbody>().velocity * prediction;

        //result = base.getSteering();

        result.linear = target.transform.position 
            + target.GetComponent<Rigidbody>().velocity * prediction 
            - transform.position;

        result.linear.Normalize();
        result.linear *= character.maxAcceleration;

        result.angular = 0;

        return result;
    }
}
