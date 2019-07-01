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

	[Header("Velocidad de Camara")]
	public int VCamera=10;

	[Header("IsPortarQuestion?")]
	public bool PortarQuiention = false;
	[Header("NumberOfQuestion?")]
	public int NumberQuestion = 1;
	[Header("Canvas to hide")]
	public GameObject CamvasToHide;

	[Header("Next mision")]
	public GameObject obj;

	void Start () {
		obj_varGlobals = GameObject.FindWithTag("VariablesGlobales");
		Cs_VarGlobals = obj_varGlobals.GetComponent<VariablesGlobales> ();
		cameraMain=Camera.main;
		Distance = 0;
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Jugador") {
			Cs_VarGlobals.SectionCritic = 1;
			Cs_VarGlobals.NP = -1;
			StartCoroutine (moveCamera());

			if (IsQuestion == true) {
				//this.gameObject.SetActive (false);
				//Destroy (this.gameObject);
				fc.ExecuteBlock ("EscogePeces");
			}
			if (PortarQuiention == true && NumberQuestion==1) {
				CamvasToHide.SetActive (false);
				fc.ExecuteBlock ("PortalIntroduction1");
			}
			if (PortarQuiention == true && NumberQuestion==2) {
				CamvasToHide.SetActive (false);
				fc.ExecuteBlock ("PortalIntroduction2");
			}
			//obj.SetActive (true);
			//this.gameObject.SetActive (false);

		}
	}

	public void MoveCAmera_OfPortal(Transform pos0Cam){
		StartCoroutine (moveCamera2(pos0Cam,60));
	}

	public IEnumerator moveCamera(){
		while(cameraMain.transform.position!=pos0Camera.position){
			cameraMain.transform.position = Vector3.MoveTowards 
				(cameraMain.transform.position,pos0Camera.position,VCamera*Time.deltaTime);
			yield return null;
		}

		yield return new WaitForSeconds(0.0f);
		if (IsQuestion == true) {
			Destroy (this.gameObject);
		}
		//this.gameObject.SetActive (false);
	}
	public IEnumerator moveCamera2(Transform pos0Cam,int v){
		while(cameraMain.transform.position!=pos0Cam.position){
			cameraMain.transform.position = Vector3.MoveTowards 
				(cameraMain.transform.position,pos0Cam.position,v*Time.deltaTime);
			yield return null;
		}

		yield return new WaitForSeconds(0.0f);
		if (IsQuestion == true) {
			Destroy (this.gameObject);
		}
	}


 
}
