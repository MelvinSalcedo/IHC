using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delete : MonoBehaviour {

	public Image PosInicial;
	public Image PosFinal;
	bool translateUI;
	public VariablesGlobales VarGlobals;
	Vector3 namePose=new Vector3();
	// Update is called once per frame


	void Update () {
		

		if (translateUI == true) {
			
			PosInicial.transform.position = Vector3.MoveTowards(PosInicial.transform.position,
				PosFinal.transform.position,333*Time.deltaTime);
			
			if (PosInicial.transform.position == PosFinal.transform.position) {
				VarGlobals.offset = 110;
				//Destroy (PosInicial);
				PosInicial.gameObject.SetActive(false);

				VarGlobals.contadorPez++;

				if (VarGlobals.contadorPez <= VarGlobals.pez.Length) {
					VarGlobals.activateCamvasPez ();
				}

				translateUI = false;
				Destroy (this.gameObject);
			}
		}


	}	

	void OnMouseDown ()
	{
		
		PosFinal.transform.position += new Vector3 (VarGlobals.offset, 0, 0);
		namePose = Camera.main.WorldToScreenPoint(this.transform.position);
		PosInicial.transform.position = namePose;
		translateUI = true;
		PosInicial.gameObject.SetActive (true);
	}

}