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

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip activationSound;
    [SerializeField] private AudioClip deactivationSound;

    private void Awake()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

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
        audioSource.clip = activationSound;
        audioSource.Play();
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
        audioSource.clip = deactivationSound;
        audioSource.Play();
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
