using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

    public GameObject resetPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider col) {
        if (col.transform.tag == "Player" || (col.transform.tag == "Ball" && col.transform.parent == null)) {
            col.transform.position = resetPoint.transform.position;
            col.transform.rotation = resetPoint.transform.rotation;
        }
    }
}
