using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Key : MonoBehaviour
{
   [SerializeField] private Exit exit;

   public void OnCollisionEnter2D(Collision2D other)
   {
      if (!other.collider.CompareTag("Player")) return;
      exit.AddKey();
      Destroy(gameObject);
   }
}
