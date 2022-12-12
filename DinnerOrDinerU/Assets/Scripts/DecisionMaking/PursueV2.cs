using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueV2 : SeekV2
{
    public float prediction;
    public float maxPrediction;
    float distance;
    Vector3 direction;
    float targetSpeed;

    public override SteeringOutput getSteeringPursue()
    {
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

        result.linear = target.transform.position
            + target.GetComponent<Rigidbody>().velocity * prediction
            - transform.position;

        result.linear.Normalize();
        result.linear *= character.maxAcceleration;

        result.angular = 0;

        return result;
    }
}
