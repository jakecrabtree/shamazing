using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    public float ghostTime = 5f;
    public GameObject spawnPoint;
    public GameObject playerPrefab;
    public GameObject ghostPrefab;
    private GameObject _player;
    private List<GameObject> _spawnedGhosts = new List<GameObject>();
    
    private List<Path> _paths;
    private Path _currentPath;
    
    float cur_x;
    float cur_y;
    float timeElapsed;

    void Start()
    {
        //Instantiate New Ghost List and currentGhost
        _paths = new List<Path>();
        _currentPath = new Path();
        //Call level reset
        ResetLevel();
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
    }
    void FixedUpdate()
    {
        //Current InputRaw
        cur_x = Input.GetAxisRaw("Horizontal");
        cur_y = Input.GetAxisRaw("Vertical");
        // Increase TimeElapsed
        timeElapsed += Time.deltaTime;

        TimeDataPoint prev = _currentPath.Back();

        // If we've recieved a new input:
        if((int)Math.Round(cur_y, 0) != (int)Math.Round(prev.y_dir, 0) ||
               (int)Math.Round(cur_x, 0) != (int)Math.Round(prev.x_dir, 0))
        {
            //add new data point
            _currentPath.AddDataPoint(cur_x, cur_y,  timeElapsed);
            //reset elapsed time since last call
            timeElapsed = 0f;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //For testing purposes:
            //press space to reset the level
            _paths.Add(_currentPath);
            _currentPath = new Path();
            Destroy(_player);
            foreach (GameObject ghost in _spawnedGhosts)
            {
                Destroy(ghost);
            }
            _spawnedGhosts.Clear();
            ResetLevel();
        }
    }
}
