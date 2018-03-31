using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public Transform target;

	void Update()
	{
		// Rotate the camera every frame so it keeps looking at the target
		transform.LookAt(target);
	}
}
