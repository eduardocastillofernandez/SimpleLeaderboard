using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Contains the information and logic of a banner in a leaderboard
/// </summary>
public class LeaderboardBanner : MonoBehaviour
{
    #region Variables
    public Text playerNameText;
    public Text scoreText;
    #endregion

    /// <summary>
    /// Changes the information displayed in the banner based on the given player information
    /// </summary>
    /// <param name="player"></param>
    public void UpdateBanner(PlayerLeaderboardData player)
    {
        playerNameText.text = player.Name;
        scoreText.text = player.Score.ToString();
    }

    public void Reset()
    {
        playerNameText.text = "";
        scoreText.text = "";
    }
    
}
