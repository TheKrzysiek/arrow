using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    public TextMeshPro countUI;

    [SerializeField]
    private GameObject midPointVisual, arrowPrefab, arrowSpawnPoint;

    [SerializeField]
    private float arrowMaxSpeed = 50;

    private int arrowCount = 0;

    [SerializeField]
    private AudioSource bowReleaseAudioSource;

    public void PrepareArrow()
    {
        midPointVisual.SetActive(true);
    }

    public void ReleaseArrow(float strength)
    {
        arrowCount += 1 ;

        bowReleaseAudioSource.Play();
        midPointVisual.SetActive(false);

        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = arrowSpawnPoint.transform.position;
        arrow.transform.rotation = midPointVisual.transform.rotation;
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.AddForce(midPointVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);

    }

    public void ArrowCountDisplay()
    {
        countUI.text = "Arrows shot: " + arrowCount.ToString();
    }
}