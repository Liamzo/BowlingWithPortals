using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
    public GameObject otherPortal;
    //public GameObject inPortal = null;
    Vector3 telePosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {     
	}

    void OnTriggerEnter (Collider col) {
        if (col.transform.tag == "Player") {
            col.transform.position = otherPortal.transform.position + (otherPortal.transform.forward * 1.2f);
            col.transform.eulerAngles = new Vector3(0, otherPortal.transform.eulerAngles.y, 0);

            if (otherPortal.transform.forward.y != 0) {
                PlayerControls pc = col.transform.GetComponent<PlayerControls>();
                pc.verticalVelocity = Mathf.Abs(pc.verticalVelocity) * otherPortal.transform.forward.y;
            }
        } else if (col.transform.tag == "Ball" && col.transform.parent == null) {
            col.transform.position = otherPortal.transform.position + (otherPortal.transform.forward * 1.2f);
            col.attachedRigidbody.velocity = otherPortal.transform.forward * col.attachedRigidbody.velocity.magnitude;
        }
        
    }
}
