using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeHandler : MonoBehaviour
{
    public float timeRemaining = 10f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0)
        {
            //player.ghostControl = false;
            //Destroy(gameObject);
            Debug.Log("Object should be destroyed");
        }
    }
}
