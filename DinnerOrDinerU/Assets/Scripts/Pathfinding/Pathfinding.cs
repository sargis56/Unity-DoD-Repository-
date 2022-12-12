using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject node;
    public float speed = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(GameObject nodeToMove)
    {
        Vector3 p0 = transform.position;
        Vector3 p1 = nodeToMove.transform.position;
        Vector3 newPos = transform.position + (speed + 5) * Time.deltaTime * (p1 - p0).normalized;
        transform.position = newPos;
    }

}
