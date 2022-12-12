using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionAngry : Condition
{
    float strikes;
    float maxStrikes;
    public ConditionAngry()
    {
        maxStrikes = 3.0f;
        strikes = 0;
    }

    public ConditionAngry(float maxStrikes_)
    {
        maxStrikes = maxStrikes_;
        strikes = 0;
    }

    public override void UpdateCondition(BearFSM owner_, GameObject targetPlayer_)
    {
        owner = owner_;
        targetPlayer = targetPlayer_;
    }

    public override bool Test()
    {
        if (strikes >= maxStrikes)
        {
            return true;
        }

        if (owner.getStateMachine().getCurrentStateName().getName() == BearState.idle)
        {
            strikes = strikes + (0.05f);
        }



        return false;
    }

}
