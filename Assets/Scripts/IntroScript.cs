using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {

    public GameObject gbLogo, controls;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Destroy(gbLogo, 3f);
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter)) && !gbLogo)
            SceneManager.LoadScene("GameScene");
	}
}
