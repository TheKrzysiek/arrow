using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
//using UnityEditor.ShortcutManagement;
using UnityEngine;

public class StartGame : MonoBehaviour, IHittable
{
    [SerializeField]
    private GameObject start;

    [SerializeField]
    private GameObject usebow;

    [SerializeField]
    private GameObject hitarrow;

    [SerializeField]
    private GameObject difficulty;

    private Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;  
    }

    public void GetHit()
    {     
        difficulty.SetActive(true); 
        difficulty.transform.localPosition = new Vector3(6.6f, 2.07f, -6.158f);

        usebow.SetActive(false);
        hitarrow.SetActive(false);

        StartCoroutine("Disabler");        
    }

    public IEnumerator Disabler()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        yield return new WaitForSeconds(2);
        rb.isKinematic = true;
        yield return new WaitForSeconds(1);
        start.SetActive(false);        
    }

}
