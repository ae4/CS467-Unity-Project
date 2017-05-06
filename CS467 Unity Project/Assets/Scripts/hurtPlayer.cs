using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtPlayer : MonoBehaviour {

    public playerHealth healthScript;
    private AudioSource source;

    void OnTriggerEnter(Collider col)
    {
        source = GetComponent<AudioSource>();
        if (col.gameObject.tag == "Player")
         {
            source.Play();
            healthScript.decreaseHealth(50f);
         }
    }

    void OnTriggerStay(Collider col)
    {
        //source = GetComponent<AudioSource>();
        if (col.gameObject.tag == "Player")
        {
            //source.Play();
            healthScript.decreaseHealth(2f);
        }
    }


}
