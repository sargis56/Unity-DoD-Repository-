using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public State targetState;
    public Condition condition;

    public Transition()
    {
        targetState = new State();
        condition = new Condition();
    }

    public Transition(State targetState_, Condition condition_)
    {
        targetState = targetState_;
        condition = condition_;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isTriggered()
    {
        //print("isTriggered");
        return condition.Test();
    }

    public State getTargetState()
    {
        return targetState;
    }

}
