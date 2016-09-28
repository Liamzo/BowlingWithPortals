using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public GameObject leftDoor;
    public GameObject rightDoor;
    public float moveAmount;
    public float timeToOpen;
    public bool isOpen = false;

    Vector3 leftStart;
    Vector3 leftEnd;

    Vector3 rightStart;
    Vector3 rightEnd;

    float journeyLength;
    float startTime;

	// Use this for initialization
	void Start () {
        leftStart = leftDoor.transform.localPosition;
        leftEnd = leftDoor.transform.localPosition;

        rightStart = rightDoor.transform.localPosition;
        rightEnd = rightDoor.transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        float distCovered = (Time.time - startTime) * timeToOpen;
        float fracJourney = distCovered / journeyLength;
        leftDoor.transform.localPosition = Vector3.Lerp(leftStart, leftEnd, fracJourney);
        rightDoor.transform.localPosition = Vector3.Lerp(rightStart, rightEnd, fracJourney);

    }

    public void activate() {
        isOpen = !isOpen;

        if (isOpen) {
            leftStart = leftDoor.transform.localPosition;
            leftEnd = leftDoor.transform.localPosition + (leftDoor.transform.forward * moveAmount);

            rightStart = rightDoor.transform.localPosition;
            rightEnd = rightDoor.transform.localPosition - (rightDoor.transform.forward * moveAmount);

            journeyLength = Vector3.Distance(leftStart, leftEnd);
            startTime = Time.time;
        } else {
            leftStart = leftDoor.transform.localPosition;
            leftEnd = leftDoor.transform.localPosition - (leftDoor.transform.forward * moveAmount);

            rightStart = rightDoor.transform.localPosition;
            rightEnd = rightDoor.transform.localPosition + (rightDoor.transform.forward * moveAmount);

            journeyLength = Vector3.Distance(leftStart, leftEnd);
            startTime = Time.time;
        }
    }
}
