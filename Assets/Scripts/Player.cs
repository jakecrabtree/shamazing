using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //Public Game Variables
    public float walkSpeed = 5f;
    [HideInInspector] public bool active = true;
    public Animator animator;
    [HideInInspector] public float returnTime = 10f;

    
    Vector2 movement;

    //Private Game Variables
    private Rigidbody2D pRigid;
    public GameObject ring;
    private Collider2D collider;


    void Start() {
        //obtain rigidbody object from attached player object
        pRigid = gameObject.GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        if(active)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");


            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    void FixedUpdate() {

        if(active)
        {
            //if we're not controlling a ghost, get keyboard input and translate the player
            pRigid.velocity = walkSpeed * new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            /*pRigid.velocity = (pRigid.velocity.magnitude == 0)
                ? Vector2.zero
                : pRigid.velocity / pRigid.velocity.magnitude;
            pRigid.velocity *= walkSpeed;*/
            //after player control swaps to ghost, slow player to a nice stop rather than just have it freeze
        }

    }
    
    public void MoveTowardPlayer(float x, float y)
    {
        StopAllCoroutines();
        pRigid.velocity = Vector2.zero;
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
        // float playerX = TimeHandler.instance._player.transform.position.x;
        //float playerY = TimeHandler.instance._player.transform.position.y;

        StartCoroutine(MoveTo(x, y, returnTime));
    }
    
    IEnumerator MoveTo(float x, float y, float time)
    {
        Vector3 destination = new Vector2(x, y);

        float sqrRemainingDistance = (transform.position - destination).sqrMagnitude;

        while(sqrRemainingDistance > float.Epsilon)
        {
            transform.position = Vector2.Lerp(transform.position, destination, (6/time) * Time.deltaTime);

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
}
