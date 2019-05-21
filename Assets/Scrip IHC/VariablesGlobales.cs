using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesGlobales : MonoBehaviour {

	// Use this for initialization
	[Header("Activar movimiento de camera siguiente")]
	public GameObject trigerCamNext;

	[Header("CmabasPeces")]
	public GameObject[] pez;
	[HideInInspector]
	public int contadorPez=-1;

	[HideInInspector]
	public int I_CountFishesClicked=0;
	[HideInInspector]
	public int offset = 0;

	public void  countFishesClicked(){
		I_CountFishesClicked++;
		if (I_CountFishesClicked == 3) {
			trigerCamNext.SetActive (true);
		}
	}

	public void activateCamvasPez(){
		pez [contadorPez].SetActive (true);
	}
}
