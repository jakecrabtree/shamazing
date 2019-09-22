using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //Public Game Variables
    public float walkSpeed = 5f;
    [HideInInspector] public bool active = true;

    //Private Game Variables
    private Rigidbody2D pRigid;

    void Start() {
        //obtain rigidbody object from attached player object
        pRigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {

        if(active)
        {
            //if we're not controlling a ghost, get keyboard input and translate the player
            pRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * walkSpeed, Input.GetAxisRaw("Vertical") * walkSpeed);
            //after player control swaps to ghost, slow player to a nice stop rather than just have it freeze
        }

    }
}
