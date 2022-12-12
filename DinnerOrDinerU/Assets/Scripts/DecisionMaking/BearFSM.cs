using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearFSM : MonoBehaviourFSM
{
    public float maxSpeed = 1.0f;
    public float speed = 1.0f;
    public float maxAcceleration = 10.0f;
    public float maxRotation = 0.0f;
    public float orientation = 0.0f;
    public Vector3 displacment = Vector3.zero;
    public Vector3 velocity = Vector3.zero;

    List<Condition> conditions;
    protected SteeringOutput steeringOutput = new SteeringOutput();

    protected State idle = new State();
    protected State seek = new State();
    protected State arrive = new State();
    protected State pursue = new State();

    //Conditions: Condition | ConditionOutRange | ConditionAngry | ConditionInRange 
    protected Condition conditionOutRange10 = new ConditionOutRange(10);
    protected Condition conditionOutRange15 = new ConditionOutRange(15);
    protected Condition conditionInRange5 = new ConditionInRange(5);
    protected Condition conditionAngry = new ConditionAngry(100);

    protected Transition transitionToIdle;
    protected Transition transitionToSeek;
    protected Transition transitionToArrive;
    protected Transition transitionToPursue;

    protected StateMachine stateMachine = new StateMachine();

    void Start()
    {
        conditions = new List<Condition>();
        conditions.Add(conditionOutRange10);
        conditions.Add(conditionOutRange15);
        conditions.Add(conditionInRange5);
        conditions.Add(conditionAngry);

        idle.stateName = (BearState)System.Enum.Parse(typeof(BearState), "idle");
        seek.stateName = (BearState)System.Enum.Parse(typeof(BearState), "seek");
        arrive.stateName = (BearState)System.Enum.Parse(typeof(BearState), "arrive");
        pursue.stateName = (BearState)System.Enum.Parse(typeof(BearState), "pursue");

        transitionToIdle = new Transition(idle, conditionOutRange10);
        transitionToSeek = new Transition(seek, conditionOutRange15);
        transitionToArrive = new Transition(arrive, conditionInRange5);
        transitionToPursue = new Transition(pursue, conditionAngry);

        stateMachine.setInitialState(idle);

        //idle.clearTransitions();
        //seek.clearTransitions();
        //arrive.clearTransitions();
        //pursue.clearTransitions();

        idle.addTransition(transitionToArrive);
        arrive.addTransition(transitionToIdle);
        idle.addTransition(transitionToSeek);
        seek.addTransition(transitionToIdle);
        //seek.addTransition(transitionToPursue);
        idle.addTransition(transitionToPursue);
        pursue.addTransition(transitionToArrive);
        pursue.addTransition(transitionToSeek);

    }

    void Update()
    {

        foreach (Condition condition in conditions)
        {
            condition.UpdateCondition(this, target);
        }

        stateMachine.Update();

        switch (stateMachine.getCurrentStateName().getName())
        {
            case BearState.idle:
                print("In Idle State");
                Idle();
                break;

            case BearState.seek:
                print("In Seek State");
                Seek();
                break;

            case BearState.arrive:
                print("In Arrive State");
                Arrive();
                break;

            case BearState.pursue:
                print("In Pursue State");
                Pursue();
                break;

        }

        Displace();
    }

    void LateUpdate()
    {
        velocity += steeringOutput.linear * Time.deltaTime;
        orientation += steeringOutput.angular * Time.deltaTime;

        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized;
            velocity *= speed;
        }

    }

    public void setSteeringSeek(SteeringOutput steeringOut)
    {
        if (stateMachine.getCurrentStateName().getName() == BearState.seek)
        {
            steeringOutput = steeringOut;
        }
    }

    public void setSteeringArrive(SteeringOutput steeringOut)
    {
        if (stateMachine.getCurrentStateName().getName() == BearState.arrive)
        {
            steeringOutput = steeringOut;
        }

    }

    public void setSteeringPursue(SteeringOutput steeringOut)
    {
        if (stateMachine.getCurrentStateName().getName() == BearState.pursue)
        {
            steeringOutput = steeringOut;
        }

    }

    void Displace()
    {
        displacment = (velocity * Time.deltaTime);
        transform.Translate(displacment, Space.World);
    }

    void Idle()
    {
        //velocity = Vector3.zero;
        print("IDLE");
    }

    void Seek()
    {
        print("SEEK");
    }

    void Arrive()
    {
        print("ARRIVE");
    }

    void Pursue()
    {
        maxSpeed = 5;
        speed = 2;
        maxAcceleration = 2;
        print("PURSUE");
    }

    public StateMachine getStateMachine()
    {
        return stateMachine;
    }
}
