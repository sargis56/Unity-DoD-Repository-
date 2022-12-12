using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject targetNode1;
    public GameObject targetNode2;
    public GameObject targetNode3;
    public GameObject targetNode4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        DrawLines();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        DrawLines();


    }

    void DrawLines()
    {
        if (targetNode1 == null)
        {
            return;
        }
        else
        {

            Gizmos.DrawLine(transform.position, targetNode1.transform.position);
        }

        if (targetNode2 == null)
        {
            return;
        }
        else
        {
            Gizmos.DrawLine(transform.position, targetNode2.transform.position);
        }

        if (targetNode3 == null)
        {
            return;
        }
        else
        {
            Gizmos.DrawLine(transform.position, targetNode3.transform.position);
        }

        if (targetNode4 == null)
        {
            return;
        }
        else
        {
            Gizmos.DrawLine(transform.position, targetNode4.transform.position);
        }
        
    }
}
