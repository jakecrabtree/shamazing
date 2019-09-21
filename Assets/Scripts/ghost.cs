using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    private float timeRemaining = 10f;

    void Start() {

    }
    void FixedUpdate() {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0) {
            Destroy(gameObject);
            Debug.Log("Object should be destroyed");
        }
    }
}
