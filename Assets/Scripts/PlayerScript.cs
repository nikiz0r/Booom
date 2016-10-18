using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    [Range(1, 2)]
    public int playerNumber = 1;
    public GameObject bomb;
    public bool dead = false;
    public int bombLimit = 1;
    public int firePower = 2;

    private Rigidbody2D rb;
    private float baseMoveSpeed = 5;
    private GameScript _gameScript;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        _gameScript = (GameScript)FindObjectOfType(typeof(GameScript));
	}
	
	// Update is called once per frame
	void Update () {
        if (playerNumber == 1)
            MovePlayer1();
        else
            MovePlayer2();
    }

    void MovePlayer1()
    {
        if (Input.GetKey(KeyCode.A))
            rb.velocity = new Vector2(-baseMoveSpeed, rb.velocity.y);
        else if (Input.GetKey(KeyCode.D))
            rb.velocity = new Vector2(baseMoveSpeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);

        if (Input.GetKey(KeyCode.W))
            rb.velocity = new Vector2(rb.velocity.x, baseMoveSpeed);
        else if (Input.GetKey(KeyCode.S))
            rb.velocity = new Vector2(rb.velocity.x, -baseMoveSpeed);
        else
            rb.velocity = new Vector2(rb.velocity.x, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            PlaceBomb();
    }

    void MovePlayer2()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.velocity = new Vector2(-baseMoveSpeed, rb.velocity.y);
        else if (Input.GetKey(KeyCode.RightArrow))
            rb.velocity = new Vector2(baseMoveSpeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);

        if (Input.GetKey(KeyCode.UpArrow))
            rb.velocity = new Vector2(rb.velocity.x, baseMoveSpeed);
        else if (Input.GetKey(KeyCode.DownArrow))
            rb.velocity = new Vector2(rb.velocity.x, -baseMoveSpeed);
        else
            rb.velocity = new Vector2(rb.velocity.x, 0);

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            PlaceBomb();
    }

    void PlaceBomb()
    {
        if (bombLimit > 0)
        {
            bombLimit--;
            bomb.tag = playerNumber.ToString();
            Instantiate(bomb, new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y - 0.5f), -1), transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Explosion"))
        {
            dead = true;
            _gameScript.PlayerDied(playerNumber);
            Destroy(gameObject);
        }
    }
}
