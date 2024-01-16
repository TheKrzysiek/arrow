using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour, IHittable
{
public int score = 0;
public string playername = "";

public void AssignScore(int scorescore)
{
    score = scorescore;
}

public void AssignName(string namename)
{
    playername = playername + namename;
}
public void GetHit()
{   
    PlayerData playerData = new PlayerData();

    playerData.score = score;
    playerData.name = playername;

    SaveSystem.SavePlayer(playerData);
        
    FindObjectOfType<Reset>().GetHit();
}
}
