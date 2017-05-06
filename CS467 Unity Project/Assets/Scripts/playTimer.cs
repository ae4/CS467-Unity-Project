using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playTimer : MonoBehaviour {

    // Use this for initialization
    public Text timerText;
    private float startTime;
    private float currTime;
	void Start () {
        //this.transform.Find("Time").GetComponent<Text>().text = "10.00";
        timerText.text = "10:00";
        //currTime = Time.time;
        startTime = 600;
    }
	
	// Update is called once per frame
	void Update () {
        //currTime = Time.time;
        currTime = Time.timeSinceLevelLoad;
        //if (System.Int32.Parse(this.transform.Find("Time").GetComponent<Text>().text) > 0)
        //{
        //    int tcount = System.Int32.Parse(this.transform.Find("Time").GetComponent<Text>().text) - 1;
        //    this.transform.Find("Time").GetComponent<Text>().text = "" + tcount;
        //}
        string mins = ((int)(startTime - currTime) / 60).ToString();
        string secs = ((int)(startTime - currTime) % 60).ToString();
        timerText.text = mins + ":" + secs;
    }
}
