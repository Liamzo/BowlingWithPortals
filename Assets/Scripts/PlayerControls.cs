using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
    public float mouseSensitivity = 2f;

    public float moveSpeed = 7f;
    public float jumpSpeed = 5f;
    public float verticalVelocity = 0f;
    CharacterController cc;
    Camera cam;

    float rotUpDown = 0f;
    public float upDownRange = 70f;

    // For ball
    private Transform heldBall;
    bool throwing = false;

    //For portals
    private Transform portalGun;


    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cc = GetComponent<CharacterController>();
        cam = Camera.main;

        // For ball
        heldBall = cam.transform.FindChild("Ball");

        // For portals
        portalGun = cam.transform.FindChild("PortalGun");
    }
	
	// Update is called once per frame
	void Update () {

        // Rotation
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        rotUpDown -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotUpDown = Mathf.Clamp(rotUpDown, -upDownRange, upDownRange);
        cam.transform.localRotation = Quaternion.Euler(rotUpDown, 0, 0);

        // Movement

        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * moveSpeed;

        if (cc.isGrounded) {
            verticalVelocity = 0f;
        } else {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
        if (Input.GetButton("Jump") && cc.isGrounded == true) {
            verticalVelocity = jumpSpeed;
        }

        Vector3 movement = transform.rotation * new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        cc.Move(movement * Time.deltaTime);

        // For ball
        if (heldBall != null) {
            if (Input.GetKeyDown(KeyCode.E)) {
                throwing = true;
            }
        }

        // For portals
        if (portalGun != null) {
            if (Input.GetMouseButtonDown(0)) {
                portalGun.GetComponent<PortalGun>().shootPortal(0);
            }
            if (Input.GetMouseButtonDown(1)) {
                portalGun.GetComponent<PortalGun>().shootPortal(1);
            }
        }

        // Throw ball
        if (throwing && heldBall != null) {
            throwing = false;

            Rigidbody ballRB = heldBall.GetComponent<Rigidbody>();

            heldBall.transform.parent = null;
            ballRB.isKinematic = false;
            ballRB.AddForce((cam.transform.forward * 1000) - cam.transform.position);
            heldBall = null;
        }
    }

    void OnTriggerEnter (Collider col) {       
        if (col.transform.tag == "Ball") {
            Rigidbody ballRB = col.attachedRigidbody;

            if (heldBall == null && col.transform.parent == null && ballRB.velocity.magnitude < 5f) {
                heldBall = col.transform;
                heldBall.parent = cam.transform;
                ballRB.isKinematic = true;
                heldBall.transform.localPosition = new Vector3(0.4f, -0.7f, 1);
            }
        } else if (col.transform.tag == "PortalGun") {
            if (portalGun == null && col.transform.parent == null) {
                portalGun = col.transform;
                portalGun.parent = cam.transform;
                portalGun.transform.localPosition = new Vector3(-0.4f, -0.4f, 1);
                portalGun.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
}
