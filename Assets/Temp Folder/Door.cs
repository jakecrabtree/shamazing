using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int requiredSwitches;
    
    private int _currSwitches;
    private Collider2D _collider;
    
    public void Start()
    {
        _collider = GetComponent<Collider2D>();
    }
    
    public void Open()
    {
        Debug.Log("Open");
        if (++_currSwitches == requiredSwitches)
        {
            _collider.enabled = false;
        }
        //TODO animation
        //TODO sound
    }

    public void Close()
    {
        Debug.Log("Close");
        --_currSwitches;
        _collider.enabled = true;
        //TODO animation
        //TODO sound
    }
    
}
