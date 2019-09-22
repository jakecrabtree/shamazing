using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    //Object Variables
    public float walkSpeed = 5f;
    private Rigidbody2D gRigid;
    public Animator animatorG;

    private Path _path;

    //set move list
    public void Move(Path path)
    {
        _path = path;
        gRigid = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveAlongPath());
    }

   
    IEnumerator MoveAlongPath()
    {
        TimeDataPoint point;
        for (int i = 0; i < _path.Size() - 1; ++i)
        {
            point = _path.Get(i);
            TimeDataPoint nextPoint = _path.Get(i + 1);
            gRigid.velocity = new Vector2(walkSpeed* point.x_dir, walkSpeed* point.y_dir);
        
            yield return new WaitForSeconds(nextPoint.time);
        }
        point = _path.Get(_path.Size() - 1);
        gRigid.velocity = walkSpeed * new Vector2(point.x_dir, point.y_dir);
    }

    private void Update()
    {
        animatorG.SetFloat("horizontal", gRigid.velocity.x);
        animatorG.SetFloat("vertical", gRigid.velocity.y);
        animatorG.SetFloat("Speed", gRigid.velocity.sqrMagnitude);
        Debug.Log("horizontal " + gRigid.velocity.x);
    }

}
