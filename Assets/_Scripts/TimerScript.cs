using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;


public class TimerScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshPro TimeDisplay;

    [SerializeField]
    private GameObject scorequestion;

    private int TimerCount = 15;
    private int start = 0;

    public IEnumerator Reset() {
        yield return new WaitForSeconds(1);
        TimerCount --;
        TimeDisplay.text = "Timer: " + TimerCount.ToString();

        if(TimerCount == 0 )
        {
            FindObjectOfType<ScoreCounter>().FinalScore();
            scorequestion.SetActive(true);
        }
        else
        {
        StartCoroutine("Reset");
        }
    } 

    // Start is called before the first frame update
    public void StartTimer()
    {
        TimeDisplay.text = "Timer: " + TimerCount.ToString();
        start ++;
        
        if(start == 1){
        StartCoroutine("Reset");
        }
    }
    public void ResetTimer()
    {
        TimerCount = 15;  
    }
}
