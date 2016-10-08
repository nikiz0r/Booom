using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private Rigidbody2D rb;
    private float baseMoveSpeed = 5;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        var xDirection = Input.GetAxisRaw("Horizontal") * baseMoveSpeed;
        var yDirection = Input.GetAxisRaw("Vertical") * baseMoveSpeed;

        rb.velocity = new Vector2(xDirection, yDirection);
    }

    void PlaceBomb()
    {

    }
}
