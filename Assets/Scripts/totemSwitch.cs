using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemSwitch : MonoBehaviour
{
    enum objectTypes
    {
        Door,
        Log,
    }

    [SerializeField] private Door door;
    [SerializeField] private Log log;

    [SerializeField] private objectTypes dropdown;


    private void On()
    {
        switch(dropdown)
        {
            case objectTypes.Door:
                door.Open();
                break;
            case objectTypes.Log:
                log.Halt();
                break;
        }
    }

    private void Off()
    {
        switch (dropdown)
        {
            case objectTypes.Door:
                door.Close();
                break;
            case objectTypes.Log:
                log.Spin();
                break;
        }
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
