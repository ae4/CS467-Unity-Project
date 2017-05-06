using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// THIS SCRIPT HAS BEEN MERGED INTO pickableObject.cs 
/// OBJECTS WILL BE ADDED TO INVENTORY WITH E KEY.
/// </summary>

public class addToInventory : MonoBehaviour {

    public GameObject inventoryPanel;
    public GameObject[] inventoryIcons;

    void OnTriggerEnter(Collider collision)
    {
        //look through children for existing icon
        foreach (Transform child in inventoryPanel.transform)
        {
            //if item already in inventory
            if (child.gameObject.tag == collision.gameObject.tag)
            {
                string c = child.Find("Text").GetComponent<Text>().text;
                int tcount = System.Int32.Parse(c) + 1;
                child.Find("Text").GetComponent<Text>().text = "" + tcount;
                return;
            }
        }


        GameObject i;
        if (collision.gameObject.tag == "StimPack")
        {
            i = Instantiate(inventoryIcons[0]);
            i.transform.SetParent(inventoryPanel.transform);
            Destroy(collision.gameObject);
        }
        //else if (collision.gameObject.tag == "green")
        //{
        //    i = Instantiate(inventoryIcons[1]);
        //    i.transform.SetParent(inventoryPanel.transform);
        //}
        //else if (collision.gameObject.tag == "blue")
        //{
        //    i = Instantiate(inventoryIcons[2]);
        //    i.transform.SetParent(inventoryPanel.transform);
        //}
    }
}
