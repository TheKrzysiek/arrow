using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
//using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class S : MonoBehaviour, IHittable
{
    [SerializeField]
    private TextMeshPro playername;

    public void GetHit()
    {        
        playername.text = playername.text + "S";
        FindObjectOfType<SaveScore>().AssignName("S");
    }
}
