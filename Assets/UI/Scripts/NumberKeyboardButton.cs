using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class NumberKeyboardButton : MonoBehaviour {

	public Text text;
	public int number;
	public Image image;

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

	public void SetPressed(bool isPressed) {
		if (isPressed) {
			image.color = Color.yellow;
		} else {
			image.color = Color.white;
		}
	}

	public void SetSelected() {
		NumberSelectController nsc = transform.parent.gameObject.GetComponentInParent<NumberSelectController> ();

		if (!nsc.numberIsSelected) {
			SetPressed (true);
			nsc.SetNumberSelected (this);
		
		} else {

			if (nsc.selectedNumberDisplayable == this) {
				nsc.DeselectNumber ();
			} else {
				nsc.DeselectNumber ();
				nsc.SetNumberSelected (this);
			}

		}


	}


}
