
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class ExamQuestion : MonoBehaviour {

	[Header("fungus flowchart ")]
	public Flowchart fc;

	[Header("Numero de pregunta")]
	public int numeroPregunta=0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0,Time.deltaTime*50,0);
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Jugador") {
			fc.ExecuteBlock ("Alerta");
			if (numeroPregunta == 1) {
				fc.ExecuteBlock ("Question1");
			}
			else if (numeroPregunta == 2) {
				fc.ExecuteBlock ("Question2");
			}
			else if (numeroPregunta == 3) {
				fc.ExecuteBlock ("Question3");
			}
			else if (numeroPregunta == 4) {
				fc.ExecuteBlock ("Question4");
			}
		}
	}

}
