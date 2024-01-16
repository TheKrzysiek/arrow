using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    
[SerializeField]
public TextMeshPro ScoreDisplay;

[SerializeField]
public TextMeshPro FinalScoreDisplay;

[SerializeField]
public TextMeshPro FinalArrowCount;

[SerializeField]
public GameObject ArrowCountGO;

[SerializeField]
public GameObject FinalScoreExplanationGO;

[SerializeField]
public GameObject FinalScoreDisplayGO;

public int ScoreCount = 0;

private int FinalScoreCount = 0;

private int ArrowCount = 0;

public void AddScore(int a)
{
    ScoreCount += a;
    ScoreDisplay.text = "Score:" + ScoreCount.ToString();
}

public void AddArrowCount()
{
    ArrowCount += 1;
}

public void FinalScore()
{
    FinalScoreDisplayGO.SetActive(true);
    ArrowCountGO.SetActive(true);
    FinalScoreExplanationGO.SetActive(true);

    FinalScoreCount = (ScoreCount * 2) - ArrowCount;

    FinalScoreDisplay.text = "Final score: " + FinalScoreCount.ToString();
    FinalArrowCount.text = "Arrows shot: " + ArrowCount.ToString();
}

public void SendScore()
{
    FindObjectOfType<SaveScore>().AssignScore(FinalScoreCount);
}

public void ScoreReset()
{
    ScoreCount = 0;
    FinalScoreCount = 0;
    ArrowCount = 0;
}

}
