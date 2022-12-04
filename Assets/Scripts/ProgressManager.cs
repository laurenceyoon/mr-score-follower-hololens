using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressManager : MonoBehaviour
{
    public float progress = 0f;
    private List<float> thresholds = new List<float> { 
        0f, 80f
    };
    private int currentIndex = 0;

    [SerializeField]
    public GameObject progressUI;
    public GameObject[] scoreList;

    public void updateProgress(float value)
    {
        progress = value;
        progressUI.GetComponent<TextMeshPro>().SetText("Progress : " + progress.ToString());

        setScore();
    }
    public void addProgress(float value)
    {
        progress += value;
        progressUI.GetComponent<TextMeshPro>().SetText("Progress : " + progress.ToString());
    }

    void setScore()
    {
        for (int i = 0; i < thresholds.Count; i++)
        {
            float threshold = thresholds[i];
            if (progress > threshold && currentIndex != i)
            {
                Debug.Log($"progress({progress}) > threshold({threshold})");
                currentIndex = i;
                Debug.Log($"currentIndex updated!: {currentIndex}");
                updateImages();
            }
        }
    }

    public void resetScore()
    {
        currentIndex = 0;

    }

    void updateImages()
    {
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().displayScores(currentIndex);
    }
}
