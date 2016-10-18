using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    private GameScript _game;

	// Use this for initialization
	void Start () {
        _game = (GameScript)FindObjectOfType(typeof(GameScript));

        Destroy(gameObject, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SoftBlock"))
        {
            var prob = Random.Range(0, 10);
            if (prob <= 8)
                CreateItem();

            Destroy(other.gameObject);
        }
    }

    void CreateItem()
    {
        GameObject selectedGO = _game.itemList[Random.Range(0, _game.itemList.Count)];
        Instantiate(selectedGO, transform.position, selectedGO.transform.rotation);
    }
}
