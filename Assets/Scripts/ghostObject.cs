using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostObject : MonoBehaviour
{
    //Object Variables
    private float timeRemaining = 10f;
    private float walkSpeed = 10f;
    private Rigidbody2D gRigid;

    //Time Elapsed since Last Call
    private float timeElapsed;

    //Movement list
    public List<timeDataPoint> dataPoints;

    void Awake()
    {
        //Reset timeElapsed and get Rigidbody (CRASHES UNITY)
        timeElapsed = 0f;
        Debug.Log("Before Rigidbody get");
        gRigid = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log("After Rigidbody get");
    }
    void beginMove()
    {
        //For each point in dataPoints:
        foreach (timeDataPoint point in dataPoints)
        {
            //for as long as we moved in this direction, do:
            while(timeElapsed <= point.time)
            {
                Debug.Log(gRigid);
                //Moved object according to inputs
                gRigid.velocity = new Vector2(Mathf.Lerp(0, point.x_dir * walkSpeed, 0.8f),
                    Mathf.Lerp(0, point.y_dir * walkSpeed, 0.8f));
            }
            //reset timeElapsed
            timeElapsed = 0f;
        }
    }
    //set move list
    public void getMove(ghost inputVal)
    {
        dataPoints = inputVal.dataPoints;
        beginMove();
    }
}
