using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //Public Game Variables
    public float walkSpeed = 5f;

    //Private Game Variables
    private Rigidbody2D pRigid;

    void Start() {
        //obtain rigidbody object from attached player object
        pRigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {

        //if we're not controlling a ghost, get keyboard input and translate the player
        pRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        pRigid.velocity = (pRigid.velocity.magnitude == 0.0f) ? Vector2.zero : pRigid.velocity/pRigid.velocity.magnitude;
        pRigid.velocity *= walkSpeed;
        //after player control swaps to ghost, slow player to a nice stop rather than just have it freeze
    }
}
