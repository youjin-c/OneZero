using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	public GameObject something;
	public Vector3 targetPosition;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
		something.transform.position = Vector3.SmoothDamp(something.transform.position, targetPosition, ref velocity, smoothTime);
    }
}
