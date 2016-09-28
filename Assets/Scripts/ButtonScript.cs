using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public bool isOn = false;
    public Material offMaterial;
    public Material onMaterial;
    public GameObject switchPart;
    public GameObject controlledDoor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider col) {
        if (col.transform.tag == "Ball" && col.transform.parent == null) {
            isOn = !isOn;

            if (isOn) {
                switchPart.GetComponent<Renderer>().material = onMaterial;
            } else {
                switchPart.GetComponent<Renderer>().material = offMaterial;
            }

            controlledDoor.GetComponent<Door>().activate();
        }
    }
}
