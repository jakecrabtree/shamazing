using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int requiredSwitches;
    [SerializeField] private GameObject particles;
    
    private int _currSwitches;
    private Collider2D _collider;
    private ParticleSystem _pSystem;
    
    public void Start()
    {
        _collider = GetComponent<Collider2D>();
        _pSystem = particles.GetComponent<ParticleSystem>();
    }
    
    public void Open()
    {
        Debug.Log("Open");
        if (++_currSwitches == requiredSwitches)
        {
            _collider.enabled = false;
            _pSystem.Stop();
        }
        //TODO animation
        //TODO sound
    }

    public void Close()
    {
        Debug.Log("Close");
        --_currSwitches;
        _collider.enabled = true;
        _pSystem.Play();
        //TODO animation
        //TODO sound
    }
    
}
