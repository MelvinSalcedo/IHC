using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesGlobales : MonoBehaviour {

	// Use this for initialization
	[Header("Activar movimiento de camera siguiente")]
	/*public GameObject trigerCamNext;*/

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

	[HideInInspector]
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
}
