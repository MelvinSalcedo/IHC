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

	void OnMouseDown ()
	{
		
		PosFinal.transform.position += new Vector3 (VarGlobals.offset, 0, 0);
		namePose = Camera.main.WorldToScreenPoint(this.transform.position);
		PosInicial.transform.position = namePose;
		translateUI = true;
		PosInicial.gameObject.SetActive (true);
		StartCoroutine (Scale());
		StartCoroutine (MovePezToCorner());
	}

	public IEnumerator MovePezToCorner(){
		
		while(PosInicial.transform.position != PosFinal.transform.position){
			PosInicial.transform.position = Vector3.MoveTowards(PosInicial.transform.position,
				PosFinal.transform.position,333*Time.deltaTime);
			yield return null;
		}
		VarGlobals.offset = 110;
		VarGlobals.contadorPez++;
		PosInicial.gameObject.SetActive(false);
		if (VarGlobals.contadorPez <= VarGlobals.pez.Length) {
			VarGlobals.activateCamvasPez ();
		}
		yield return new WaitForSeconds(0.0f);
		translateUI = false;
		Destroy (this.gameObject);

	}

	IEnumerator Scale(){
		while(0.5f < transform.localScale.x){
			transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * 5.0f;
			yield return null;
		}
		yield return new WaitForSeconds(0.0f);

	}


}