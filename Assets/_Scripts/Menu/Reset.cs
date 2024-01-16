using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour, IHittable
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private GameObject reset;

    [SerializeField]
    private GameObject start;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject score;

    [SerializeField]
    private GameObject timer;

    [SerializeField]
    private GameObject keyboard;

    [SerializeField]
    private GameObject arrowcount;

    [SerializeField]
    private GameObject scoreexplain;

    [SerializeField]
    private GameObject finalscore;

    [SerializeField]
    private GameObject savescore;

    [SerializeField]
    private GameObject playername;

    public void GetHit()
    {                
        start.SetActive(true);
        FindObjectOfType<StartGame>().Awake();

        start.transform.localPosition = new Vector3(6.33f, 1.49f, -6.158f);

        GameObject[] copies = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject copy in copies)
        {
            copy.SetActive(false);
        }

        score.SetActive(false);
        keyboard.SetActive(false);
        arrowcount.SetActive(false);
        scoreexplain.SetActive(false);
        finalscore.SetActive(false);
        savescore.SetActive(false);
        playername.SetActive(false);
        timer.SetActive(false);

        FindObjectOfType<ScoreCounter>().ScoreReset();
        FindObjectOfType<TimerScript>().ResetTimer();

    }
}