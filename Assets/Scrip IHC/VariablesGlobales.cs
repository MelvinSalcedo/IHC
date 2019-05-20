using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesGlobales : MonoBehaviour {

	// Use this for initialization
	[Header("CmabasPeces")]
	public GameObject[] pez;
	[HideInInspector]
	public int contadorPez=-1;

	[HideInInspector]
	public int I_CountFishesClicked=0;


	public void  countFishesClicked(){
		I_CountFishesClicked++;
	}

	public void activateCamvasPez(){
		pez [contadorPez].SetActive (true);
	}
}
