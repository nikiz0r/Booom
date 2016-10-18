using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    [Range(1, 2)]
    public int playerNumber = 1;
    public GameObject bomb;
    public bool dead = false;
    public int bombLimit = 1;

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
