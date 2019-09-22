﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
<<<<<<< HEAD
    //Object Variables
//<<<<<<< HEAD
    public float walkSpeed = 5f;
    public Rigidbody2D gRigid;
    public Animator animatorG;
//=======
   // private float walkSpeed = 5f;
    [HideInInspector] public float returnTime = 10f;
   // private Rigidbody2D gRigid;
    private Collider2D collider;
//>>>>>>> 54a4ef75fc28fff17e0393c6101bc85e0f60c008
=======
    public Animator animatorG;
    private float walkSpeed = 5f;
    [HideInInspector] public float returnTime = 5f;
    private Rigidbody2D gRigid;
    private Collider2D collider;
>>>>>>> 01f9d7004a94ad663556ce9f012610e82611d6d9

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

<<<<<<< HEAD
//<<<<<<< HEAD
=======
>>>>>>> 01f9d7004a94ad663556ce9f012610e82611d6d9
    private void Update()
    {
        animatorG.SetFloat("horizontal", gRigid.velocity.x);
        animatorG.SetFloat("vertical", gRigid.velocity.y);
        animatorG.SetFloat("Speed", gRigid.velocity.sqrMagnitude);
        Debug.Log("horizontal " + gRigid.velocity.x);
    }

<<<<<<< HEAD
//=======
=======

>>>>>>> 01f9d7004a94ad663556ce9f012610e82611d6d9
    public void MoveTowardPlayer()
    {
        StopAllCoroutines();
        gRigid.velocity = Vector2.zero;
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
        float playerX = TimeHandler.instance._player.transform.position.x;
        float playerY = TimeHandler.instance._player.transform.position.y;

        StartCoroutine(MoveTo(playerX, playerY, returnTime));
    }

    public void MoveTowardPlayer(float moveTime)
    {
        StopAllCoroutines();
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
        float playerX = TimeHandler.instance._player.transform.position.x;
        float playerY = TimeHandler.instance._player.transform.position.y;

        StartCoroutine(MoveTo(playerX, playerY, moveTime));
    }

    IEnumerator MoveTo(float x, float y, float time)
    {
        Vector3 destination = new Vector2(x, y);

        float sqrRemainingDistance = (transform.position - destination).sqrMagnitude;

        while(sqrRemainingDistance > float.Epsilon)
        {
            transform.position = Vector2.Lerp(transform.position, destination, (3/time) * Time.deltaTime);

            sqrRemainingDistance = (transform.position - destination).sqrMagnitude;

            yield return null;
        }

        /*
        float timeElapsed = 0;

        while(timeElapsed < time)
        {
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * time);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        */
        yield break;
        
    }

<<<<<<< HEAD

    
//>>>>>>> 54a4ef75fc28fff17e0393c6101bc85e0f60c008
=======
>>>>>>> 01f9d7004a94ad663556ce9f012610e82611d6d9
}
