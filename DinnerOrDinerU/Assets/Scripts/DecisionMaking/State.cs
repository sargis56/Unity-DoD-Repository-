using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviourFSM
{
    List<Transition> transitions;
    public BearState stateName;

    public State()
    {
        stateName = BearState.idle;
        transitions = new List<Transition>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getActions()
    {

    }

    public void getEntryActions()
    {

    }

    public void getExitActions()
    {

    }

    public List<Transition> getTransitions()
    {
        return transitions;
    }

    public void addTransition(Transition transition)
    {
        transitions.Add(transition);
    }

    public void clearTransitions()
    {
        transitions.Clear();
    }

    public BearState getName()
    {
        return stateName;
    }
}
