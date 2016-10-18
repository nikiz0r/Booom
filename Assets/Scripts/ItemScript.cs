using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<PlayerScript>();

            if (player)
            {
                switch (gameObject.name.Substring(0, gameObject.name.IndexOf('(')))
                {
                    case "BombUp":
                        player.bombLimit += 1;
                        break;
                    case "FireUp":
                        player.firePower += 1;
                        break;
                    case "SpeedUp":
                        player.baseMoveSpeed += 1;
                        break;
                    default:
                        break;
                }
            }

            Destroy(gameObject);
        }
    }
}
