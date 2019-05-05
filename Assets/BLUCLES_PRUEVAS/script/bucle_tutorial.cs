using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bucle_tutorial : MonoBehaviour {

	public GameObject meta_1;
	public GameObject meta_2;
	public GameObject meta_3;

	[Header("pantalla de carga")]
	public int num_meta=0,nivel;
	public GameObject imagen_carga;
	public Slider barra;
	private AsyncOperation asyn;

	public void click_carga(){
		imagen_carga.SetActive (true);
		StartCoroutine (Loadlevelslider(nivel));
	}

	IEnumerator Loadlevelslider(int nivel){
		asyn = Application.LoadLevelAsync (nivel);
		while(!asyn.isDone){
			barra.value=asyn.progress;
			yield return null;
		}
	}

	void OnTriggerEnter(Collider col){

	}
}
