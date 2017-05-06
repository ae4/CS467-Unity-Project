using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour {

	public Light flashlight;
	public bool activateFlashlight;

	// Use this for initialization
	void Start () {
		flashlight = GetComponent<Light> ();
	}

    // Update is called once per frame
    void Update()
    {
        flashlight.enabled = activateFlashlight;
        if (Input.GetKeyDown(KeyCode.F))
        {
            activateFlashlight = !activateFlashlight;
        }
    }
}
