using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class VectorNumberDisplayable : MonoBehaviour {

	public Text text;
	public int number;
	public NumberSelectController nsc;
	public bool allowModify = true;

	void Start () {
	}

	void Update() {
		UpdateDisplayedNumber (); // Can probably remove this before deploying
	}

	void UpdateDisplayedNumber() {
		text.text = number.ToString ();
		if (number < 0) {
			text.rectTransform.localPosition = new Vector2 (-8f, -6f);
		} else {
			text.rectTransform.localPosition = new Vector2 (0f, -6f);
		}
	}

	public void SetNumber(int num) {
		number = num;
		UpdateDisplayedNumber ();
	}

	public void SetNumberToSelected() {
		if (nsc.numberIsSelected && allowModify) {
			SetNumber ((int) nsc.selectedValue);
		}
	}
}
