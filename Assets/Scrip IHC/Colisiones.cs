using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Colisiones : MonoBehaviour {
	[Header("scrip ScripPlayer")]
	public ScriptPlayer scPalyer;
	[Header("material de ScripArrow")]
	public Material mt;
	[Header("material de ScripPlayer")]
	public Sprite right;
	public Sprite left;
	public Sprite down;
	public Sprite up;

	void OnTriggerEnter(Collider col){
		if (col.tag == "pared") {
			col.GetComponent<Renderer>().material = mt;
			if (scPalyer.TipoEjecucion == 0) {
				scPalyer.comandos [scPalyer.ContadorInstrucciones-1].GetComponent<Image> ().sprite = up;
			}else if (scPalyer.TipoEjecucion == 1) {
				scPalyer.comandos [scPalyer.ContadorInstrucciones-1].GetComponent<Image> ().sprite = down;
			}else if (scPalyer.TipoEjecucion == 2) {
				scPalyer.comandos [scPalyer.ContadorInstrucciones-1].GetComponent<Image> ().sprite = left;
			}else if (scPalyer.TipoEjecucion == 3) {
				scPalyer.comandos [scPalyer.ContadorInstrucciones-1].GetComponent<Image> ().sprite = right;
			}
		}
	}
}
