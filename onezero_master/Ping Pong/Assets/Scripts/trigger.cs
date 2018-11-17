using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {
	public bool hit = false;	
	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Object Entered the trigger");
		hit = true; 
	}
	//public void OnTriggerStay(Collider other)
	//{
	//	Debug.Log("Object is within trigger");
	//	hit = true; 
	//}

	private void OnTriggerExit(Collider other)
	{
		//Debug.Log("Object Exited the trigger");
		hit = false;
	}
}
