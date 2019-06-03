using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Respuestas : MonoBehaviour {
	private GameObject OB_fc;
	private Flowchart fc;

	public bool RespuestaCorrecta = false;

	[Header("obj a ser destruidos")]
	public GameObject obj1;
	public GameObject obj2;

	void Start(){
		OB_fc = GameObject.FindWithTag ("Flowchart");	
		fc = OB_fc.GetComponent<Flowchart> ();
		//print (fc.GetIntegerVariable ("Var"));

	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Jugador") {
			if (RespuestaCorrecta==true) {
				fc.ExecuteBlock ("correcto");
				Destroy (obj1);
				Destroy (obj2);
			} else{
				fc.ExecuteBlock ("Incorrecto");
			}
		}
	}



}
