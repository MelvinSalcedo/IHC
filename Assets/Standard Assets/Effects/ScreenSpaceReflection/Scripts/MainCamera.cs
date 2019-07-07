using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public Transform lookat;
	Vector3 dir;
	public float distance;
	public float fixed_distance=0;

	private ProtectCameraFromWallClip cam_collider;

	public int dato_acercamiento_camara=0;
	void Start () {
		cam_collider = GetComponent<ProtectCameraFromWallClip> ();
		this.dir = new Vector3 (0,0,this.distance);
		transform.position = this.lookat.position - this.lookat.rotation * this.dir;
		transform.LookAt (this.lookat);
	}

	// Update is called once per frame
	void Update () {
		this.distance += Input.GetAxis ("Mouse ScrollWheel");
		if (dato_acercamiento_camara == 0) {
				this.distance = Mathf.Clamp (distance, 0.1f, 15f);//limitar la camara entre 2 numeros
		} else {
			this.distance = Mathf.Clamp (6, 0.1f, 15f);//limitar la camara entre 2 numeros
		}

		this.fixed_distance=cam_collider.get_m_CurrentDist();
	}
	void LateUpdate(){
		this.dir.Set (0,0,this.fixed_distance);

		transform.position = this.lookat.position - this.lookat.rotation * this.dir;
		transform.LookAt (this.lookat);
	}
}
