using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public GameObject bomb;

    private Rigidbody2D rb;
    private float baseMoveSpeed = 5;
    private int bombLimit = 1;
    private bool hasKick = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();

        if (Input.GetKeyDown(KeyCode.H))
            PlaceBomb();
	}

    void Move()
    {
        var xDirection = Input.GetAxisRaw("Horizontal") * baseMoveSpeed;
        var yDirection = Input.GetAxisRaw("Vertical") * baseMoveSpeed;

        rb.velocity = new Vector2(xDirection, yDirection);
    }

    void PlaceBomb()
    {
        if (bombLimit > 0)
            Instantiate(bomb, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
    }
}
