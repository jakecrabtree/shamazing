﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public static TimeHandler instance;
    public float ghostTime = 10f;
    public int lives = 3;
    public GameObject spawnPoint;
    public GameObject playerPrefab;
    public GameObject ghostPrefab;
    public GameObject _player;
    [HideInInspector] public List<GameObject> _spawnedGhosts = new List<GameObject>();
    private GameManager _manager = GameManager.Instance;
    private Coroutine _coroutine;
    [HideInInspector] public bool active = true;
    
    public TextMeshProUGUI livesText;
    public Slider timeSlider;

    private List<Path> _paths;
    private Path _currentPath;
    private int _currentLives;
    
    float cur_x;
    float cur_y;
    float timeElapsed;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Instantiate New Ghost List and currentGhost
        _paths = new List<Path>();
        _currentPath = new Path();
        //Call level reset
        ResetLevel();
        //Invoke(nameof(Die), ghostTime);
        _currentLives = lives;
        livesText.text = "x " + (_currentLives - 1);
        timeSlider.maxValue = ghostTime;
        timeSlider.value = ghostTime;
    }
    void ResetLevel()
    {
        //Instantiate new player
        _player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
        //for each ghost in ghost list:
        foreach(Path path in _paths) {
            //instantiate new ghost object, set to curGhost
            GameObject ghostBeingInstantiated = Instantiate(ghostPrefab, spawnPoint.transform.position, Quaternion.identity);
            //curGhost set the move list in the new object to the current ghost
            ghostBeingInstantiated.GetComponent<Ghost>().Move(path);
            _spawnedGhosts.Add(ghostBeingInstantiated);
        }
        //set prev_x and y to current movement (so if they're holding a key down when they respawn
        //it keeps movement
        float initialX = Input.GetAxisRaw("Horizontal");
        float initialY = Input.GetAxisRaw("Vertical");
        timeElapsed = 0f;

        //add blank datapoint to currentGhost dataPoint list
        _currentPath.AddDataPoint(initialX, initialY, timeElapsed);
        _coroutine = StartCoroutine(DieRoutine(ghostTime));
    }
    void FixedUpdate()
    {
        if(active)
        {
            //Current InputRaw
            cur_x = Input.GetAxisRaw("Horizontal");
            cur_y = Input.GetAxisRaw("Vertical");
            // Increase TimeElapsed
            timeElapsed += Time.deltaTime;

            TimeDataPoint prev = _currentPath.Back();

            // If we've recieved a new input:
            if ((int)Math.Round(cur_y, 0) != (int)Math.Round(prev.y_dir, 0) ||
                   (int)Math.Round(cur_x, 0) != (int)Math.Round(prev.x_dir, 0))
            {
                //add new data point
                _currentPath.AddDataPoint(cur_x, cur_y, timeElapsed);
                //reset elapsed time since last call
                timeElapsed = 0f;
            }
            if(GameManager.Instance.tutorialMode == false && GameManager.Instance._currentScene == 0)
            {
                GameManager.Instance.NextLevel();
            }
        }
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !GameManager.Instance.tutorialMode)
        {
            //For testing purposes:
            //press space to reset the level
            Die();
        }
    }
    void Die()
    {
        //_currentPath.AddDataPoint(0, 0, timeElapsed);
        _paths.Add(_currentPath);
        _currentPath = new Path();
        Destroy(_player);
        foreach (GameObject ghost in _spawnedGhosts)
        {
            Destroy(ghost);
        }
        _spawnedGhosts.Clear();
        _currentLives--;
        livesText.text = "x " + (_currentLives - 1);
        if (_currentLives == 0)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            StopCoroutine(_coroutine);
            ResetLevel();
        }
    }

    IEnumerator DieRoutine(float seconds)
    {
        Debug.Log("Die Routine");
        timeSlider.maxValue = seconds;
        float elapsedTime = 0f;
        while(true)
        {
            //Debug.Log(elapsedTime);
            if (!GameManager.Instance.tutorialMode)
            {
                timeSlider.value = (seconds - elapsedTime);
                if (elapsedTime >= seconds)
                {
                    Die();
                    elapsedTime = 0;
                }
            }

            yield return null;
            if (!GameManager.Instance.tutorialMode)
            {
                elapsedTime += Time.deltaTime;
            }
            //Debug.Log("Late timeElapsed: " + timeElapsed);
        }
        
    }
    
}
