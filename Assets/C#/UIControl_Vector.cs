﻿using UnityEngine;
using System.Collections;
using Vuforia;
using System;
using UnityEngine.UI;

public class UIControl_Vector : MonoBehaviour, ITrackableEventHandler {
	const int invalid = 9999;

	float native_width= 750f; 
	float native_height= 1334f;

	public Button menuBtn;
	public GameObject vectorPanel;
	public GameObject bottomPanel;
	public GameObject digitsPanel;
	public Transform v1_tar;
	public Transform v2_tar;
	public Transform v3_tar;

	public Transform v1_cube;
	public Transform v2_cube;
	public Transform v3_cube;

	const float ratio = 0.04f;
	private float ratio2 = Screen.width/1080f;

	private TrackableBehaviour mTrackableBehaviour;

	private bool mShowGUIButton = false;
	private bool buttonOpen = false;

	private int v1_x, v1_y, v1_z, v2_x, v2_y, v2_z = invalid;
	private int v3_x, v3_y, v3_z = invalid;

	private float v1_cube_initZ, v2_cube_initZ, v3_cube_initZ;

	void Start () {
		
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}

		v1_x =v1_y=v1_z=v2_x=v2_y=v2_z = invalid;
		v3_x= v3_y = v3_z = invalid;
		v1_cube_initZ = v1_cube.transform.localScale.z;

