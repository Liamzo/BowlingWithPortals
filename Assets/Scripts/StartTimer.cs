using UnityEngine;
using System.Collections;

public class StartTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider col) {
        if (col.transform.tag == "Player") {
            GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().startTimer();
        }
    }
}
