using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnmodifiableVector : MonoBehaviour {

	public VectorNumberDisplayable[] coordinates; // x y z in order

	public Vector3 GetVector() {
		return new Vector3 (coordinates[0].number, coordinates[1].number, coordinates[2].number);
	}

	public void SetVector(Vector3 vec) {
		coordinates [0].SetNumber ((int) vec.x);
		coordinates [1].SetNumber ((int) vec.x);
		coordinates [2].SetNumber ((int) vec.x);
	}

}
