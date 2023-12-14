using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;


public class TimerScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshPro TimeDisplay;

    private int TimerCount = 5;

    public IEnumerator Reset() {
        yield return new WaitForSeconds(1);
        TimerCount --;
        TimeDisplay.text = TimerCount.ToString();

        if(TimerCount == 0 )
        {
            FindObjectOfType<Target>().FinalScore();
            FindObjectOfType<ArrowController>().ArrowCountDisplay();
        }
        else
        {
        StartCoroutine("Reset");
        }
    } 

    // Start is called before the first frame update
    public void StartTimer()
    {
        TimeDisplay.text = TimerCount.ToString();
        StartCoroutine("Reset");
    }
}
