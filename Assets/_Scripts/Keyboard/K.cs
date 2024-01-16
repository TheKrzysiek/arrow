using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
//using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class K : MonoBehaviour, IHittable
{
    [SerializeField]
    private TextMeshPro playername;

    public void GetHit()
    {        
        playername.text = playername.text + "K";
        FindObjectOfType<SaveScore>().AssignName("K");
    }
}
