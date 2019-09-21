using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemSwitch : MonoBehaviour
{

    [SerializeField] private Door door;

    private void On()
    {
        door.Open();
    }

    private void Off()
    {
        door.Close();
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            On();
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Off();
        }
    }
}
