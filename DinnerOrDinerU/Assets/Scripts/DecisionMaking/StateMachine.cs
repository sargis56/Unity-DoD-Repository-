using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviourFSM
{
    public State initialState;
    public State currentState;
    protected BearFSM owner;

    public StateMachine()
    {
        initialState = new State();
        currentState = new State();
    }

    // Start is called before the first frame update
    void Start()
    {
        owner = GetComponent<BearFSM>();
    }

    // Update is called once per frame
    public void Update()
    {
        Transition triggered = null;

        foreach (Transition transition in currentState.getTransitions())
        {
            if (transition.isTriggered())
            {
                triggered = transition;
                State targetState = triggered.getTargetState();
                currentState = targetState;
                break;
            }
        }

    }

    public void setInitialState(State state)
    {
        initialState = state;
        currentState = initialState;
    }

    public State getCurrentStateName()
    {
        return currentState;
    }
}
