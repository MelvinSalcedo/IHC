using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Pregunta1 : MonoBehaviour {

	[Header("fungus flowchart ")]
	public Flowchart fc;

	[HideInInspector]
	public Camera MainCamera;

	[HideInInspector]
	public int SectionCritic=0;

	[Header("Numero de nivel")]
	public int NumeroNivel=0;

	private bool Doonce=false;
	private float Speed=5.0f;
	private float InicialPositionOfCamera;
	void Start(){
		MainCamera = Camera.main;
		InicialPositionOfCamera = MainCamera.transform.position.z;
	}
	void Update () {
		
		if (Doonce == true) {
			if (NumeroNivel == 0) {
				MainCamera.transform.Translate (-Vector3.left * Time.deltaTime * Speed);
				if (MainCamera.transform.position.z < 0) {
					Doonce = false;
				}
				//print (MainCamera.transform.position.z);
			} else {
				MainCamera.transform.Translate (Vector3.left * Time.deltaTime * Speed);
				if (MainCamera.transform.position.z > InicialPositionOfCamera) {
					Doonce = false;
				}
			}
		} else {
			this.transform.Rotate (0,Time.deltaTime*50,0);
		}
	}


	void OnTriggerEnter(Collider col){
		if (col.tag == "Jugador") {
			Doonce = true;
			SectionCritic = 1;
			NumeroNivel = 0;
			foreach (Transform child in transform) {
				//print ("Foreach loop: " + child);
				child.gameObject.SetActive (false);
			}
			fc.ExecuteBlock ("Pregunta 1");
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "Jugador") {
			Doonce = true;
			SectionCritic = 1;
			NumeroNivel = 1;

		}
	}

}
