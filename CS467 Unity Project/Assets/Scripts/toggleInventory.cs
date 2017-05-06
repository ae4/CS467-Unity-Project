using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleInventory : MonoBehaviour {

    private Canvas CanvasObject; // Assign in inspector

    void Start()
    {
        CanvasObject = GetComponent<Canvas>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            CanvasObject.enabled = !CanvasObject.enabled;
            Cursor.visible = !Cursor.visible;

            if (!Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
        }

    }
}
