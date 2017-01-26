using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Describes what information of a player is shown in the leaderboard
/// </summary>
public class PlayerLeaderboardData : IComparable<PlayerLeaderboardData>
{
    public int Score { get; set; }

    public string Name { get; set; }

    public PlayerLeaderboardData(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public int CompareTo(PlayerLeaderboardData other)
    {
        return Score.CompareTo(other.Score) * -1;
    }
}
