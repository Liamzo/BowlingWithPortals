using UnityEngine;
using System.Collections;

public class PortalGun : MonoBehaviour {

    public GameObject leftPortal;
    public GameObject rightPortal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void shootPortal (int i) {
        GameObject portal;

        // Get which portal to fire
        if (i == 0) {
            portal = leftPortal;
        } else {
            portal = rightPortal;
        }

        // Raycast to see what was hit
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
         if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.GetComponent<Portalable>() != null) {
                portal.transform.position = hit.point;
                portal.transform.rotation = Quaternion.LookRotation(hit.normal);
            }
        }
    }
}
