using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class NumberSelectController : MonoBehaviour {

	public bool numberIsSelected = false;
	public int? selectedValue;
	public NumberKeyboardButton selectedNumberDisplayable;

	public void SetNumberSelected(NumberKeyboardButton ndc) {
		selectedNumberDisplayable = ndc;
		selectedValue = ndc.number;
		numberIsSelected = true;
		ndc.SetPressed (true);
	}

	public void DeselectNumber() {
		if (numberIsSelected) {
			selectedNumberDisplayable.SetPressed (false);
			numberIsSelected = false;
			selectedValue = null;
			selectedNumberDisplayable = null;
		}
	}

}
