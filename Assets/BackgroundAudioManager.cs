using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioManager : MonoBehaviour
{
    public static BackgroundAudioManager instance;

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

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
