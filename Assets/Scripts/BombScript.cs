using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BombScript : MonoBehaviour {

    public GameObject explosionPrefab;
    public LayerMask levelMask;
    private bool exploded = false;
    private List<PlayerScript> _players = new List<PlayerScript>();
    private PlayerScript _player;

    // Use this for initialization
    void Start () {
        Invoke("Explode", 3f);

        var objList = FindObjectsOfType(typeof(PlayerScript));
        foreach (var player in objList)
            _players.Add((PlayerScript)player);

        _player = _players.Where(p => p.playerNumber.ToString() == gameObject.tag).FirstOrDefault();
    }

    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        StartCoroutine(CreateExplosions(Vector2.up));
        StartCoroutine(CreateExplosions(Vector2.down));
        StartCoroutine(CreateExplosions(Vector2.left));
        StartCoroutine(CreateExplosions(Vector2.right));

        GetComponent<SpriteRenderer>().enabled = false;
        exploded = true;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 0.3f);

        // adiciona 1 bomba de volta a coleção do player
        if (_player != null)
            _player.bombLimit++;
    }

    IEnumerator CreateExplosions(Vector2 direction)
    {
        for (int i = 1; i < 3; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, i, levelMask);

            if (!hit.collider)
                Instantiate(explosionPrefab, new Vector3(transform.position.x + (i * direction.x), transform.position.y + (i * direction.y)), explosionPrefab.transform.rotation);
            else
                break;

            yield return new WaitForSeconds(.05f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!exploded && other.CompareTag("Explosion"))
        {
            CancelInvoke("Explode");
            Explode();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            GetComponent<Collider2D>().isTrigger = false;
    }
}
