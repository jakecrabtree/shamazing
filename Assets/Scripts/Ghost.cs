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
    public Animator animatorG;
    private Collider2D collider;
    [HideInInspector] public float returnTime = 5f;
    
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
            velocity = (velocity.magnitude == 0.0f) ? Vector2.zero : velocity/velocity.magnitude;
            gRigid.velocity = walkSpeed * velocity;
            yield return new WaitForSeconds(point.time);
        }
    }


    private void Update()
    {
        animatorG.SetFloat("horizontal", gRigid.velocity.x);
        animatorG.SetFloat("vertical", gRigid.velocity.y);
        animatorG.SetFloat("Speed", gRigid.velocity.sqrMagnitude);
        Debug.Log("horizontal " + gRigid.velocity.x);
    }

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

    }

}
