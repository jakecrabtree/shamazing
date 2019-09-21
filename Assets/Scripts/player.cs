using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    public float walkSpeed = 10f;
    Rigidbody2D pRigid;

    void Start()
    {
        pRigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        //debug.log(time.deltaTime());    
        pRigid.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * walkSpeed, 0.8f),
            Mathf.Lerp(0, Input.GetAxis("Vertical") * walkSpeed, 0.8f));
    }
}
