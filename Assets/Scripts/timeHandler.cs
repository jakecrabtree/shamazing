using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeHandler : MonoBehaviour
{
    public float timeRemaining = 10f;
    public GameObject spawnPoint;
    public GameObject player;
    public GameObject ghost;
    private GameObject ghostBeingInstantiated;

    private List<ghost> ghosts;
    private ghost currentGhost;

    float prev_x;
    float prev_y;
    float cur_x;
    float cur_y;
    float timeElapsed;

    void Start()
    {
        //Instantiate New Ghost List and currentGhost
        ghosts = new List<ghost>();
        currentGhost = new ghost();
        //Call level reset
        levelReset();
    }
    void levelReset()
    {
        Debug.Log("Level Reset Called");
        //Instantiate new player
        player = Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
        Debug.Log("Player Instantiated");
        //for each ghost in ghost list:
        foreach(ghost ghah in ghosts) {
            Debug.Log("For Entered");
            //instantiate new ghost object, set to curGhost
            ghostBeingInstantiated = Instantiate(ghost, spawnPoint.transform.position, Quaternion.identity);
            //curGhost set the move list in the new object to the current ghost
            ghostBeingInstantiated.GetComponent<ghostObject>().getMove(ghah);
        }
        //set prev_x and y to current movement (so if they're holding a key down when they respawn
        //it keeps movement
        prev_x = Input.GetAxisRaw("Horizontal");
        prev_y = Input.GetAxisRaw("Vertical");
        timeElapsed = 0f;

        //add blank datapoint to currentGhost dataPoint list
        currentGhost.addDataPoint(prev_x, prev_y, player.transform.position.x, player.transform.position.y, timeElapsed);
    }
    void FixedUpdate()
    {
        //Current InputRaw
        cur_x = Input.GetAxisRaw("Horizontal");
        cur_y = Input.GetAxisRaw("Vertical");
        // Increase TimeElapsed
        timeElapsed += Time.fixedTime;

        // If we've recieved a new input:
        if(cur_x != prev_x || cur_y != prev_y)
        {
            Debug.Log("Change in Input");
            //Change prev_x and prev_y to current directions
            prev_x = cur_x;
            prev_y = cur_y;
            //add new data point
            currentGhost.addDataPoint(cur_x, cur_y, player.transform.position.x, player.transform.position.y, timeElapsed);
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
            Debug.Log("Space Pressed - Reset");
            resetLevel();
        }
    }
    void resetLevel() {
        //Add current ghost to the ghost list
        ghosts.Add(currentGhost);
        currentGhost = new ghost();
        //Destroy(player);
        levelReset();
    }
}
