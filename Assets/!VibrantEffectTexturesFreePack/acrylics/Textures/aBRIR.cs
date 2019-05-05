using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aBRIR : MonoBehaviour {

	public GameObject a;
	public GameObject b;
	float textWidth;
	public int pos = 0;
	void OnTriggerEnter(Collider other){
		if (other.tag == "Jugador") {
			a.SetActive (false);
			b.SetActive (false);
			pos = 1;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Jugador") {
			pos = 0;
		}
		pos = 0;
	}
	void OnGUI () {
		if (pos == 1) {
			string myString = "PUERTA ABIERTA";
			textWidth = myString.Length * 10;
			GUI.Label (new Rect (Screen.width / 2 - textWidth / 2, Screen.height / 2, textWidth, 1000), myString);

		}
	}
}
