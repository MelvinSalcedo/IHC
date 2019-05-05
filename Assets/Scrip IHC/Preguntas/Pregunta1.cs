using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Pregunta1 : MonoBehaviour {

	[Header("fungus flowchart ")]
	public Flowchart fc;


	void Update () {

		this.transform.Rotate (0,Time.deltaTime*50,0);
	}


	void OnTriggerEnter(Collider col){
		if (col.tag == "Jugador") {
			fc.ExecuteBlock ("Pregunta 1");
		}
	}

}
