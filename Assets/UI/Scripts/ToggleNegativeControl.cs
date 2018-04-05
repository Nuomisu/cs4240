using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ToggleNegativeControl : MonoBehaviour {

	public Text text;
	public bool isNegative = false;
	public NumberKeyboardButton[] numbers;

	void Update () {
		UpdateDisplay ();
	}

	public void ToggleNegative() {
		
		NumberSelectController nsc = transform.parent.GetComponentInParent<NumberSelectController> ();
		if (nsc.numberIsSelected) {
			nsc.selectedValue *= -1;
		}
		isNegative = !isNegative;
		foreach (NumberKeyboardButton ndc in numbers) {
			ndc.SetNumber (ndc.number * -1);
		}
		UpdateDisplay ();
	}

	public void SetNegative(bool state) {
		isNegative = state;
		UpdateDisplay ();
	}

	public int GetValue() {
		return isNegative ? -1 : 1;
	}

	private void UpdateDisplay() {
		text.text = isNegative ? "-" : "+";
	}
}
