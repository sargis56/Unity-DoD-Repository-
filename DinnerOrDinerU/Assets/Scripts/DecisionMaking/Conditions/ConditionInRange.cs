using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionInRange : Condition
{
    float thresholdDistance;

    public ConditionInRange()
    {
        thresholdDistance = 4.0f;
    }

    public ConditionInRange(float thresholdDistance_)
    {
        thresholdDistance = thresholdDistance_;
    }
    public override void UpdateCondition(BearFSM owner_, GameObject targetPlayer_)
    {
        owner = owner_;
        targetPlayer = targetPlayer_;
    }

    public override bool Test()
    {
        if (Vector3.Distance(targetPlayer.transform.position, owner.transform.position) < thresholdDistance)
        {
            return true;
        }
        return false;
    }
}
