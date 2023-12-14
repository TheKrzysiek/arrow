using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWind : MonoBehaviour
{
    [SerializeField]
    private ConstantForce ArrowForce;
    [SerializeField]
    private ConstantForce WindSphere;
    [SerializeField]
    private ConstantForce WindHinge;

    private float windx = 0f;
    private float windy = 0f;
    private float windz = 0f;
    [SerializeField]
    private int difficulty = 1;
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
        WindSphere.force = ArrowForce.force;
        WindHinge.force = ArrowForce.force;

        int waitTimer = Random.Range(2,10);
        yield return new WaitForSeconds(waitTimer);
        StartCoroutine("Reset");
    } 

    // Start is called before the first frame update
    void Start()
    {
        switch(difficulty){
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

    // Update is called once per frame
    void Update()
    { 

    }
}
