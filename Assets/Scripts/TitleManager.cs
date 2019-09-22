using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{

    public Image screenFader;
    public string[] introFileNames;
    public Image introImage;
    private int ind = 0;

    private void Start()
    {
        screenFader.canvasRenderer.SetAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {

            StartCoroutine(FadeOut(1f, ind++));
        }
    }

    IEnumerator FadeOut(float time, int index)
    {
        screenFader.CrossFadeAlpha(1f, time, false);
        yield return new WaitForSeconds(time);
        if (index < introFileNames.Length)
        {
            screenFader.CrossFadeAlpha(0f, time, false);
            Sprite sprite = Resources.Load<Sprite>("Intro/" + introFileNames[index]);
            introImage.sprite = sprite;
            yield return new WaitForSeconds(time);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
