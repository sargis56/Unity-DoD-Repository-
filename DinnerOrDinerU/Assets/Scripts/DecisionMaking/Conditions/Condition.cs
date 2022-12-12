using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviourFSM
{
    public BearFSM owner;
    public GameObject targetPlayer;

    public Condition()
    {
        owner = character;
        targetPlayer = target;
    }

    public virtual void UpdateCondition()
    {

    }

    public virtual void UpdateCondition(BearFSM owner_, GameObject targetPlayer_)
    {
        owner = owner_;
        targetPlayer = targetPlayer_;
    }

    public virtual bool Test()
    {
        return false;
    }
}
