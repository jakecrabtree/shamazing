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

    [SerializeField] private Sprite inactive;
    [SerializeField] private Sprite active;
    [SerializeField] private ParticleSystem partSys;

    [SerializeField] private DialogueManager dialogueManager;

    private void Awake()
    {

        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void On()
    {
        Debug.Log("on");
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
            partSys.Play();
            this.GetComponent<SpriteRenderer>().sprite = active;
            audioSource.clip = activationSound;
            audioSource.Play();
            On();
            if (GameManager.Instance.tutorialMode)
            {
                dialogueManager.Convo2();
            }
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            partSys.Stop();
            GetComponent<SpriteRenderer>().sprite = inactive;
            audioSource.clip = deactivationSound;
            audioSource.Play();
            Off();
        }
    }
}
