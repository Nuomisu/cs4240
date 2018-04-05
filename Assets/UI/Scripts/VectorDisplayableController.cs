using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VectorDisplayableController : MonoBehaviour {

	public VectorNumberDisplayable[] coordinates; // x y z in order

	public Vector3 GetVector() {
		return new Vector3 (coordinates[0].number, coordinates[1].number, coordinates[2].number);
	}

}
