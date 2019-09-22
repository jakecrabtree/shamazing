using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{

    public Image screenFader;

    private void Start()
    {
        screenFader.canvasRenderer.SetAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {

            StartCoroutine(FadeOut(1f));
        }
    }

    IEnumerator FadeOut(float time)
    {
        screenFader.CrossFadeAlpha(1f, time, false);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1);
        //screenFader.CrossFadeAlpha(0f, time, false);
        yield break;
    }
}
