using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] private float _spinspeed = 1f;
    private bool _spinning;
    private Rigidbody2D _logBody;

    public void Start()
    {
        _spinning = true;
        _logBody = GetComponent<Rigidbody2D>();
        _logBody.rotation = 45f;
    }

    public void Spin()
    {
        _spinning = true;
        //TODO animation
        //TODO sound
    }

    void FixedUpdate()
    {
        _logBody.rotation += _spinspeed;
        if(_spinspeed > 0 && !_spinning)
        {
            _spinspeed -= .01f;
        } 
        else if(_spinspeed < 1 && _spinning)
        {
            _spinspeed += .01f;
        }
    }
    public void Halt()
    {
        _spinning = false;
        //TODO animation
        //TODO sound
    }
}
