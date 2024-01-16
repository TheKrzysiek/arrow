using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWind : MonoBehaviour
{
    [SerializeField]
    private ConstantForce ArrowForce;
    [SerializeField]
    private ConstantForce WindHinge;

    private float windx = 0f;
    private float windy = 0f;
    private float windz = 0f;
    [SerializeField]
    private int difficulty = 0;
    private float windForce = 0f;
    private float windRange = 0f;

    IEnumerator Reset() {

        windx = windx + Random.Range(-windRange,windRange);
        windz = windx + Random.Range(-windRange,windRange);

        if(windx > windForce){
            windx = windForce;
        }
        else if(windx < -windForce){
            windx = -windForce;
        }
        if(windz > windForce){
            windz = windForce;
        }
        else if(windz < -windForce){
            windz = -windForce;
        }

        ArrowForce.force = new Vector3(windx, windy, windz);
        WindHinge.force = ArrowForce.force;

        int waitTimer = Random.Range(2,10);
        yield return new WaitForSeconds(waitTimer);
        StartCoroutine("Reset");
    } 

    // Start is called before the first frame update
    void Start()
    {
        switch(difficulty){
            case 0:
                windForce = 0f;
                windRange = 0f;
                windx = Random.Range(-windForce,windForce);
                windz = Random.Range(-windForce,windForce);
                break;
            case 1:
                windForce = 1f;
                windRange = 0.5f;
                windx = Random.Range(-windForce,windForce);
                windz = Random.Range(-windForce,windForce);
                break;
            case 2:
                windForce = 2.5f;
                windRange = 1.5f;
                windx = Random.Range(-windForce,windForce);
                windz = Random.Range(-windForce,windForce);
                break;
            case 3:
                windForce = 5f;
                windRange = 2.5f;
                windx = Random.Range(-windForce,windForce);
                windz = Random.Range(-windForce,windForce);
                break;        
        }
        StartCoroutine("Reset");
    }


    public void DifficultyChange(int diff)
    {
        switch(diff)
        {
            case 1:
                difficulty = 1;
                break;
            case 2:
                difficulty = 2;
                break;
            case 3:
                difficulty = 3;
                break;
        }
    }

}
