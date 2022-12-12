using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : BearBehaviour
{
    public float slowRadius = 1.0f;
    public float timeToReach = 0.5f;
    public float targetRadius = 1.0f;
    private float targetSpeed = 0.0f;
    private float distance;
    private Vector3 targetVelocity;
    private Vector3 direction;

    public override SteeringOutput getSteering()
    {
        print("Bear is arriving");
        SteeringOutput result = new SteeringOutput();

        direction = target.transform.position - transform.position;
        distance = direction.magnitude;

        if (distance < targetRadius)
        {
            return null;
        }

        if (distance > slowRadius)
        {
            targetSpeed = character.maxSpeed;
        }
        else
        {
            targetSpeed = character.maxSpeed * distance / slowRadius;
        }

        // The target velocity combines speed and direction
        targetVelocity = direction;
        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;

        // Acceleration tries to get to the target velocity
        result.linear = targetVelocity - character.velocity;
        result.linear /= timeToReach;

        //Clip the velocity if it is too high (OpenGL version)
        //if (character.velocity.magnitude > character.maxSpeed)
        //{
        //    result.linear.Normalize();
        //    result.linear *= character.speed;
        //}

        // Clip acceleration if too high
        if (result.linear.magnitude > character.maxAcceleration)
        {
            result.linear.Normalize();
            result.linear *= character.maxAcceleration;

        }

        result.angular = 0;
        return result;
    }
}
