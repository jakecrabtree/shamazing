using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeHandler : MonoBehaviour
{
    public float timeRemaining = 10f;
    public GameObject spawnPoint;
    public GameObject player;
    public GameObject ghost;

    private List<ghost> ghosts;
    private ghost currentGhost;

    int prev_x;
    int prev_y;

    void Start()
    {
        Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
        ghosts = new List<ghost>();
        currentGhost = new ghost();

        prev_x;
        prev_y;
    }

    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") != prev_x || Input.GetAxisRaw("Vertical") != prev_y)
        {

        }
        /*timeRemaining -= time.fixedTime;
        if (timeRemaining < 0)
        {
            resetLevel();
            Debug.Log("Object should be destroyed");
        } */
    }
    void resetLevel() {

        ghosts.Add(currentGhost);
        currentGhost = new ghost();
    }
}
