using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class problemas_bucle : MonoBehaviour {
	public GameObject imagen_carga;
	public Slider barra;

	private AsyncOperation asyn;
	public int nivel = 0;
	public void click_carga(){
		imagen_carga.SetActive (true);
		StartCoroutine (Loadlevelslider(1));
	}

	IEnumerator Loadlevelslider(int nivel){
		asyn = Application.LoadLevelAsync (nivel);
		while(!asyn.isDone){
			barra.value=asyn.progress;
			yield return null;
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.tag == "Jugador") {
			/*if (nivel == 2){EstadoJuego.estadoJuego.bucle_2 = 1;}
			else if (nivel == 3){EstadoJuego.estadoJuego.bucle_3 = 1;}
			else if (nivel == 4){EstadoJuego.estadoJuego.bucle_4 = 1;}
			else if (nivel == 5){EstadoJuego.estadoJuego.bucle_5 = 1;}
			else if (nivel == 6){EstadoJuego.estadoJuego.bucle_6 = 1;}
			else if (nivel == 7){EstadoJuego.estadoJuego.bucle_7 = 1;}
			else if (nivel == 8){EstadoJuego.estadoJuego.bucle_8 = 1;}
			else if (nivel == 9){EstadoJuego.estadoJuego.bucle_9 = 1;}
			else if (nivel == 10){EstadoJuego.estadoJuego.bucle_10 = 1;}
			else if (nivel == 11){EstadoJuego.estadoJuego.bucle_11 = 1;}
			else if (nivel == 12){EstadoJuego.estadoJuego.bucle_12 = 1;}
			else if (nivel == 13){EstadoJuego.estadoJuego.bucle_13 = 1;}
			else if (nivel == 14){EstadoJuego.estadoJuego.bucle_14 = 1;}
			else if (nivel == 15){EstadoJuego.estadoJuego.bucle_15 = 1;}
			else if (nivel == 16){EstadoJuego.estadoJuego.bucle_16 = 1;}
			else if (nivel == 17){EstadoJuego.estadoJuego.bucle_17 = 1;}
			else if (nivel == 18){EstadoJuego.estadoJuego.bucle_18 = 1;}
			else if (nivel == 19){EstadoJuego.estadoJuego.bucle_19 = 1;}
			else if (nivel == 20){EstadoJuego.estadoJuego.bucle_20 = 1;}
			EstadoJuego.estadoJuego.guardar_bucles();*/
			click_carga ();
		}
	}
}
