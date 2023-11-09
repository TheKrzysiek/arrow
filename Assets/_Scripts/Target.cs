using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Target : MonoBehaviour, IHittable
{
    private Rigidbody rb;
    private bool stopped = false;

    private Vector3 nextposition;
    private Vector3 originPosition;

    [SerializeField]
    GameObject xr;

    //[SerializeField]
  //  private int health = 1;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float arriveThreshold, movementRadius = 2, speed = 1, x = 0, z = 0, y = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originPosition = transform.position;
        nextposition = GetNewMovementPosition();
    }

    private Vector3 GetNewMovementPosition()
    {
        return originPosition + (Vector3)Random.insideUnitCircle * movementRadius;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((rb.isKinematic || collision.gameObject.CompareTag("Arrow")) == false)
        {
            audioSource.Play();
        }
    }

    public void GetHit()
    {
        xr.transform.position = new Vector3(x, y, z);
        /*health--;
        if(health <= 0)
        {
            rb.isKinematic = false;
            stopped = true;
        }*/
    }

    private void FixedUpdate()
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
    }
}

public interface IHittable
{
    void GetHit();
}