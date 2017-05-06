using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class pickableObject : MonoBehaviour {

	public Transform TransformCamera;
	public LayerMask RayMask;
	private RaycastHit hit;
	private float throwForce = 300;
	private Transform currentTransform;
	private float length;

    public GameObject inventoryPanel;
    public GameObject[] inventoryIcons;

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			if (Physics.Raycast(TransformCamera.position, TransformCamera.forward, out hit, 3f, RayMask)){
                    //handle objects that can be moved
					if (hit.transform.tag == "pickableObject") {
						SetNewTransform(hit.transform);
					}

                    //handle objects that can be added to inventory

                    //look through children for existing icon
                    foreach (Transform child in inventoryPanel.transform)
                    {
                        //if item already in inventory
                        if (child.gameObject.tag == hit.transform.tag)
                        {
                            string c = child.Find("Text").GetComponent<Text>().text;
                            int tcount = System.Int32.Parse(c) + 1;
                            child.Find("Text").GetComponent<Text>().text = "" + tcount;
                            return;
                        }
                    }
                    GameObject i;
                    if (hit.transform.tag == "accessCard")
                    {
                        i = Instantiate(inventoryIcons[0]);
                        i.transform.SetParent(inventoryPanel.transform);
                        Destroy(hit.transform.gameObject);
                    }
                    else if (hit.transform.tag == "StimPack")
                    {
                        i = Instantiate(inventoryIcons[1]);
                        i.transform.SetParent(inventoryPanel.transform);
                        Destroy(hit.transform.gameObject);
                    }
               
            }
		}
		
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			RemoveTransform();
		}

		if (Input.GetKeyDown(KeyCode.Mouse1)) {
			throwTransform ();
		}

		if (currentTransform) {
			MoveTransformAround();
		}

	}


	public void SetNewTransform(Transform newTransform) {
	
		if (currentTransform)
			return;

		currentTransform = newTransform;

		length = Vector3.Distance (TransformCamera.position, newTransform.position);

		currentTransform.GetComponent<Rigidbody> ().isKinematic = true;
	}
	
	private void MoveTransformAround() {
		currentTransform.position = TransformCamera.position + TransformCamera.forward * length;
	}

	private void throwTransform() {
		if (!currentTransform)
			return;
		currentTransform.GetComponent<Rigidbody> ().isKinematic = false;
		currentTransform.GetComponent<Rigidbody> ().AddForce (TransformCamera.forward * throwForce);
		currentTransform = null;
	}

	public void RemoveTransform() {
		if (!currentTransform)
			return;	
		currentTransform.GetComponent<Rigidbody> ().isKinematic = false;
		currentTransform = null;
	}

}