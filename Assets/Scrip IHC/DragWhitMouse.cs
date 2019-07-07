using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using Fungus;
using UnityEngine.SceneManagement;

public class DragWhitMouse : MonoBehaviour, IDragHandler  {
	public Flowchart fc;
	public void OnDrag (PointerEventData data) {
		transform.position = data.position;
	}

	void Update(){
		if(Input.GetKeyDown ("space")){
			fc.ExecuteBlock("pregunta");
		}
		if(Input.GetKeyDown ("1")){
			SceneManager.LoadScene("GameIhc");
		}
	}
}
