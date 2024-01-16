using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target2 : MonoBehaviour, IHittable{
    [SerializeField]
   private Rigidbody rb;
    //private bool stopped = false;

    private Vector3 nextposition;
    private Vector3 originPosition;

    [SerializeField]
    private GameObject TargetOriginal;

    [SerializeField]
    private GameObject HitTargetToStart;

    [SerializeField]
    private AudioSource audioSource;

    /*float x1;
    float x2;
    float y1;
    float y2;
    float z1;
    float z2;*/

    //[SerializeField]
    //private float arriveThreshold, movementRadius = 2, speed = 1, x = 0, z = 0, y = 0;

    private void Awake()
    {
        
        originPosition = transform.position;
        //nextposition = GetNewMovementPosition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((rb.isKinematic || collision.gameObject.CompareTag("Arrow")) == false)
        {
            audioSource.Play();
        }
    }

    /*public void ChangeDifficulty(int difficulty)
    {
        switch(difficulty)
        {
            case 1:
                x1 = 6f;
                x2 = 8f;
                y1 = 1f;
                y2 = 2f;
                z1 = -6f;
                z2 = -2f;
                break;
            case 2:
                x1 = 7f;
                x2 = 11f;
                y1 = 0.5f;
                y2 = 3f;
                z1 = -8f;
                z2 = 0f;
                break;
            case 3:
                x1 = 9f;
                x2 = 15f;
                y1 = 0f;
                y2 = 4f;
                z1 = -10f;
                z2 = 2f;
                break;
        }
    }*/

    public void GetHit()
    {
        FindObjectOfType<TimerScript>().StartTimer();
        FindObjectOfType<ScoreCounter>().AddScore(2);

        HitTargetToStart.SetActive(false);

    
        GameObject TargetCopy = Instantiate(TargetOriginal, new Vector3(Random.Range(10f,20f), Random.Range(0f,3f), Random.Range(-7f,-3f)), TargetOriginal.transform.rotation);
        
        StartCoroutine("Disabler");       
    }
        public IEnumerator Disabler()
    {
        rb.isKinematic = false;
        yield return new WaitForSeconds(2);
        TargetOriginal.SetActive(false);
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

