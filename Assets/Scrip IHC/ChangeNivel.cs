using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ChangeNivel : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider col)
	{
		if(col.tag=="Jugador"){
		// Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
			SceneManager.LoadScene("Mockups");
		}
	}
}
