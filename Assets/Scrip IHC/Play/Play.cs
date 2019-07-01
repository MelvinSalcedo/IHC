using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour {
	public Flowchart fc;
	// Use this for initialization

	public void DisplayMision(){
		fc.ExecuteBlock ("Play1");
	}

	public void ChangeScene(string nameScene){
			SceneManager.LoadScene(nameScene);
		
	}

}
