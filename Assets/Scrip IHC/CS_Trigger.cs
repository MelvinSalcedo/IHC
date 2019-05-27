using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CS_Trigger : MonoBehaviour {

	public Transform pos0Camera;
	public bool IsQuestion=false;
	public Flowchart fc;

	private Camera cameraMain;
	private Vector3 DistanceToPosCamera;
	private float Distance;
	private GameObject obj_varGlobals;
	private VariablesGlobales Cs_VarGlobals;


	void Start () {
		obj_varGlobals = GameObject.FindWithTag("VariablesGlobales");
		Cs_VarGlobals = obj_varGlobals.GetComponent<VariablesGlobales> ();
		cameraMain=Camera.main;
		Distance = 0;
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Jugador") {
			Cs_VarGlobals.SectionCritic = 1;
			StartCoroutine (moveCamera());

			if (IsQuestion == true) {
				//this.gameObject.SetActive (false);
				//Destroy (this.gameObject);
				fc.ExecuteBlock ("EscogePeces");
			}
		}
	}

	public IEnumerator moveCamera(){
		while(cameraMain.transform.position!=pos0Camera.position){
			cameraMain.transform.position = Vector3.MoveTowards 
				(cameraMain.transform.position,pos0Camera.position,10*Time.deltaTime);
			yield return null;
		}

		yield return new WaitForSeconds(0.0f);
		if (IsQuestion == true) {
			Destroy (this.gameObject);
		}
	}

 
}
