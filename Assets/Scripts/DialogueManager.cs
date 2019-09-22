using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private string convo1;
    [SerializeField] private Transform camPt1;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private string[] convo2;
    [SerializeField] private string[] convo2Speakers;
    private bool validPress = false;
    private int step = 0;
    private int convoPos = 0;
    void Start()
    { 
        Invoke(nameof(Convo1), 0.5f);
    }

    public void Convo2()
    {
        dialogueBox.SetActive(true);
        textObject.text = convo2[convoPos];
        validPress = true;
    }

    void Convo1()
    {
        dialogueBox.SetActive(true);
        textObject.text = convo1;
        validPress = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && validPress)
        {
            if (step == 0)
            {
                dialogueBox.SetActive(false);
                StartCoroutine(MoveTo(camPt1.position, 1, 0));
                StartCoroutine(ZoomTo(1.2f, 1f, 1));
                StartCoroutine(ZoomTo(8f, 1f, 3f)); 
                StartCoroutine(MoveTo(Vector3.forward * -10f, 1, 4f));
                validPress = false;
                ++step;
            }else if (step == 1)
            {
                if(++convoPos < convo2.Length)
                {
                    textObject.text = convo2[convoPos];
                }
                else
                {
                    validPress = false;
                    dialogueBox.SetActive(false);
                    ++step;
                    GameManager.Instance.tutorialMode = false;
                }
            }
        }
    }

    IEnumerator MoveTo(Vector3 pos, float time, float offset)
    {
        yield return new WaitForSeconds(offset);
        Vector2 start = Camera.main.transform.position;
        for (float i = 0; i <= 1f; i += Time.fixedDeltaTime)
        {
            Camera.main.transform.position = Vector3.Lerp(start, pos, i);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        
    }
    IEnumerator ZoomTo(float amt, float time, float offset)
    {
        yield return new WaitForSeconds(offset);
        float start = Camera.main.orthographicSize;
        for (float i = 0; i <= time; i += Time.fixedDeltaTime)
        {
            Camera.main.orthographicSize = Mathf.Lerp(start, amt, i);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }
}