		Debug.Log ("v1_cube_initZ: " +v1_cube_initZ);
		v2_cube_initZ = v2_cube.transform.localScale.z;
		v3_cube_initZ = v3_cube.transform.localScale.z;
	}

	private void intiPanelVector(){
		
		RectTransform panelRectTransform = vectorPanel.GetComponent<RectTransform> ();
		panelRectTransform.sizeDelta = new Vector2 (Screen.width, Screen.height);

		//RectTransform bottompanelRectTransform = bottomPanel.GetComponent<RectTransform> ();
		//bottompanelRectTransform.sizeDelta = new Vector2 (Screen.width, Screen.height * 0.11f);


	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			mShowGUIButton = true;
		}
		else
		{
			mShowGUIButton = false;
		}
	}

	void OnGUI() {

		//set up scaling
		float rx = Screen.width /  native_width;
		float ry = Screen.height / native_height;

		GUI.matrix = Matrix4x4.TRS (new Vector3(0, 0, 0), Quaternion.identity, new Vector3 (rx, ry, 1));

		GUIStyle normarlTextStyle;
		normarlTextStyle = new GUIStyle(GUI.skin.textField);
		normarlTextStyle.fontSize = 40;
		normarlTextStyle.alignment = TextAnchor.MiddleCenter;
		normarlTextStyle.richText=true;
		normarlTextStyle.normal.textColor = Color.yellow;

		Rect mButtonRect = new Rect(5,native_height - 115,110,110);


		// --------------------------------------------------------------------------------

		//Color c = GUI.backgroundColor;
		//GUI.backgroundColor = Color.green;
		//GUI.Label(new Rect(5, 5, 200, 50), "<b>teachAR</b>",logoTextStyle);
		//GUI.backgroundColor = c;

		if (mShowGUIButton) {
			GUI.Label (new Rect (native_width*0.5f - 250, 80, 500, 70), "<b> Vector Calculator </b>", normarlTextStyle);
			menuBtn.gameObject.SetActive (true);
			bottomPanel.gameObject.SetActive (true);

			if (buttonOpen) {
				//bottomPanel.gameObject.SetActive (false);
				RectTransform rt = bottomPanel.GetComponent<RectTransform>();
				rt.anchoredPosition = new Vector2 (0, -Screen.height);

			} else {
				//bottomPanel.gameObject.SetActive (true);
				RectTransform rt = bottomPanel.GetComponent<RectTransform>();
				//rt.anchoredPosition = new Vector2 (0*ratio2, -855*ratio2);
				rt.anchoredPosition = new Vector2 (0*ratio2, -Screen.height/2 + 250/2*ratio2);

			}

			GameObject[] all = GameObject.FindGameObjectsWithTag ("imageTarget");
			foreach(GameObject each in all){
				if (!each.name.Equals(this.name)) {
					each.SetActive (false);
				}
			}

		} else {

			GUI.Label(new Rect(native_width*0.5f - 250, 80, 500, 70), "<b> Find a card! </b>",normarlTextStyle);
			menuBtn.gameObject.SetActive (false);
			vectorPanel.gameObject.SetActive (false);
			bottomPanel.gameObject.SetActive (false);
			digitsPanel.gameObject.SetActive (false);
			buttonOpen = false;


			GameObject[] all = GameObject.FindGameObjectsWithTag ("imageTarget");
			foreach(GameObject each in all){
				if (!each.name.Equals(this.name)) {
					each.SetActive (true);
				}
			}

		}
			
	}
		

	public void TaskOnClickMenu()
	{
		buttonOpen = !buttonOpen;

		if (buttonOpen) {
			vectorPanel.gameObject.SetActive (true);
			//bottomPanel.gameObject.SetActive (false);

			RectTransform rt = bottomPanel.GetComponent<RectTransform>();
			rt.anchoredPosition = new Vector2 (0, -Screen.height);


			intiPanelVector ();
		} else {
			vectorPanel.gameObject.SetActive (false);
			//bottomPanel.gameObject.SetActive (true);

			RectTransform rt = bottomPanel.GetComponent<RectTransform>();
			rt.anchoredPosition = new Vector2 (0, -Screen.height/2 + Screen.height * 0.11f / 2);

		}
	}


	void Setv1x(int x){ v1_x = x;}
	void Setv1y(int x){ v1_y = x;}
	void Setv1z(int x){ v1_z = x;}
	void Setv2x(int x){ v2_x = x;}
	void Setv2y(int x){ v2_y = x;}
	void Setv2z(int x){ v2_z = x;}
	void SetSignv1x(){ 
		if (v1_x != invalid) {
			v1_x = -v1_x;
		} else {
			v1_x = 0;
		}
	}
	void SetSignv1y(){
		if (v1_y != invalid) {
			v1_y = -v1_y;
		} else {
			v1_y = 0;
		}
	}
	void SetSignv1z(){ 
		if (v1_z != invalid) {
			v1_z = -v1_z;
		} else {
			v1_z = 0;
		}
	}
	void SetSignv2x(){ 
		if (v2_x != invalid) {
			v2_x = -v2_x;
		} else {
			v2_x = 0;
		}
	}
	void SetSignv2y(){ 
		if (v2_y != invalid) {
			v2_y = -v2_y;
		} else {
			v2_y = 0;
		}
	}
	void SetSignv2z(){ 
		if (v2_z != invalid) {
			v2_z = -v2_z;
		} else {
			v2_z = 0;
		}
	}


	private GameObject targetCell;
	private GameObject targetCell_small;

	private string targetName;

	public void EnableDigitPanel(string type){
		targetName = type;
		targetCell = GameObject.FindWithTag(targetName);

		targetCell_small = GameObject.FindWithTag (targetName + "_s");

		digitsPanel.gameObject.SetActive (true);

	}

	public void DigitClick(string value){

		targetCell = GameObject.FindWithTag(targetName);
		targetCell_small = GameObject.FindWithTag (targetName + "_s");

		targetCell.GetComponentInChildren<Text>().text = value;
		targetCell_small.GetComponentInChildren<Text>().text = value;

		int num = int.Parse (value);
		switch (targetName) {
		case "v1x":
			Setv1x (num);
			targetName = "v1y";
			break;
		case "v1y":
			Setv1y (num);
			targetName = "v1z";
			break;
		case "v1z":
			Setv1z (num);
			targetName = "v2x";
			break;
		case "v2x":
			Setv2x (num);
			targetName = "v2y";
			break;
		case "v2y":
			Setv2y (num);
			targetName = "v2z";
			break;
		case "v2z":
			Setv2z (num);
			break;
		}
	}

	public void SignClick(){

		targetCell = GameObject.FindWithTag(targetName);
		targetCell_small = GameObject.FindWithTag (targetName + "_s");

		Debug.Log ("Sign target name: "+targetName);

		switch (targetName) {
		case "v1x":
			SetSignv1x ();
			targetCell.GetComponentInChildren<Text>().text = (v1_x).ToString();
			targetCell_small.GetComponentInChildren<Text>().text = (v1_x).ToString();
			targetName = "v1y";
			break;
		case "v1y":
			SetSignv1y ();
			targetCell.GetComponentInChildren<Text>().text = (v1_y).ToString();
			targetCell_small.GetComponentInChildren<Text>().text = (v1_y).ToString();
			targetName = "v1z";
			break;
		case "v1z":
			SetSignv1z ();
			targetCell.GetComponentInChildren<Text>().text = (v1_z).ToString();
			targetCell_small.GetComponentInChildren<Text>().text = (v1_z).ToString();
			targetName = "v2x";
			break;
		case "v2x":
			SetSignv2x ();
			targetCell.GetComponentInChildren<Text>().text = (v2_x).ToString();
			targetCell_small.GetComponentInChildren<Text>().text = (v2_x).ToString();
			targetName = "v2y";
			break;
		case "v2y":
			SetSignv2y ();
			targetCell.GetComponentInChildren<Text>().text = (v2_y).ToString();
			targetCell_small.GetComponentInChildren<Text>().text = (v2_y).ToString();
			targetName = "v2z";
			break;
		case "v2z":
			SetSignv2z ();
			targetCell.GetComponentInChildren<Text>().text = (v2_z).ToString();
			targetCell_small.GetComponentInChildren<Text>().text = (v2_z).ToString();
			break;
		}

	

	}

	private string operatorChosed = "plus";

	public Button bPlus;
	public Button bMinus;

	public Sprite[] sprites;
	public Button smallOperator;

	public void operatorPlus(){
		operatorChosed = "plus";

		bPlus.image.overrideSprite = sprites [1];
		smallOperator.image.overrideSprite = sprites [1];
		bMinus.image.overrideSprite = sprites [2];
	}
	public void operatorMinus(){
		operatorChosed = "minus";
		bPlus.image.overrideSprite = sprites [0];
		smallOperator.image.overrideSprite = sprites [3];
		bMinus.image.overrideSprite = sprites [3];
	}

	private void calculate(){
		if (operatorChosed.Equals ("")
			|| v1_x == invalid || v1_y == invalid || v1_z == invalid
			|| v2_x == invalid || v2_y == invalid || v2_z == invalid) {

			return;
		} else {
			if (operatorChosed.Equals ("plus")) {
				v3_x = v1_x + v2_x;
				v3_y = v1_y + v2_y;
				v3_z = v1_z + v2_z;
			} else if (operatorChosed.Equals ("minus")) {
				v3_x = v1_x - v2_x;
				v3_y = v1_y - v2_y;
				v3_z = v1_z - v2_z;
			}

			GameObject temp;
			temp = GameObject.FindWithTag("v3x");
			temp.GetComponentInChildren<Text>().text = v3_x.ToString();
			temp = GameObject.FindWithTag("v3y");
			temp.GetComponentInChildren<Text>().text = v3_y.ToString();
			temp = GameObject.FindWithTag("v3z");
			temp.GetComponentInChildren<Text>().text = v3_z.ToString();
		
			temp = GameObject.FindWithTag("v3x_s");
			temp.GetComponentInChildren<Text>().text = v3_x.ToString();
			temp = GameObject.FindWithTag("v3y_s");
			temp.GetComponentInChildren<Text>().text = v3_y.ToString();
			temp = GameObject.FindWithTag("v3z_s");
			temp.GetComponentInChildren<Text>().text = v3_z.ToString();
		}
	}
		
	private float height = 0.7f;

	void draw(){


		if (v1_x == invalid || v1_y == invalid || v1_z == invalid) {
			//Debug.Log ("ooooo:" + v1_x + " "+ v1_y + " " + v1_z);
		}else {
			//Debug.Log ("Vector 1 is ready.");

			v1_tar.gameObject.SetActive (true);

			v1_tar.localPosition = new Vector3 (v1_x*ratio, v1_y*ratio + height, v1_z*ratio);
			v1_cube.localPosition = new Vector3 (v1_x*ratio/2f, v1_y*ratio/2f + height, v1_z*ratio/2f);
			Vector3 mi = v1_cube.transform.localScale;

			mi.z =
				(float) Math.Sqrt(
					(v1_x*ratio) * (v1_x*ratio) 
					+ (v1_y*ratio) * (v1_y*ratio) 
					+ (v1_z*ratio) * (v1_z*ratio));
			v1_cube.transform.localScale = mi;
			//Debug.Log ("Vector 1 is ready.");
		}

		if (v2_x == invalid || v2_y == invalid || v2_z == invalid) {
			
		}else {
			//Debug.Log ("Vector 2 is ready.");

			v2_tar.gameObject.SetActive (true);

			v2_tar.localPosition = new Vector3 (v2_x*ratio, v2_y*ratio + height, v2_z*ratio);
			v2_cube.localPosition = new Vector3 (v2_x*ratio/2f, v2_y*ratio/2f + height, v2_z*ratio/2f);
			Vector3 mi2 = v2_cube.transform.localScale;

			mi2.z = 
				(float) Math.Sqrt(
					(v2_x*ratio) * (v2_x*ratio) 
					+ (v2_y*ratio) * (v2_y*ratio) 
					+ (v2_z*ratio) * (v2_z*ratio));
			v2_cube.transform.localScale = mi2;
			//Debug.Log ("Vector 1 is ready.");
		}

		if (v3_x == invalid || v3_y == invalid || v3_z == invalid) {
			
		}else {

			//Debug.Log ("Vector 3 is ready.");

			v3_tar.gameObject.SetActive (true);

			v3_tar.localPosition = new Vector3 (v3_x*ratio, v3_y*ratio + height, v3_z*ratio);
			v3_cube.localPosition = new Vector3 (v3_x*ratio/2f, v3_y*ratio/2f + height, v3_z*ratio/2f);

			Vector3 mi3 = v3_cube.transform.localScale;
			mi3.z = 
				(float) Math.Sqrt(
					(v3_x*ratio) * (v3_x*ratio) 
					+ (v3_y*ratio) * (v3_y*ratio) 
					+ (v3_z*ratio) * (v3_z*ratio));

			v3_cube.transform.localScale = mi3;

		}
	}

	void Update(){
		calculate ();
		draw ();

		v1_cube.LookAt (v1_tar);
		v2_cube.LookAt (v2_tar);
		v3_cube.LookAt (v3_tar);
	}
		
}