using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SoftBlock"))
        {
            Destroy(other.gameObject);
        }
    }
}
