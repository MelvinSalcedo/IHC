using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bucle : MonoBehaviour {
	[Header("siguiente puntos de salto")]
	public Transform[] next_p;
	[Header("camaras")]
	public GameObject[] cambio_Camera;
	[Header("angulo de la camara")]
	public int cambio_Camera_posicion;
	int n_posicion=0;
	private int n_activador=0,primero = 0,ultimo = 0,activador_ = 0,temporal_ = 0,contador = 0;
	private int activador_bucle = 0;
	public float numero_pasos_dados = 2.00f;
	float tiempo = 0;
	int activador_animacion=0,ContadorInstrucciones = 0,colision=0,compravador_error=0,activar_numero_que_dara_=0;
	bool arriba=true;
	int int_camara=0;
	int colision_obejto=0;
	public Sprite right;
	public Sprite left;
	public Sprite down;
	public Sprite up;
	public Sprite llave_d;
	public Sprite llave_I;
	public Sprite inicio;
	public Transform jugador;
	public Sprite repetir_2;
	public Sprite repetir_3;
	public Sprite repetir_4;
	public Sprite repetir_5;

	private GameObject cube;
	private GameObject P_I_P_segundo;

	GameObject[] comandos;
	Animator anim;




	private UnityEngine.AI.NavMeshAgent navmesh;
	float distancia=0;
	public Transform Posicion_inicial_personaje;



	public GameObject final;
	private float h;
	private float v;


	private struct Pair{
		public Vector3 vector_3;
		public int c_bucle;
		public Pair(Vector3 a,int c) : this(){
			this.vector_3=a;
			this.c_bucle=c;
		}
	}

	List<Pair> myList_pair = new List<Pair>();

	List<GameObject> list = new List<GameObject>();
	List<Pair> lista_vector_bucle = new List<Pair>();
	List<Pair> lista_vector= new List<Pair>();

	List<int> lista_primeros=new List<int>();
	private Vector3 vector_3;

	private int sizeComandos=0;
	void Start () {
		navmesh = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		P_I_P_segundo = GameObject.CreatePrimitive(PrimitiveType.Cube);
		P_I_P_segundo.transform.position = jugador.position;
		P_I_P_segundo.GetComponentInChildren<Renderer> ().enabled = false;
		comandos = GameObject.FindGameObjectsWithTag("comandos");
		Array.Sort(comandos, CompareNames);
		vector_3 = this.transform.position;

		sizeComandos = comandos.Length;
	}

	int CompareNames(GameObject x, GameObject y){
		return x.name.CompareTo(y.name);
	}

	public void eliminar_instrucionnes(){
		int y_con = lista_vector_bucle.Count; 
		lista_vector_bucle.Clear ();
		lista_primeros.Clear ();
		lista_vector.Clear ();
		list.Clear ();
	}
	void Animating(){
		if (arriba == false) {
			anim.SetBool ("caminando", true);
		} else {
			anim.SetBool ("caminando", false);	
		}
	}
	int mmmmmm=0;
	void crear_cubos(){
		if (ContadorInstrucciones < sizeComandos) {
			if(Input.GetMouseButtonDown(1) && colision != 5) {
				if (ContadorInstrucciones > 0) {
					comandos [lista_vector.Count - 1].GetComponent<Image> ().sprite = inicio;
					lista_vector.RemoveAt (lista_vector.Count - 1);
					ContadorInstrucciones--;
				}
			} else if (Input.GetKeyDown ("space") && colision != 5) {
				if (mmmmmm == 0) {
					mmmmmm = 1;
					activar_numero_que_dara_ = 0;
					for (int y = 0; y < lista_vector.Count; y++) {

						if (lista_vector [y].vector_3 == new Vector3 (0, 0, 0)) {
							compravador_error++;
						} else if (lista_vector [y].vector_3 == new Vector3 (-1, -1, -1)) {
							if (compravador_error == 0) {
								compravador_error = 100;
							}
							compravador_error--;
						}
					}

					if (compravador_error == 0) {
						for (int y = 0; y < ContadorInstrucciones; y++) {
							comandos [y].GetComponent<Image> ().sprite = inicio;
						}
						ContadorInstrucciones = 0;
						convertir_estado_base ();
						tiempo = 1;
						colision = 0;
						n_activador = 1;
					} else {
						print ("hay mas o menos sentencias de bucle ");
						lista_vector.Clear ();
						lista_vector_bucle.Clear ();
						list.Clear ();
						for (int y = 0; y < ContadorInstrucciones; y++) {
							comandos [y].GetComponent<Image> ().sprite = inicio;
						}
						ContadorInstrucciones = 0;
						compravador_error = 0;
					}
				}
				//play_bucle ();}
			} else if (Input.GetKeyDown ("w") && colision != 5) {
				activar_numero_que_dara_ = 0;
				comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = up;
				ContadorInstrucciones += 1;

				if (cambio_Camera_posicion == 0) {
					Pair pair_ = new Pair (new Vector3 (numero_pasos_dados, 0, 0), -1);lista_vector.Add (pair_);
				}
				else if (cambio_Camera_posicion ==1) {
					Pair pair_ = new Pair (new Vector3 (-numero_pasos_dados, 0, 0), -1);lista_vector.Add (pair_);
				}else if (cambio_Camera_posicion ==2) {
					Pair pair_ = new Pair (new Vector3 (0, 0, numero_pasos_dados), -1);lista_vector.Add (pair_);
				}
				else if (cambio_Camera_posicion >=3) {
					Pair pair_ = new Pair (new Vector3 (0, 0, -numero_pasos_dados), -1);lista_vector.Add (pair_);
				}

			} else if (Input.GetKeyDown ("s") && colision != 5) {
				activar_numero_que_dara_ = 0;
				comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = down;
				ContadorInstrucciones += 1;
				if (cambio_Camera_posicion == 0) {
					Pair pair_ = new Pair (new Vector3 (-numero_pasos_dados, 0, 0), -1);lista_vector.Add (pair_);
				}
				else if (cambio_Camera_posicion ==1) {
					Pair pair_ = new Pair (new Vector3 (numero_pasos_dados, 0, 0), -1);lista_vector.Add (pair_);
				}else if (cambio_Camera_posicion ==2) {
					Pair pair_ = new Pair (new Vector3 (0, 0, -numero_pasos_dados), -1);lista_vector.Add (pair_);
				}
				else if (cambio_Camera_posicion >=3) {
					Pair pair_ = new Pair (new Vector3 (0, 0, numero_pasos_dados), -1);lista_vector.Add (pair_);
				}
			} else if (Input.GetKeyDown ("a") && colision != 5) {
				activar_numero_que_dara_ = 0;
				comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = left;
				ContadorInstrucciones += 1;
				if (cambio_Camera_posicion == 0) {
					Pair pair_ = new Pair (new Vector3 (0, 0, numero_pasos_dados), -1);lista_vector.Add (pair_);
				}
				else if (cambio_Camera_posicion ==1) {
					Pair pair_ = new Pair (new Vector3 (0, 0, -numero_pasos_dados), -1);lista_vector.Add (pair_);
				}else if (cambio_Camera_posicion ==2) {
					Pair pair_ = new Pair (new Vector3 (-numero_pasos_dados, 0, 0), -1);lista_vector.Add (pair_);
				}
				else if (cambio_Camera_posicion >=3) {
					Pair pair_ = new Pair (new Vector3 (numero_pasos_dados, 0, 0), -1);lista_vector.Add (pair_);
				}

			} else if (Input.GetKeyDown ("d") && colision != 5) {
				activar_numero_que_dara_ = 0;
				comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = right;
				ContadorInstrucciones += 1;
				if (cambio_Camera_posicion == 0) {
					Pair pair_ = new Pair (new Vector3 (0, 0, -numero_pasos_dados), -1);lista_vector.Add (pair_);
				}
				else if (cambio_Camera_posicion ==1) {
					Pair pair_ = new Pair (new Vector3 (0, 0, numero_pasos_dados), -1);lista_vector.Add (pair_);
				}else if (cambio_Camera_posicion ==2) {
					Pair pair_ = new Pair (new Vector3 (numero_pasos_dados, 0, 0), -1);lista_vector.Add (pair_);
				}
				else if (cambio_Camera_posicion >=3) {
					Pair pair_ = new Pair (new Vector3 (-numero_pasos_dados, 0, 0), -1);lista_vector.Add (pair_);
				}
			} else if (Input.GetKeyDown ("f") && colision != 5) {
				activar_numero_que_dara_ = 1;
				Pair pair_;
				comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = llave_d;
				ContadorInstrucciones += 1;
				pair_ = new Pair (new Vector3 (0, 0, 0), 2);
				lista_vector.Add (pair_);

			} else if (Input.GetKeyDown ("down") && colision != 5) {
				if (activar_numero_que_dara_ == 1) {
					comandos [ContadorInstrucciones - 1].GetComponent<Image> ().sprite = repetir_3;

					lista_vector.RemoveAt (lista_vector.Count - 1);
					Pair pair_ = new Pair (new Vector3 (0, 0, 0), 3);
					lista_vector.Add (pair_);
				}
			} else if (Input.GetKeyDown ("left") && colision != 5) {
				if (activar_numero_que_dara_ == 1) {
					comandos [ContadorInstrucciones - 1].GetComponent<Image> ().sprite = repetir_4;

					lista_vector.RemoveAt (lista_vector.Count - 1);
					Pair pair_ = new Pair (new Vector3 (0, 0, 0), 4);
					lista_vector.Add (pair_);
				}
			} else if (Input.GetKeyDown ("right") && colision != 5) {
				if (activar_numero_que_dara_ == 1) {
					comandos [ContadorInstrucciones - 1].GetComponent<Image> ().sprite = repetir_5;

					lista_vector.RemoveAt (lista_vector.Count - 1);
					Pair pair_ = new Pair (new Vector3 (0, 0, 0), 5);
					lista_vector.Add (pair_);
				}
			}else if (Input.GetKeyDown ("up") && colision != 5) {
				if (activar_numero_que_dara_ == 1) {
					comandos [ContadorInstrucciones - 1].GetComponent<Image> ().sprite = repetir_2;

					lista_vector.RemoveAt (lista_vector.Count - 1);
					Pair pair_ = new Pair (new Vector3 (0, 0, 0), 2);
					lista_vector.Add (pair_);
				}
			} else if (Input.GetKeyDown ("g") && colision != 5) {
				activar_numero_que_dara_ = 0;
				comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = llave_I;
				ContadorInstrucciones += 1;
				Pair pair_ = new Pair (new Vector3 (-1, -1, -1), -1);
				lista_vector.Add (pair_);

			} 
		} else {
			if(Input.GetMouseButtonDown(1) && colision != 5) {
				if (ContadorInstrucciones > 0) {
					comandos [lista_vector.Count - 1].GetComponent<Image> ().sprite = inicio;
					lista_vector.RemoveAt (lista_vector.Count - 1);
					ContadorInstrucciones--;
				}
			}

			if (Input.GetKeyDown ("space") && colision != 5) {
				if (mmmmmm == 0) {
					mmmmmm = 1;
					activar_numero_que_dara_ = 0;
					for (int y = 0; y < lista_vector.Count; y++) {

						if (lista_vector [y].vector_3 == new Vector3 (0, 0, 0)) {
							compravador_error++;
						} else if (lista_vector [y].vector_3 == new Vector3 (-1, -1, -1)) {
							if (compravador_error == 0) {
								compravador_error = 100;
							}
							compravador_error--;
						}
					}

					if (compravador_error == 0) {
						for (int y = 0; y < ContadorInstrucciones; y++) {
							comandos [y].GetComponent<Image> ().sprite = inicio;
						}
						ContadorInstrucciones = 0;
						convertir_estado_base ();
						tiempo = 1;
						colision = 0;
						n_activador = 1;
					} else {
						print ("hay mas o menos sentencias de bucle ");
						lista_vector.Clear ();
						lista_vector_bucle.Clear ();
						list.Clear ();
						for (int y = 0; y < ContadorInstrucciones; y++) {
							comandos [y].GetComponent<Image> ().sprite = inicio;
						}
						ContadorInstrucciones = 0;
						compravador_error = 0;
					}
				}
				//play_bucle ();}
			}


		}
	}
	int mjkl=0;
	void play(){
		int s_s = lista_vector_bucle.Count;
		if (s_s > 0) {
			if (n_activador == 1) {
				

				cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.position = P_I_P_segundo.transform.position + lista_vector_bucle [0].vector_3;
				P_I_P_segundo.transform.position = cube.transform.position;
				cube.GetComponentInChildren<Renderer> ().enabled = false;
				n_activador = 0;
			}
			distancia =	Vector3.Distance (jugador.position, cube.transform.position);
			navmesh.destination = cube.transform.position;

			if (distancia <= 0.2f) {
				lista_vector_bucle.RemoveAt (0);
				n_activador = 1;
			}
		} else {
			mmmmmm = 0;
			arriba = true;
		}
	}

	void play_bucle(){

		int begin = 0;
		int longitud_lista = lista_vector.Count; 
		if (longitud_lista > 0) {
			for (int coun = 0; coun < longitud_lista; coun++) {
				
				if (lista_vector [coun].vector_3 != new Vector3 (0, 0, 0)) {
					lista_vector_bucle.Add (lista_vector[coun]);
				} else {
					for (int t = 0; t < lista_vector[lista_primeros[begin]].c_bucle; t++) {
						for (int c = coun+1; c < longitud_lista; c++) {
							if (lista_vector[c].vector_3 != new Vector3 (-1,-1,-1)) {
								lista_vector_bucle.Add (lista_vector[c]);
							} else {
								temporal_ = c ;
								break;
							}
						}
					}coun = temporal_;begin++;
				}
			}
		}

		lista_vector.Clear ();
		lista_primeros.Clear ();
	}
	void vereficar_mas_bucles_anidados(){
		int longitud_lista = lista_vector.Count;
		for (int t = 0; t < longitud_lista; t++) {
			if (lista_vector [t].vector_3 == new Vector3 (0, 0, 0)) {
				if (contador == 0) {
					primero = t+1;
					lista_primeros.Add (t);
				}
				contador += 1;
			} else if (lista_vector [t].vector_3 == new Vector3 (-1, -1, -1)) {
				contador -= 1;
				if (contador == 0) {
					ultimo = t-1;

				}
			}
			if (contador >= 2) {
				activador_ = 1;
			}
		}
		contador = 0;
	}

	void convertir_estado_base(){
		vereficar_mas_bucles_anidados ();
		int mustra = 0;

		if (activador_ == 1) {
			for (int num_bucles = 0; num_bucles < primero-1; num_bucles++) {
				lista_vector_bucle.Add (lista_vector [num_bucles]);
			}
			for (int num_bucles = 0; num_bucles < lista_vector[primero-1].c_bucle; num_bucles++) {
				for (int i = primero; i <=ultimo; i++) {
					lista_vector_bucle.Add (lista_vector [i]);
				}
			}
			for (int num_bucles = ultimo+2; num_bucles < lista_vector.Count; num_bucles++) {
				lista_vector_bucle.Add (lista_vector [num_bucles]);
			}
			lista_vector.Clear();
			for (int num_bucles = 0; num_bucles < lista_vector_bucle.Count; num_bucles++) {
				lista_vector.Add (lista_vector_bucle [num_bucles]);

			}
			activador_ = 0;
			lista_vector_bucle.Clear ();
			lista_primeros.Clear ();
			vereficar_mas_bucles_anidados ();
			if (activador_ == 1) {
				convertir_estado_base ();
			}
			mustra = 1;
		} 
			play_bucle ();
	}

	void Update () {
		int l = list.Count;
		Animating ();
		crear_cubos ();
		if (tiempo == 1) {
			arriba = false;
			play ();
		} else if (activador_animacion == 0) {
			tiempo = 0;
			arriba = true;
		}
		if (activador_animacion == 1) {
			arriba = false;
			/*navmesh.destination = Posicion_inicial_personaje.position;
			jugador.position = Posicion_inicial_personaje.position;*/
			activador_animacion = 0;
		}
	}

	void OnTriggerEnter(Collider target){
		if (target.tag == "ultima_mision") {
			final.SetActive (true);
			//colision = 5;
			eliminar_instrucionnes ();
			vector_3 = jugador.position;									
			P_I_P_segundo.transform.position =vector_3;
			jugador.position = vector_3;
			navmesh.destination = vector_3;

		}
		else if(target.tag=="inicio"){arriba = false;
			print ("___");
			eliminar_instrucionnes ();
			P_I_P_segundo.transform.position =vector_3;
			jugador.position = vector_3;
			navmesh.destination = vector_3;
		}
	}
}
