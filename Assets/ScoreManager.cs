using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scores
{
    public List<Texture> scores;
}
[System.Serializable]
public class ScoresList
{
    public List<Scores> scoresList;
}

public class ScoreManager : MonoBehaviour
{
    //material texture change
    //public Material myMaterial;
    public List<Renderer> renderers = new List<Renderer>();
    public ScoresList scoresList = new ScoresList();
    public int index;
    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        foreach (Renderer renderer in renderers)
        {
            foreach (Scores scores in scoresList.scoresList)
            {
                Texture scoreImage = scores.scores[index];
                renderer.material.mainTexture = scoreImage;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
