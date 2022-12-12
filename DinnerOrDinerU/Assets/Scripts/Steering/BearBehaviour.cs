using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearBehaviour : MonoBehaviour
{
    public GameObject target;
    protected Bear character;

    // Start is called before the first frame update
    public virtual void Start()
    {
        character = GetComponent<Bear>();
    }

    // Update is called once per frame
    void Update()
    {
        character.setSteering(getSteering());
    }

    public virtual SteeringOutput getSteering()
    {
        return new SteeringOutput();
    }
}
