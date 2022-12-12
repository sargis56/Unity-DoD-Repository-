using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekV2 : MonoBehaviourFSM
{
    public override SteeringOutput getSteeringSeek()
    {
        SteeringOutput result = new SteeringOutput();

        result.linear = target.transform.position - transform.position;
        result.linear.Normalize();
        result.linear *= character.maxAcceleration;

        result.angular = 0;
        return result;
    }
}
