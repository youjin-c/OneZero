using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetaBall : MonoBehaviour {
    
	public GameObject later0;
	public GameObject later1;
	public int reset;
    arduinoBluetooth mainScript;
	private void Start()
	{
        GameObject main = GameObject.Find("ArduinoBluetooth");
        mainScript = main.GetComponent<arduinoBluetooth>();
	}

	private void Update()
    {
        //print(mainScript.receive);
		GameObject[] ball = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] racket = GameObject.FindGameObjectsWithTag("Racket");
        if (Input.GetKeyDown(KeyCode.Space)||mainScript.receive==1)
        {
			reset = 1;
			
			Instantiate(later0);
			Instantiate(later1);
			for (int i = 0; i < ball.Length;i++){
				Destroy(ball[0]);
			}
			for (int i = 0; i < racket.Length;i++){
				Destroy(racket[0]);
			}
        }
		if (Input.GetKeyUp(KeyCode.Space))
        {
            reset = 0;
        }
    }
}
