using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    /* private float timeRemaining = 10f;
    private float walkSpeed = 10f;
    private Rigidbody2D gRigid; */

    public struct timeDataPoint {
        int pos_x;
        int pos_y;
        int x_dir; //-1, 0, or 1
        int y_dir; //-1, 0, or 1
        float time1;
        float time2;
    }

    public List<timeDataPoint> dataPoints;

    void Start() {
        //gRigid = gameObject.GetComponent<Rigidbody2D>();
        dataPoints = new List<timeDataPoint>();
    }
    void FixedUpdate() {

    }
    void addDataPoint() {

    }
}
