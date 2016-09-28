using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timer = 0f;
    bool isTiming = false;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (isTiming) {
            timer += Time.deltaTime;
            GetComponent<Text>().text = string.Format("{0:#0.00}", timer);
        }
    }

    public void startTimer () {
        isTiming = true;
    }
    
    public void stopTimer () {
        isTiming = false;
    }

    public void resetTimer () {
        stopTimer();
        timer = 0f;
    }
}
