using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour, IHittable
{
    private Rigidbody rb;
    private bool stopped = false;

    private Vector3 nextposition;
    private Vector3 originPosition;

    [SerializeField]
    public TextMeshPro ScoreDisplay;
        [SerializeField]
    public TextMeshPro FinalScoreDisplay;

    private int ScoreCount = 0;

    //[SerializeField]
    //private int health = 1;

    [SerializeField]
    private AudioSource audioSource;

    //[SerializeField]
    //private float arriveThreshold, movementRadius = 2, speed = 1, x = 0, z = 0, y = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originPosition = transform.position;
        //nextposition = GetNewMovementPosition();
    }

   /* private Vector3 GetNewMovementPosition()
    {
        return originPosition + (Vector3)Random.insideUnitCircle * movementRadius;
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if ((rb.isKinematic || collision.gameObject.CompareTag("Arrow")) == false)
        {
            audioSource.Play();
        }
    }

    public void GetHit()
    {
        FindObjectOfType<TimerScript>().StartTimer();

        ScoreCount += 1 ;
        ScoreDisplay.text = ScoreCount.ToString();

        transform.position = new Vector3(Random.Range(6f,7f), Random.Range(0.7f,2f), Random.Range(-8f,-4f));

        /*health--;
        if(health <= 0)
        {
            rb.isKinematic = false;
            stopped = true;
        }*/
    }

    public void FinalScore()
    {
        FinalScoreDisplay.text = "Final score: " + ScoreCount.ToString();
    }

    /*private void FixedUpdate()
    {
        if (stopped == false)
        {
            if(Vector3.Distance(transform.position,nextposition) < arriveThreshold)
            {
                nextposition = GetNewMovementPosition();
            }

            Vector3 direction = nextposition - transform.position;
            rb.MovePosition(transform.position + direction.normalized * Time.fixedDeltaTime * speed);
        }
    }*/
}

public interface IHittable
{
    void GetHit();
}