using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> currentSentences;

    void Start()
    {
        currentSentences = new Queue<string>();
    }
}
