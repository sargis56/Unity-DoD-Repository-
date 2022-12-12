using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : BearBehaviour
{
    public override SteeringOutput getSteering()
    {
        print("Bear is seeking");
        SteeringOutput result = new SteeringOutput();

        result.linear = target.transform.position - transform.position;
        result.linear.Normalize();
        //result.linear = character.maxSpeed * result.linear;
        result.linear *= character.maxAcceleration;
        
        result.angular = 0;
        return result;
    }
}
