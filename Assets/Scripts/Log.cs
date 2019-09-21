using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] private float _spinspeed = 1f;
    private int _spinning;
    private Rigidbody2D _logBody;

    public void Start()
    {
        _spinning = 1;
        _logBody = GetComponent<Rigidbody2D>();
        _logBody.rotation = 45f;
    }

    public void Spin()
    {
        _spinning = 1;
        _spinspeed = 1f;
        //TODO animation
        //TODO sound
    }

    void FixedUpdate()
    {
        _logBody.rotation += _spinspeed;
        if(_spinspeed > 0 && _spinning == 0)
        {
            _spinspeed -= .01f;
        }
    }
    public void Halt()
    {
        _spinning = 0;
        //TODO animation
        //TODO sound
    }
}
