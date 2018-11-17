using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove : MonoBehaviour {
	//GameObject[] racket = GameObject.FindGameObjectsWithTag("Racket");
	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Racket")
        {
            Destroy(col.gameObject,1);
        }
    }
}
