using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
//using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Medium : MonoBehaviour, IHittable
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private GameObject start;

    [SerializeField]
    private GameObject difficulty;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject HitTargetToStart;

    [SerializeField]
    private GameObject score;

    [SerializeField]
    private GameObject timer;

    [SerializeField]
    private GameObject hingethingy;
    public int difficultyOption;

    public void Awake()
    {
        rb.isKinematic = true;  
    }

    public void GetHit()
    {        
        difficultyOption = 2;

        FindObjectOfType<ArrowWind>().DifficultyChange(difficultyOption);

        start.SetActive(false);

        target.SetActive(true);
        FindObjectOfType<Target>().Awake();
        rb.isKinematic = true;
        target.transform.localPosition = new Vector3(18.97f, 2.05f, -6.04f);

        HitTargetToStart.SetActive(true);
        score.SetActive(true);
        timer.SetActive(true);
        hingethingy.SetActive(true);

        StartCoroutine("Disabler");
    }
        public IEnumerator Disabler()
    {
        rb.isKinematic = false;
        yield return new WaitForSeconds(2);
        rb.isKinematic = true;
        yield return new WaitForSeconds(1);
        difficulty.SetActive(false);      
    }
}
