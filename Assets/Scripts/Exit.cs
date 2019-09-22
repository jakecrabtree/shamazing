using System;
using System.Collections;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private int requiredKeys;
    private int _currKeys;
    private bool _exitable;
    public AudioSource audioSource;

    private void Awake()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

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
            Debug.Log("Level completed.");
            //TODO Play animation first
            TimeHandler.instance._player.GetComponent<Player>().active = false;
            TimeHandler.instance._player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            TimeHandler.instance.StopAllCoroutines();
            TimeHandler.instance.active = false;

            StartCoroutine(VictoryAnimation());

            //GameManager.Instance.NextLevel();
        }
    }

    IEnumerator VictoryAnimation()
    {
        foreach(GameObject ghost in TimeHandler.instance._spawnedGhosts)
        {
            Debug.Log("Ghost Found");
            Ghost ghostObject = ghost.GetComponent<Ghost>();
            if(ghostObject != null)
            {
                ghostObject.MoveTowardPlayer();
            }
        }
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        TimeHandler.instance._player.GetComponent<Player>().active = true;
        TimeHandler.instance.active = true;
        TimeHandler.instance = null;

        GameManager.Instance.NextLevel();
    }
    
}
