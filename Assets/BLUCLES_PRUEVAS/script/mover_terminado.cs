using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover_terminado : MonoBehaviour {
	public int tipo_Dato=0;
	private Vector3 pos_Ini;
	private BoxCollider b_C;
	private Renderer ren;
	public Material mt;
	/*
	void Start(){
		ren = GetComponent<Renderer> ();
		b_C = GetComponent<BoxCollider> ();
		pos_Ini = this.gameObject.transform.position;
		if (tipo_Dato == 1) {
			if (EstadoJuego.estadoJuego.bucle_1 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 2) {
			if (EstadoJuego.estadoJuego.bucle_2 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 3) {
			if (EstadoJuego.estadoJuego.bucle_3 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 4) {
			if (EstadoJuego.estadoJuego.bucle_4 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 5) {
			if (EstadoJuego.estadoJuego.bucle_5 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}

		if (tipo_Dato == 6) {
			if (EstadoJuego.estadoJuego.bucle_6 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}

		if (tipo_Dato == 7) {
			if (EstadoJuego.estadoJuego.bucle_7 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}

		if (tipo_Dato == 8) {
			if (EstadoJuego.estadoJuego.bucle_8 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}

		if (tipo_Dato == 9) {
			if (EstadoJuego.estadoJuego.bucle_9 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}

		if (tipo_Dato == 10) {
			if (EstadoJuego.estadoJuego.bucle_10 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}

		if (tipo_Dato == 11) {
			if (EstadoJuego.estadoJuego.bucle_11 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 12) {
			if (EstadoJuego.estadoJuego.bucle_12 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 13) {
			if (EstadoJuego.estadoJuego.bucle_13 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 14) {
			if (EstadoJuego.estadoJuego.bucle_14 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 15) {
			if (EstadoJuego.estadoJuego.bucle_15 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 16) {
			if (EstadoJuego.estadoJuego.bucle_16 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 17) {
			if (EstadoJuego.estadoJuego.bucle_17 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 18) {
			if (EstadoJuego.estadoJuego.bucle_18 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 19) {
			if (EstadoJuego.estadoJuego.bucle_19 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
		if (tipo_Dato == 20) {
			if (EstadoJuego.estadoJuego.bucle_20 == 1) {
				this.gameObject.transform.position =	pos_Ini + new Vector3 (0,0,-3);
				ren.material = mt;
				this.b_C.enabled = false;
			}
		}
	}*/
}
