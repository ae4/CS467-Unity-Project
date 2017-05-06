using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class useItem : MonoBehaviour {

    public void useThis()
    {
        if (this.gameObject.tag == "StimPack")
        {
            var healthScript = GameObject.FindObjectOfType(typeof(playerHealth)) as playerHealth;
            healthScript.increaseHealth(20f);
        }
        if (System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) > 1)
        {
            int tcount = System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text) - 1;
            this.transform.Find("Text").GetComponent<Text>().text = "" + tcount;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
