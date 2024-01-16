using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
//using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScoreStart : MonoBehaviour, IHittable
{
    private Rigidbody rb;

    [SerializeField]
    private GameObject timer;

    [SerializeField]
    private GameObject playername;

    [SerializeField]
    private GameObject score;

    [SerializeField]
    private GameObject finalscore;

    [SerializeField]
    private GameObject scoretextthingy;

    [SerializeField]
    private GameObject arrowcount;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject keyboard;

    [SerializeField]
    private GameObject savescore;

    public void GetHit()
    {        
        timer.SetActive(false);
        score.SetActive(false);
        finalscore.SetActive(false);
        arrowcount.SetActive(false);
        target.SetActive(false); 
        scoretextthingy.SetActive(false);       

        keyboard.SetActive(true);
        playername.SetActive(true);

        FindObjectOfType<ScoreCounter>().SendScore();

        StartCoroutine("Disabler");
    }
    public IEnumerator Disabler()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        yield return new WaitForSeconds(2);
        savescore.SetActive(false);
    }
}