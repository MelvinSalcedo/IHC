using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Misiones : MonoBehaviour {
	
	[Header("el personaje puedo pasar")]
	public GameObject CanPassPlayer;
	public GameObject CanPassPlayer1;
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

	void Start () {
		//StartCoroutine(OpenDor(5f));
//		source = GetComponent<AudioSource> ();
		if (obj_rotate == null) {
			obj_rotate = this.gameObject;
		}
		animDor= Door.GetComponent<Animator> ();

	}

	void reproducirSonido(int s){
		if (s == 0) {
			source.PlayOneShot (clip_pressButton);
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
			} else if (obj.name == "Puerta") {
				animDor.enabled=true;
				reproducirSonido (1);	
				Destroy (CanPassPlayer);
				Destroy (CanPassPlayer1);

			}

			Destroy (this.gameObject);
		}
	}
	void Update () {
		
		obj_rotate.transform.Rotate (0,Time.deltaTime*speed,0);
	}


	//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>><<
	private IEnumerator OpenDor()
	{
		
		float RotateDoorY = Door.transform.rotation.y;
		print ("RotateDoorY " + Door.transform.rotation.y);
		while(Door.transform.rotation.y>-70f/1.0)
		{
			print (". "+Door.transform.rotation.y);
			Door.transform.Rotate (0,RotateDoorY,0);
			RotateDoorY-=1;
			yield return null;
		}
		print ("end");
		yield return new WaitForSeconds(1f);

	}
}
