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
    public List<Renderer> renderers = new List<Renderer>();
    public ScoresList scoresList = new ScoresList();
    // Start is called before the first frame update

    public void displayScores(int index)
    {
        for (int i = 0; i < renderers.Count; i++)
        {
            Renderer renderer = renderers[i];
            Scores scores = scoresList.scoresList[i];
            renderer.material.mainTexture = scores.scores[index];
        }
    }
}
