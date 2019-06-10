using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Misiones : MonoBehaviour {
	[Header("Flowchar ")]
	public Flowchart fc;


	[Header("el personaje puedo pasar")]
	public GameObject CanPassPlayer;

	[Header("source")]
	public AudioSource  source;
	[Header("sound")]
	public AudioClip clip_pressButton;
	public AudioClip clip_opendDorr;


	public float speed=5f;
	[Header("Obj to rotate")]
	public GameObject obj_rotate;

	[Header("Siguiente mision")]
	public GameObject obj;

	[Header("StartCoroutine")]
	public GameObject Door;

	private Animator animDor;

	private GameObject obj_personaje;
	private ScriptPlayer sc_personaje;
	public GameObject GameObjectVarGlobals;
	private VariablesGlobales cs_VarGlobals;
	void Start () {
		GameObjectVarGlobals = GameObject.FindWithTag ("VariablesGlobales");
		cs_VarGlobals = GameObjectVarGlobals.GetComponent<VariablesGlobales> ();

		obj_personaje = GameObject.FindWithTag ("Jugador");
		sc_personaje = obj_personaje.GetComponent<ScriptPlayer> ();

		if (obj_rotate == null) {
			obj_rotate = this.gameObject;
		}
		animDor= Door.GetComponent<Animator> ();

	}

	void reproducirSonido(int s){
		if (s == 0) {
			source.PlayOneShot (clip_pressButton);

			//print ("**** "+cs_VarGlobals.ContadorNumeroPasos);
			fc.ExecuteBlock ("pasos");


			//fc.ExecuteBlock ("sigueBuscando");

		} else if (s == 1) {
			source.PlayOneShot (clip_opendDorr);
		}

	}

	// Update is called once per frame
	void OnTriggerEnter(Collider col){
		if (col.tag == "Jugador") {
			
			if (obj != null && obj.name != "Puerta") {
				obj.SetActive (true);
				reproducirSonido (0);
				this.gameObject.SetActive (false);

				sc_personaje.anim.CrossFade ("mixamo_com2",0.0f);
			} else if (obj.name == "Puerta") {
				sc_personaje.anim.CrossFade ("mixamo_com",0.0f);
				animDor.enabled=true;
				reproducirSonido (1);	
				Destroy (CanPassPlayer);
			}
			Destroy (this.gameObject);
		}
	}

	void Update () {
		
		obj_rotate.transform.Rotate (0,Time.deltaTime*speed,0);
	}
		
}
