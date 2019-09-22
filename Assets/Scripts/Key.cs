using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Key : MonoBehaviour
{
   [SerializeField] private Exit exit;
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private SpriteRenderer spriteRenderer; //Needed to hide key
    private Boolean active = true;

    private void Awake()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
   {
        if(active)
        {
            //Debug.Log("Trigger entered");
            if (!other.CompareTag("Player")) return;
            Debug.Log("Key collected");
            exit.AddKey();
            active = false;
            spriteRenderer.enabled = false;
            audioSource.Play();
        }
      
   }
}
