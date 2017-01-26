using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public LeaderboardBanner[] banners;

    public List<PlayerLeaderboardData> Data { get; private set; }

    public void AddPlayer(string playerName, int score)
    {
        if (!UpdatePlayerScore(playerName, score))
        {
            Data.Add(new PlayerLeaderboardData(playerName, score));
            Data.Sort();

            if (Data.Count > banners.Length)//reducing the data so it does not passes the number of places in the leaderboard
            {
                Data.Remove(Data[Data.Count-1]);
            }
           
            UpdateBanners();
        }
    }

    /// <summary>
    /// Populates the leaderboard Based on the given dictionary
    /// </summary>
    /// <param name="data">Dictionary that contains the information of the players</param>
    public void Initialize(Dictionary<string,int> data)
    {
        Data = new List<PlayerLeaderboardData>();
        foreach (KeyValuePair<string,int> item in data)
        {
            Data.Add(new PlayerLeaderboardData(item.Key,item.Value));
        }
        Data.Sort();

        UpdateBanners();
    }

    /// <summary>
    /// Eliminates the information of a given player from the leaderboard
    /// </summary>
    /// <param name="playerName">Name of the player to eliminate from the leaderboard</param>
    public void RemovePlayer(string playerName)
    {
        for (int i = 0; i < Data.Count; i++)
        {
            if (Data[i].Name.Equals(playerName))
            {
                Data.Remove(Data[i]);
                Data.Sort();
                UpdateBanners();
                break;
            }
        }
    }

    /// <summary>
    /// Changes the score of the given player and updates the leaderboard based on the new information
    /// </summary>
    /// <param name="playerName">Name of the player whose information will be updated</param>
    /// <param name="score">New score of the given player</param>
    public bool UpdatePlayerScore(string playerName, int score)
    {
        bool isValidPlayer = false;
        for (int i = 0; i < Data.Count; i++)
        {
            if (Data[i].Name.Equals(playerName))
            {
                Data[i].Score = score;
                isValidPlayer = true;
            }
        }

        if (isValidPlayer)
        {
            Data.Sort();
            UpdateBanners();
        }
        return isValidPlayer;
    }

    /// <summary>
    /// Cleans the information in the banners and add the new information of the players
    /// </summary>
    void UpdateBanners()
    {
        for (int i = 0; i < banners.Length; i++) //Clean the information in the banners to avoid mistakes
        {
            banners[i].Reset();
        }

        for (int i = 0; i < Data.Count; i++)//shows all the information given in the banners
        {
            banners[i].UpdateBanner(Data[i]);
        }
    }
}
