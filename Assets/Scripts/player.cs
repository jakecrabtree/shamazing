using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    //Public Game Variables
    public float walkSpeed = 10f;
    public GameObject ghostPrefab;

    //Private Game Variables
    private Rigidbody2D pRigid;
    static public bool ghostControl = false;
    private bool slowdown = false;

    void Start() {
        //obtain rigidbody object from attached player object
        pRigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {

        //if we're not controlling a ghost, get keyboard input and translate the player
        pRigid.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * walkSpeed, 0.8f),
            Mathf.Lerp(0, Input.GetAxis("Vertical") * walkSpeed, 0.8f));
        //after player control swaps to ghost, slow player to a nice stop rather than just have it freeze
        if(Input.GetKeyDown("space")) {
            Debug.Log("Space Pressed - Reset");
            
        }
    }
}
