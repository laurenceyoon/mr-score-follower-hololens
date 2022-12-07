using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressManager : MonoBehaviour
{
    public float progress = 0f;
    private List<float> thresholds = new List<float> { 
        0f, 80f, 228f
    };
    private int currentIndex = 0;
    private float currentImageProgress = 0f;  // 0~1

    [SerializeField]
    public GameObject progressUI;
    public GameObject maskObject;
    private Vector3 maskScale;
    private float maskXScale;
    //public GameObject[] scoreList;

    private void Awake()
    {
        maskScale = maskObject.transform.localScale;
        maskXScale = maskScale.x;
    }
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

            //progress 가 올라가는 것을 감지해서 ..120이야 ((progress - thresholds[i])/thresholds[i+1] - thresholds[i]))
            //currentIndex 먼저 확인하고(몇번째이미지인지 확인한후) currentIndex = i
            //임계값 threshols  

            if (progress > threshold && currentIndex != i)
            {
                Debug.Log($"progress({progress}) > threshold({threshold})");
                currentIndex = i;
                Debug.Log($"currentIndex updated!: {currentIndex}");
                updateImages();
            }
        }
        //currentImageProgress
        float beforeImageProgress = currentImageProgress;
        float targetImageProgress = (progress - thresholds[currentIndex]) / (thresholds[currentIndex + 1] - thresholds[currentIndex]);

        //Maskscal의 x값에 
        
        //maskScale.x = maskXScale * targetImageProgress;
        maskObject.transform.localScale = new Vector3(maskXScale * targetImageProgress, maskScale.y, maskScale.z);
        Debug.Log($"targetImageProgress: {targetImageProgress} / maskObject.transform.localScale: {maskObject.transform.localScale}");
        //  
        currentImageProgress = targetImageProgress;
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
