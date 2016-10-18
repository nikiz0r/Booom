using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameScript : MonoBehaviour
{

    public GameObject softBlockPrefab;
    private int deadPlayers = 0, deadPlayerNumber = -1;

    // Use this for initialization
    void Start()
    {
        MapSetup();
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

    void MapSetup()
    {
        #region listSoftBlockPosition
        List<Vector2> listSoftBlockPosition = new List<Vector2>();
        listSoftBlockPosition.Add(new Vector2(-4, 1.01f));
        listSoftBlockPosition.Add(new Vector2(-4, 0.01f));
        listSoftBlockPosition.Add(new Vector2(-4, -1.01f));
        listSoftBlockPosition.Add(new Vector2(-3, 1.01f));
        listSoftBlockPosition.Add(new Vector2(-3, -1.01f));
        listSoftBlockPosition.Add(new Vector2(-2, 3.01f));
        listSoftBlockPosition.Add(new Vector2(-2, 2.01f));
        listSoftBlockPosition.Add(new Vector2(-2, 1.01f));
        listSoftBlockPosition.Add(new Vector2(-2, 0.01f));
        listSoftBlockPosition.Add(new Vector2(-2, -1.01f));
        listSoftBlockPosition.Add(new Vector2(-2, -2.01f));
        listSoftBlockPosition.Add(new Vector2(-2, -3.01f));
        listSoftBlockPosition.Add(new Vector2(-1, 3.01f));
        listSoftBlockPosition.Add(new Vector2(-1, 1.01f));
        listSoftBlockPosition.Add(new Vector2(-1, -1.01f));
        listSoftBlockPosition.Add(new Vector2(-1, -3.01f));
        listSoftBlockPosition.Add(new Vector2(0, 3.01f));
        listSoftBlockPosition.Add(new Vector2(0, 2.01f));
        listSoftBlockPosition.Add(new Vector2(0, 1.01f));
        listSoftBlockPosition.Add(new Vector2(0, 0.01f));
        listSoftBlockPosition.Add(new Vector2(0, -1.01f));
        listSoftBlockPosition.Add(new Vector2(0, -2.01f));
        listSoftBlockPosition.Add(new Vector2(0, -3.01f));
        listSoftBlockPosition.Add(new Vector2(1, 3.01f));
        listSoftBlockPosition.Add(new Vector2(1, 1.01f));
        listSoftBlockPosition.Add(new Vector2(1, -1.01f));
        listSoftBlockPosition.Add(new Vector2(1, -3.01f));
        listSoftBlockPosition.Add(new Vector2(2, 3.01f));
        listSoftBlockPosition.Add(new Vector2(2, 2.01f));
        listSoftBlockPosition.Add(new Vector2(2, 1.01f));
        listSoftBlockPosition.Add(new Vector2(2, 0.01f));
        listSoftBlockPosition.Add(new Vector2(2, -1.01f));
        listSoftBlockPosition.Add(new Vector2(2, -2.01f));
        listSoftBlockPosition.Add(new Vector2(2, -3.01f));
        listSoftBlockPosition.Add(new Vector2(3, 1.01f));
        listSoftBlockPosition.Add(new Vector2(3, -1.01f));
        listSoftBlockPosition.Add(new Vector2(4, 1.01f));
        listSoftBlockPosition.Add(new Vector2(4, 0.01f));
        listSoftBlockPosition.Add(new Vector2(4, -1.01f));
        listSoftBlockPosition.Add(new Vector2(-4, -2.01f));
        listSoftBlockPosition.Add(new Vector2(-4, -3.01f));
        listSoftBlockPosition.Add(new Vector2(-3, -3.01f));
        listSoftBlockPosition.Add(new Vector2(3, 3.01f));
        listSoftBlockPosition.Add(new Vector2(4, 3.01f));
        listSoftBlockPosition.Add(new Vector2(4, 2.01f));
        #endregion

        foreach (var transf in listSoftBlockPosition)
        {
            var prob = Random.Range(0, 10);

            if (prob <= 7)
                Instantiate(softBlockPrefab, transf, Quaternion.identity);
        }
    }
}
