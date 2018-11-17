using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetaBall : MonoBehaviour {
    
	public GameObject later0;
	public GameObject later1;
	public int reset;
    
    private void Update()
    {
		GameObject[] ball = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] racket = GameObject.FindGameObjectsWithTag("Racket");
        if (Input.GetKeyDown(KeyCode.Space))
        {
			reset = 1;
			
			Instantiate(later0);
			Instantiate(later1);
			Destroy(ball[0]);
            Destroy(racket[0]);
        }
    }
}
