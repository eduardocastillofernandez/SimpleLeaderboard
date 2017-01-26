using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used just for quick testing
/// </summary>
public class SceneController : MonoBehaviour
{
    public Leaderboard leaderboard;
    Dictionary<string, int> data;

    // Use this for initialization
    void Start()
    {
        data = new Dictionary<string, int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            data = new Dictionary<string, int>();
            data.Add("A", 100);
            data.Add("B", 10);
            data.Add("C", 100);
            data.Add("D", 200);
            data.Add("E", 100);
            data.Add("F", 100);
            data.Add("G", 1080);
            data.Add("H", 10000);
            leaderboard.Initialize(data);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            leaderboard.UpdatePlayerScore("B", 20000);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            leaderboard.RemovePlayer("E");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            leaderboard.AddPlayer("Z",666);
        }
    }
}
