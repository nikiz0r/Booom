using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{

    private int deadPlayers = 0, deadPlayerNumber = -1;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDied(int playerNumber)
    {
        deadPlayers++;

        if (deadPlayers == 1)
        {
            deadPlayerNumber = playerNumber;
            Invoke("CheckPlayersDeath", .3f);
        }
    }

    void CheckPlayersDeath()
    {
        if (deadPlayers == 1)
        {
            Debug.Log(string.Format("Player {0} is the winner!", deadPlayerNumber == 1 ? 2 : 1));
        }
        else
            Debug.Log("The game ended in a draw!");
    }
}
