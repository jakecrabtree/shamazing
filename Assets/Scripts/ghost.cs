using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    private float timeRemaining = 10f;
    private float walkSpeed = 10f;
    private Rigidbody2D gRigid;

    void Start() {
        gRigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {

        if(player.ghostControl) {
            gRigid.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * walkSpeed, 0.8f),
                Mathf.Lerp(0, Input.GetAxis("Vertical") * walkSpeed, 0.8f));
        }

        if (Input.GetKeyDown("space")) {
            player.ghostControl = false;
        }
        if (player.ghostControl == false && gRigid.velocity != new Vector2(0, 0)) {
            gRigid.velocity = gRigid.velocity * .9f;
        }
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0) {
            player.ghostControl = false;
            Destroy(gameObject);
            Debug.Log("Object should be destroyed");
        }
    }
}
