using System;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private int requiredKeys;
    private int _currKeys;
    [SerializeField]private bool _exitable;

    public void Start()
    {
        CheckKeys();
    }
    
    private void CheckKeys()
    {
        if (_currKeys == requiredKeys)
        {
            _exitable = true;
        }
    }
    
    public void AddKey()
    {
        _currKeys++;
        CheckKeys();
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") &&  _exitable)
        {
            //TODO Play animation first
            GameManager.Instance.NextLevel();
        }
    }
    
}
