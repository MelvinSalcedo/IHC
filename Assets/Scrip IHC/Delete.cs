using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delete : MonoBehaviour {

	public Image ImgOrigen;
	public Image ImgDestino;
	bool translateUI;

	Vector3 namePose=new Vector3();
	// Update is called once per frame


	void Update () {
		

		if (translateUI == true) {
			
			ImgOrigen.transform.position = Vector3.MoveTowards(ImgOrigen.transform.position,
				ImgDestino.transform.position,333*Time.deltaTime);
		}


	}	

	void OnMouseDown ()
	{
		namePose = Camera.main.WorldToScreenPoint(this.transform.position);
		ImgOrigen.transform.position = namePose;
		translateUI = true;
		ImgOrigen.gameObject.SetActive (true);
	}

}