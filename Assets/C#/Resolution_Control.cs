using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolution_Control : MonoBehaviour {

	public Image logo;
	public Button edit;
	public GameObject mainPanel;
	public GameObject vectorOne;
	public GameObject vectorTwo;
	public GameObject vectorThree;
	public GameObject plus;
	public GameObject minus;
	public GameObject equal;
	public GameObject digitPanel;

	public Button[] digits;
	public Button[] v1;
	public Button[] v3;
	public Button[] v2;

	public GameObject smallPanel;
	public GameObject smallVectorOne;
	public GameObject smallVectorTwo;
	public GameObject smallVectorThree;
	public GameObject smallPlus;
	public GameObject smallEqual;
	public Button[] smallV1;
	public Button[] smallV3;
	public Button[] smallV2;


	private float ratio = Screen.width/1080f;

	// Use this for initialization
	void Start () {
		
		RectTransform rt = logo.GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2(360*ratio, 106*ratio);
		rt.anchoredPosition = new Vector2 (-360*ratio*0.5f, -106*ratio*0.5f);

		RectTransform rt2 = edit.GetComponent<RectTransform>();
		rt2.sizeDelta = new Vector2(200*ratio, 200*ratio);
		rt2.anchoredPosition = new Vector2 (200*ratio*0.5f, 200*ratio*0.5f);

		RectTransform rt3 = vectorOne.GetComponent<RectTransform>();
		rt3.sizeDelta = new Vector2(600*ratio, 150*ratio);
		rt3.anchoredPosition = new Vector2 (0*ratio, 450*ratio);

		RectTransform rt4 = vectorTwo.GetComponent<RectTransform>();
		rt4.sizeDelta = new Vector2(600*ratio, 150*ratio);
		rt4.anchoredPosition = new Vector2 (0*ratio, 150*ratio);

		RectTransform rt5 = vectorThree.GetComponent<RectTransform>();
		rt5.sizeDelta = new Vector2(600*ratio, 150*ratio);
		rt5.anchoredPosition = new Vector2 (0*ratio, -150*ratio);

		RectTransform rt6 = plus.GetComponent<RectTransform>();
		rt6.sizeDelta = new Vector2(100*ratio, 100*ratio);
		rt6.anchoredPosition = new Vector2 (-60*ratio, 300*ratio);

		RectTransform rt7 = minus.GetComponent<RectTransform>();
		rt7.sizeDelta = new Vector2(100*ratio, 100*ratio);
		rt7.anchoredPosition = new Vector2 (60*ratio, 300*ratio);

		RectTransform rt8 = equal.GetComponent<RectTransform>();
		rt8.sizeDelta = new Vector2(100*ratio, 100*ratio);
		rt8.anchoredPosition = new Vector2 (0*ratio, 0*ratio);

		RectTransform rt9 = digitPanel.GetComponent<RectTransform>();
		rt9.sizeDelta = new Vector2(1080*ratio, 300*ratio);
		rt9.anchoredPosition = new Vector2 (0*ratio, -500*ratio);


		for (int i = 0; i < 5; i++) {
			RectTransform rt0 = digits[i].GetComponent<RectTransform>();
			rt0.sizeDelta = new Vector2(100*ratio, 100*ratio);
			rt0.anchoredPosition = new Vector2 ((-240 + 120*i)*ratio, 0*ratio);
		}

		for (int i = 5; i < 10; i++) {
			RectTransform rt0 = digits[i].GetComponent<RectTransform>();
			rt0.sizeDelta = new Vector2(100*ratio, 100*ratio);
			rt0.anchoredPosition = new Vector2 ((-240 + 120*(i-5))*ratio, -120*ratio);
		}

		RectTransform rt10 = digits[digits.Length-1].GetComponent<RectTransform>();
		rt10.sizeDelta = new Vector2(100*ratio, 100*ratio);
		rt10.anchoredPosition = new Vector2 (0*ratio, -240*ratio);


		for (int i = 0; i < v1.Length; i++) {
			RectTransform rt0 = v1[i].GetComponent<RectTransform>();
			rt0.sizeDelta = new Vector2(100*ratio, 100*ratio);
			rt0.anchoredPosition = new Vector2 ((-160 + 160*i)*ratio, 0*ratio);

			v1[i].GetComponentInChildren<Text>().fontSize = (int)(60 * ratio);
		}

		for (int i = 0; i < v2.Length; i++) {
			RectTransform rt0 = v2[i].GetComponent<RectTransform>();
			rt0.sizeDelta = new Vector2(100*ratio, 100*ratio);
			rt0.anchoredPosition = new Vector2 ((-160 + 160*i)*ratio, 0*ratio);

			v2[i].GetComponentInChildren<Text>().fontSize = (int)(60 * ratio);
		}

		for (int i = 0; i < v3.Length; i++) {
			RectTransform rt0 = v3[i].GetComponent<RectTransform>();
			rt0.sizeDelta = new Vector2(100*ratio, 100*ratio);
			rt0.anchoredPosition = new Vector2 ((-160 + 160*i)*ratio, 0*ratio);

			v3[i].GetComponentInChildren<Text>().fontSize = (int)(60 * ratio);
		}



		RectTransform rt9_s = smallPanel.GetComponent<RectTransform>();
		rt9_s.sizeDelta = new Vector2(1080*ratio, 250*ratio);
		rt9_s.anchoredPosition = new Vector2 (0*ratio, -Screen.height/2 + 250/2*ratio);


		RectTransform rt3_s = smallVectorOne.GetComponent<RectTransform>();
		rt3_s.sizeDelta = new Vector2(300*ratio, 75*ratio);
		rt3_s.anchoredPosition = new Vector2 (-120*ratio, 43*ratio);

		RectTransform rt4_s = smallVectorTwo.GetComponent<RectTransform>();
		rt4_s.sizeDelta = new Vector2(300*ratio, 75*ratio);
		rt4_s.anchoredPosition = new Vector2 (310*ratio, 43*ratio);

		RectTransform rt5_s = smallVectorThree.GetComponent<RectTransform>();
		rt5_s.sizeDelta = new Vector2(300*ratio, 75*ratio);
		rt5_s.anchoredPosition = new Vector2 (96*ratio, -53*ratio);


		RectTransform rt7_s = smallPlus.GetComponent<RectTransform>();
		rt7_s.sizeDelta = new Vector2(100*ratio, 100*ratio);
		rt7_s.anchoredPosition = new Vector2 (96*ratio, 43*ratio);

		RectTransform rt8_s = smallEqual.GetComponent<RectTransform>();
		rt8_s.sizeDelta = new Vector2(100*ratio, 100*ratio);
		rt8_s.anchoredPosition = new Vector2 (-106*ratio, -53*ratio);


		for (int i = 0; i < smallV1.Length; i++) {
			RectTransform rt0_s = smallV1[i].GetComponent<RectTransform>();
			rt0_s.sizeDelta = new Vector2(50*ratio, 50*ratio);
			rt0_s.anchoredPosition = new Vector2 ((-80 + 80*i)*ratio, 0*ratio);

			smallV1[i].GetComponentInChildren<Text>().fontSize = (int)(30 * ratio);
		}

		for (int i = 0; i < smallV2.Length; i++) {
			RectTransform rt0_s = smallV2[i].GetComponent<RectTransform>();
			rt0_s.sizeDelta = new Vector2(50*ratio, 50*ratio);
			rt0_s.anchoredPosition = new Vector2 ((-80 + 80*i)*ratio, 0*ratio);

			smallV2[i].GetComponentInChildren<Text>().fontSize = (int)(30 * ratio);
		}

		for (int i = 0; i < smallV3.Length; i++) {
			RectTransform rt0_s = smallV3[i].GetComponent<RectTransform>();
			rt0_s.sizeDelta = new Vector2(50*ratio, 50*ratio);
			rt0_s.anchoredPosition = new Vector2 ((-80 + 80*i)*ratio, 0*ratio);

			smallV3[i].GetComponentInChildren<Text>().fontSize = (int)(30 * ratio);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
