using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionBetRange : Condition
{
    float thresholdDistanceIn;
    float thresholdDistanceOut;
    public ConditionBetRange()
    {
        thresholdDistanceIn = 4.0f;
        thresholdDistanceOut = 4.0f;
    }

    public ConditionBetRange(float thresholdDistanceIn_, float thresholdDistanceOut_)
    {
        thresholdDistanceIn = thresholdDistanceIn_;
        thresholdDistanceOut = thresholdDistanceOut_;
    }

    public override void UpdateCondition(BearFSM owner_, GameObject targetPlayer_)
    {
        owner = owner_;
        targetPlayer = targetPlayer_;
    }

    public override bool Test()
    {
        print("test");
        if ((Vector3.Distance(targetPlayer.transform.position, owner.transform.position) > thresholdDistanceOut) &&
            (Vector3.Distance(targetPlayer.transform.position, owner.transform.position) < thresholdDistanceIn))
        {
            return true;
        }
        return false;
    }
}
