using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressManager : MonoBehaviour
{
    public float progress = 0f;
    private float threshold = 80f;

    [SerializeField]
    public GameObject progressUI;
    public GameObject[] scoreList;

    public void updateProgress(float value)
    {
        progress = value;
        Debug.Log(progress);
        progressUI.GetComponent<TextMeshPro>().SetText("Progress : " + progress.ToString());

        setScore();
    }
    public void addProgress(float value)
    {
        progress += value;
        Debug.Log(progress);
        progressUI.GetComponent<TextMeshPro>().SetText("Progress : " + progress.ToString());
    }

    void setScore()
    {
        //Debug.Log(index.ToString() + progress.ToString());
        if (progress > threshold)
        {
            //scoreList[1].SetActive(true);
        }
        else
        {
            //scoreList[1].SetActive(false);
        }
    }
}
