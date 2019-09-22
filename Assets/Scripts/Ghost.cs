using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    //Object Variables
    private float walkSpeed = 5f;
    private Rigidbody2D gRigid;
    private Vector2 velocity;
    private Vector2 goalPoint;

    private Path _path;

    //set move list
    public void Move(Path path)
    {
        _path = path;
        gRigid = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveAlongPath());
    }

    public void FixedUpdate()
    {
        if (gRigid == null) return;
       /* Vector2 endDest = goalPoint - (Vector2) transform.position;
        endDest /= endDest.magnitude;
        Debug.Log("v: " + velocity + "endDest: " + endDest);
        Vector2 dir = (velocity + endDest) / 2.0f;*/
        gRigid.velocity = walkSpeed * velocity;

    }

    IEnumerator MoveAlongPath()
    {
        TimeDataPoint point;
        for (int i = 0; i < _path.Size(); ++i)
        {
            point = _path.Get(i);
            velocity = new Vector2(point.x_dir,  point.y_dir);
            goalPoint = new Vector2(point.x_pos, point.y_pos);
            velocity = (velocity.magnitude == 0.0f) ? Vector2.zero : velocity/velocity.magnitude;
            gRigid.velocity = walkSpeed * velocity;
            yield return new WaitForSeconds(point.time);
        }
    }
    
}
