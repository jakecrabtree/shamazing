using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Key : MonoBehaviour
{
   [SerializeField] private Exit exit;

   public void OnTriggerEnter2D(Collider2D other)
   {
        Debug.Log("Trigger entered");
      if (!other.CompareTag("Player")) return;
      Debug.Log("Key collected");
      exit.AddKey();
      Destroy(gameObject);
   }
}
