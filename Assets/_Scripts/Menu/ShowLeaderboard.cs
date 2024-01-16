using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShowLeaderboard : MonoBehaviour, IHittable
{
[SerializeField]
public TextMeshPro leadearboardtext;

[SerializeField]
public GameObject leadearboard;
public void GetHit()
{   
    leadearboard.SetActive(true);
    List<PlayerData> leaderboardData = SaveSystem.LoadPlayers();

    if (leaderboardData.Count > 0)
    {
     // Sort the list based on scores (you can customize the sorting logic)
        leaderboardData.Sort((a, b) => b.score.CompareTo(a.score));

        // Display the leaderboard using TextMeshPro
        string displayTextString = "Leaderboard:\n";
        for (int i = 0; i < leaderboardData.Count; i++)
        {
            displayTextString += $"{i + 1}. {leaderboardData[i].name}: {leaderboardData[i].score}\n";
        }

        leadearboardtext.text = displayTextString;
        }
    else
    {
        // Handle the case where no leaderboard data is found
        leadearboardtext.text = "Leaderboard is empty.";
    }
}
}   
