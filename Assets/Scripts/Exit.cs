using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

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

            Time.timeScale = 2f;

            StartCoroutine(VictoryAnimation(other.gameObject));
            //GameManager.Instance.NextLevel();
        }
    }

    IEnumerator VictoryAnimation(GameObject pew)
    {
        foreach(GameObject ghost in TimeHandler.instance._spawnedGhosts)
        {
            Debug.Log("Ghost Found");
            Ghost ghostObject = ghost.GetComponent<Ghost>();
            if (ghostObject != null)
            {
                ghostObject.MoveTowardPlayer();
            }
        }
        AudioMixer audioMixer = GameManager.Instance.audioMixer;
        audioMixer.FindSnapshot("Paused").TransitionTo(0.1f);
        audioSource.Play();
        StartCoroutine(Pew(pew));
        yield return new WaitForSeconds(audioSource.clip.length * 0.8f);
        TimeHandler.instance._player.GetComponent<Player>().active = true;
        TimeHandler.instance.active = true;
        TimeHandler.instance = null;

        audioMixer.FindSnapshot("Default").TransitionTo(0.1f);
        Time.timeScale = 1f;
    }

    IEnumerator Pew(GameObject pew)
    {
        yield return new WaitForSeconds(audioSource.clip.length * 0.7f);
        GameObject ring = pew.GetComponent<Player>().ring;
        ring.SetActive(true);
        Vector2 scale = ring.transform.localScale;
        for (float i = 0; i <= 1f; i += Time.fixedDeltaTime)
        {
            ring.transform.localScale = Vector2.Lerp(scale, Vector2.one * 20f, i);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        ring.transform.localScale = scale;
        ring.SetActive(false);
        GameManager.Instance.NextLevel();
    }
    
}
