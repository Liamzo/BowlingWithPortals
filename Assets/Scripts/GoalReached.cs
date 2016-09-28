using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoalReached : MonoBehaviour {

    public GameObject restartButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider col) {
        if (col.transform.tag == "Player") {
            Destroy(col.transform.GetComponent<PlayerControls>());
            GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().stopTimer();

            restartButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }  
    }

    public void restartLevel () {
        SceneManager.LoadScene("Level001");
    }
}
