using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class VariablesGlobales : MonoBehaviour {

	// Use this for initialization
	//[Header("Numeros")]
	//public AudtrigerCamNext;

	[Header("Flowchar")]
	public Flowchart fc;

	[Header("CmabasPeces")]
	public GameObject[] pez;

	[Header("GameObject peces")]
	public GameObject[] peces;

	[HideInInspector]
	public int contadorPez=-1;

	[HideInInspector]
	public int I_CountFishesClicked=0;

	[HideInInspector]
	public int offset = 0;

	[HideInInspector]
	public bool Bool_PermitirPressBotonos;

	[HideInInspector]
	public int SectionCritic=0;


	public int ContadorNumeroPasos=0;
	public int NP=0;

	[HideInInspector]
	public bool EnEjecucionComandos=false;

	void Start(){
		Bool_PermitirPressBotonos = true;
	}

	public void  countFishesClicked(){
		I_CountFishesClicked++;
		if (I_CountFishesClicked == 3) {
			//trigerCamNext.SetActive (true);
		}
	}

	public void activateCamvasPez(){
		pez [contadorPez].SetActive (true);
	}

	public void moverPecesEliminar(){
		for (int i = 0; i < peces.Length; i++) {
			if (peces [i] != null) {
				
			}
		}
	}

	public void PreguntaPasos(){
		//fc.ExecuteBlock ("pasos");
	}


	public void SetEnEjecucionComandos(bool ta){
		StartCoroutine (time(ta));

	}

	IEnumerator time(bool b){
		new WaitForSeconds (1.0f);
		EnEjecucionComandos = b;
		yield return new WaitForSeconds (0.0f);
	}

}
