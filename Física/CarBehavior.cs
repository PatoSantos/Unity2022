// Marcelo Eduardo Guillen Castillo
// CarBehavior.cs
// Behavior of the car in the moment of detection of objects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    // properties of the car
    public float moveSpeed;
    public Rigidbody rgbd;

    float xInput;
    float zInput;
    bool isTouching = false;
    bool nodeReached = false;

    public int chosenNode=0;

    public MapBehavior mapbeh_script;

    // methods of the car
    void FixedUpdate()
    {
        xInput = followNextNode(true, chosenNode);
        zInput = followNextNode(false, chosenNode);

        rgbd.velocity = new Vector3(xInput*moveSpeed, rgbd.velocity.y, zInput*moveSpeed);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            isTouching = true;
        }
        else if (collision.gameObject.CompareTag("Node") && !nodeReached)
        {
            Debug.Log(chosenNode);
            chosenNode = addIteration(chosenNode);
            nodeReached = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            isTouching=false;
        }
        else if (collision.gameObject.CompareTag("Node"))
        {
            nodeReached = false;
        }
    }

    // Moves the car according to the corresponding node to follow
    // Recieve: and floating number of the coordinate and a boolean if it is x or z
    private float followNextNode(bool isX, int iter)
    {
        if (isX)
        {
            float difference = (mapbeh_script.nodes[iter].transform.position.x - transform.position.x);
            if (difference < 0)
            {
                return -1f;
            } 
            else if (difference > 0)
            {
                return 1f;
            }
            else
            {
                return 0f;
            }
        }
        else
        {
            float difference = (mapbeh_script.nodes[iter].transform.position.z - transform.position.z);
            if (difference < 0)
            {
                return -1f;
            }
            else if (difference > 0)
            {
                return 1f;
            }
            else
            {
                return 0f;
            }
        }
    }

    // Add one in the iteration of the list, but if is the last one it goes back
    private int addIteration(int iter)
    {
        if(iter+1 >= mapbeh_script.nodes.Length)
        {
            return 0;
        }
        else
        {
            return iter + 1;
        }
    }
}
