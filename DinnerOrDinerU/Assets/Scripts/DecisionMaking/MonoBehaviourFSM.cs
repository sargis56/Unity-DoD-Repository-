using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourFSM : MonoBehaviour
{
    public GameObject target;
    protected BearFSM character;

    public enum BearState
    {
        idle,
        seek,
        arrive,
        pursue
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        character = GetComponent<BearFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        character.setSteeringSeek(getSteeringSeek());
        character.setSteeringArrive(getSteeringArrive());
        character.setSteeringPursue(getSteeringPursue());
    }

    public virtual SteeringOutput getSteering()
    {
        return new SteeringOutput();
    }

    public virtual SteeringOutput getSteeringSeek()
    {
        return new SteeringOutput();
    }

    public virtual SteeringOutput getSteeringArrive()
    {
        return new SteeringOutput();
    }

    public virtual SteeringOutput getSteeringPursue()
    {
        return new SteeringOutput();
    }
}
