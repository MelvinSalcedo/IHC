using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScriptPlayer : MonoBehaviour {
	[Header("GameObject whit script VarGlobals")]
	public GameObject GameObjectVarGlobals;
	private VariablesGlobales cs_VarGlobals;

	[Header("Particulas")]
	public GameObject ParticulaPlayer;
	public GameObject ParticulaFree;
	private Vector3 posicionAdicional  =new Vector3 (0,0.3f,0);
	[Header("Parent")]
	public GameObject Parent;
	[Header("DistanciaPasos")]
	public float numero_pasos_dados = 2.00f;

	[Header("Player")]
	public Transform jugador;

	[Header("Posicion Final Juego")]
	public GameObject final;

	[Header ("Text")]
	public Text numberOfPases;

	[Header("Sprites")]
	public Sprite right;
	public Sprite left;
	public Sprite down;
	public Sprite up;
	public Sprite SpriteDefault;
	public Sprite SpriteEjecucion;

	[HideInInspector]
	public Sprite llave_d;
	[HideInInspector]
	public Sprite llave_I;
	[HideInInspector]
	public Sprite repetir_2;
	[HideInInspector]
	public Sprite repetir_3;
	[HideInInspector]
	public Sprite repetir_4;
	[HideInInspector]
	public Sprite repetir_5;

	// PRIVATE

	private int n_activador=0,activador_ = 0;

	[HideInInspector]
	public int activador_animacion = 0;
	[HideInInspector]
	public int ContadorInstrucciones = 0;

	[HideInInspector]
	public int sizeComandos=0;

	private int ContadorListaInstrucciones=0;
	private int begin = 0;

	private Vector3 PosicionInicial;

	private float EjecutarSecuencias = 0;
	private float distancia=0;

	private bool arriba=true;
	private bool EnEjecucionComandos=false;

	private GameObject cube;
	private GameObject P_I_P_segundo;
	[HideInInspector]
	public GameObject[] comandos;
	private GameObject[] comandosSpriteEjecucion;

	private Animator anim;

	private UnityEngine.AI.NavMeshAgent navmesh;


	// Direccionales 
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
	// Listas 
	private List<Pair> ListaInstrucciones = new List<Pair>();
	private List<Pair> ListaAcumuladorInstrucciones= new List<Pair>();

	private GameObject temp;
	private ScriptArrow SCarrow;
	private int lengTextInt;
	[HideInInspector]
	public int TipoEjecucion=0;


	void Start () {
		GameObjectVarGlobals = GameObject.FindWithTag ("VariablesGlobales");
		cs_VarGlobals = GameObjectVarGlobals.GetComponent<VariablesGlobales> ();

		SCarrow = GetComponent<ScriptArrow> ();
		navmesh = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		P_I_P_segundo = GameObject.CreatePrimitive(PrimitiveType.Cube);
		P_I_P_segundo.transform.position = jugador.position;
		P_I_P_segundo.GetComponentInChildren<Renderer> ().enabled = false;


		comandos = GameObject.FindGameObjectsWithTag("comandos");
		comandosSpriteEjecucion=GameObject.FindGameObjectsWithTag("entrenamiento");
		Array.Sort(comandos, CompareNames);
		Array.Sort(comandosSpriteEjecucion, CompareNames);
		PosicionInicial = this.transform.position;
		sizeComandos = comandos.Length;

		numberOfPases.text = sizeComandos.ToString();// convert int to string
		//lengTextInt = int.Parse(numberOfPases.text);// convert string to int


	}

	void Update () {
		Animating ();
		crear_cubos ();

		if (EjecutarSecuencias == 1) {
			arriba = false;
			play ();
		} else if (activador_animacion == 0) {
			EjecutarSecuencias = 0;
			arriba = true;
		}
		if (activador_animacion == 1) {
			arriba = false;
			activador_animacion = 0;
		}
	}

	int CompareNames(GameObject x, GameObject y){
		return x.name.CompareTo(y.name);
	}

	public void eliminar_instrucionnes(){
		int y_con = ListaInstrucciones.Count; 
		ListaInstrucciones.Clear ();
		ListaAcumuladorInstrucciones.Clear ();
	}

	void Animating(){
		if (arriba == false) {
			anim.SetBool ("caminando", true);
		} else {
			anim.SetBool ("caminando", false);	
		}
	}
		

	void crear_cubos(){
		if(ListaInstrucciones.Count==0){
			EnEjecucionComandos=false;
			for (int y = 0; y < ContadorInstrucciones; y++) {
				comandosSpriteEjecucion [y].GetComponent<Image> ().sprite = SpriteDefault;
			}

		}
		if (EnEjecucionComandos == false) {
			if (ContadorInstrucciones < sizeComandos) {
				if (Input.GetMouseButtonDown (1)) {
					if (ContadorInstrucciones > 0) {
						comandos [ListaAcumuladorInstrucciones.Count - 1].GetComponent<Image> ().sprite = SpriteDefault;
						ListaAcumuladorInstrucciones.RemoveAt (ListaAcumuladorInstrucciones.Count - 1);
						ContadorInstrucciones--;

						int temporal = int.Parse (numberOfPases.text) + 1;

						numberOfPases.text = temporal.ToString();

					}
				} else if (Input.GetKeyDown ("space") ) {
					ContadorInstrucciones = 0;
					ArmarSecuenciaInstruciones ();
					EjecutarSecuencias = 1;
					n_activador = 1;
					EnEjecucionComandos = true;
					ParticulaFree.transform.position = this.transform.position+posicionAdicional;
					ParticulaPlayer.SetActive (false);
					ParticulaFree.SetActive (true);
					
				} else if (Input.GetKeyDown ("w") || Input.GetKeyDown ("up")) {
					TipoEjecucion = 0;
					comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = up;
					Pair pair_ = new Pair (new Vector3 (numero_pasos_dados, 0, 0), -1);
					ContadorInstrucciones += 1;
					ListaAcumuladorInstrucciones.Add (pair_);
					int temporal = sizeComandos - ContadorInstrucciones;
					numberOfPases.text = temporal.ToString();


				} else if (Input.GetKeyDown ("s") || Input.GetKeyDown ("down")) {
					TipoEjecucion = 1;
					comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = down;
					ContadorInstrucciones += 1;
					Pair pair_ = new Pair (new Vector3 (-numero_pasos_dados, 0, 0), -1);
					ListaAcumuladorInstrucciones.Add (pair_);

					int temporal = sizeComandos - ContadorInstrucciones;
					numberOfPases.text = temporal.ToString();

		
				} else if (Input.GetKeyDown ("a") || Input.GetKeyDown ("left")) {
					TipoEjecucion = 2;
					comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = left;
					ContadorInstrucciones += 1;
					Pair pair_ = new Pair (new Vector3 (0, 0, numero_pasos_dados), -1);
					ListaAcumuladorInstrucciones.Add (pair_);

					int temporal = sizeComandos - ContadorInstrucciones;
					numberOfPases.text = temporal.ToString();

				} else if (Input.GetKeyDown ("d") || Input.GetKeyDown ("right")) {
					TipoEjecucion = 3;
					comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = right;
					ContadorInstrucciones += 1;
					Pair pair_ = new Pair (new Vector3 (0, 0, -numero_pasos_dados), -1);
					ListaAcumuladorInstrucciones.Add (pair_);

					int temporal = sizeComandos - ContadorInstrucciones;
					numberOfPases.text = temporal.ToString();

				}
			} else {
				if (Input.GetMouseButtonDown (1)) {
					if (ContadorInstrucciones > 0) {
						comandos [ListaAcumuladorInstrucciones.Count - 1].GetComponent<Image> ().sprite = SpriteDefault;
						ListaAcumuladorInstrucciones.RemoveAt (ListaAcumuladorInstrucciones.Count - 1);
						ContadorInstrucciones--;

						int temporal = int.Parse (numberOfPases.text) + 1;

						numberOfPases.text = temporal.ToString();
					}
				} else if (Input.GetKeyDown ("space")) {
					ParticulaFree.transform.position = this.transform.position+posicionAdicional;
					ParticulaPlayer.SetActive (false);
					ParticulaFree.SetActive (true);
					ContadorInstrucciones = 0;
					ArmarSecuenciaInstruciones ();
					EjecutarSecuencias = 1;
					n_activador = 1;
					EnEjecucionComandos = true;


				}	
			}
		}
	}
		
	private Vector3 diferenciaDistancia;
	float CuadradosDiferenciaDistancia;
	void play(){
		if (ListaInstrucciones.Count > 0) {
			if (n_activador == 1) {
				comandosSpriteEjecucion [ContadorListaInstrucciones].GetComponent<Image> ().sprite = SpriteEjecucion;
				cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.position = P_I_P_segundo.transform.position + ListaInstrucciones [0].vector_3;
				P_I_P_segundo.transform.position = cube.transform.position;
				cube.GetComponentInChildren<Renderer> ().enabled = false;
				n_activador = 0;
			}
			diferenciaDistancia = this.transform.position - cube.transform.position;
			CuadradosDiferenciaDistancia = diferenciaDistancia.sqrMagnitude;

			//distancia =	Vector3.Distance (jugador.position, cube.transform.position);
			navmesh.destination = cube.transform.position;
			if (CuadradosDiferenciaDistancia <= 0.2f) {
				int temporal = int.Parse(numberOfPases.text)+1;

				numberOfPases.text = temporal.ToString();

				ContadorListaInstrucciones++;
				ListaInstrucciones.RemoveAt (0);
				comandosSpriteEjecucion [ContadorListaInstrucciones-1].GetComponent<Image> ().sprite = SpriteDefault;
				n_activador = 1;
				//print (ContadorListaInstrucciones + " "+begin);
				if (ContadorListaInstrucciones == begin) {
					ParticulaPlayer.SetActive (true);
					ParticulaFree.SetActive (false);

					for (int y = 0; y < begin; y++) {
						comandos [y].GetComponent<Image> ().sprite = SpriteDefault;
					}
					//->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					for(int y = 0; y < Parent.transform.childCount; y++){
						Destroy(Parent.transform.GetChild(y).gameObject);
					}
					cs_VarGlobals.Bool_PermitirPressBotonos = true;


				}
			}
		}else {
			arriba = true;
			ContadorListaInstrucciones=0;
		}

	}

	void ArmarSecuenciaInstruciones(){
		
		int longitud_lista = ListaAcumuladorInstrucciones.Count; 
		if (longitud_lista > 0) {
			for (int coun = 0; coun < longitud_lista; coun++) {
				ListaInstrucciones.Add (ListaAcumuladorInstrucciones[coun]);
			}
		}
		begin = ListaInstrucciones.Count;	
		ListaAcumuladorInstrucciones.Clear ();
	}
		
	void OnTriggerEnter(Collider target){
		if (target.tag == "ultima_mision") {
			final.SetActive (true);
			eliminar_instrucionnes ();
			PosicionInicial = jugador.position;									
			P_I_P_segundo.transform.position =PosicionInicial;
			jugador.position = PosicionInicial;
			navmesh.destination = PosicionInicial;
		}
		else if(target.tag=="inicio"){
			arriba = false;
			numberOfPases.text = "10";
			eliminar_instrucionnes ();
			P_I_P_segundo.transform.position =PosicionInicial;
			jugador.position = PosicionInicial;
			navmesh.destination = PosicionInicial;	

			for (int y = 0; y < begin; y++) {
				comandos [y].GetComponent<Image> ().sprite = SpriteDefault;
			}
			//->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			for(int y = 0; y < Parent.transform.childCount; y++){
				Destroy(Parent.transform.GetChild(y).gameObject);
			}
			for (int y = 0; y < 10; y++) {
				comandosSpriteEjecucion [y].GetComponent<Image> ().sprite = SpriteDefault;
			}


			SCarrow.ListaPosiciones.Clear ();
			cs_VarGlobals.Bool_PermitirPressBotonos = true;
			SCarrow.ContadorInstrucciones=0;
			SCarrow.NumberArrow = 0;
			SCarrow.LP = transform.position;

			ParticulaFree.transform.position =jugador.position+posicionAdicional;
			ParticulaPlayer.SetActive (true);
			ParticulaFree.SetActive (false);

		}
	}

////////////////////////////////////////////
	public void Up (){
		bool mmm = false;
		if (EnEjecucionComandos == false) {
			if (ContadorInstrucciones < sizeComandos) {
				
				int temporal =int.Parse(numberOfPases.text)-1;
				numberOfPases.text = temporal.ToString();

				if (mmm == false) {
					

					TipoEjecucion = 0;
					comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = up;
					Pair pair_ = new Pair (new Vector3 (numero_pasos_dados, 0, 0), -1);
					ContadorInstrucciones += 1;
					ListaAcumuladorInstrucciones.Add (pair_);
					SCarrow.UpAqrrow();

					mmm = true;
				} 
			}
		}
	}

	public void Down (){
		if (EnEjecucionComandos == false) {
			bool mmm = false;
			if (ContadorInstrucciones < sizeComandos) {
				if (mmm == false) {
					int temporal =int.Parse(numberOfPases.text)-1;
					numberOfPases.text = temporal.ToString();

					TipoEjecucion = 1;
					comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = down;
					ContadorInstrucciones += 1;
					Pair pair_ = new Pair (new Vector3 (-numero_pasos_dados, 0, 0), -1);
					ListaAcumuladorInstrucciones.Add (pair_);
					SCarrow.DownAqrrow();

					mmm = true;
				} 
			}
		}
	}

	public void Left (){
		if (EnEjecucionComandos == false) {
			bool mmm = false;
			if (ContadorInstrucciones < sizeComandos) {
				if (mmm == false) {
					int temporal =int.Parse(numberOfPases.text)-1;
					numberOfPases.text = temporal.ToString();

					TipoEjecucion = 2;
					comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = left;
					ContadorInstrucciones += 1;
					Pair pair_ = new Pair (new Vector3 (0, 0, numero_pasos_dados), -1);
					ListaAcumuladorInstrucciones.Add (pair_);
					SCarrow.LeftAqrrow ();

					mmm = true;
				} 
			}
		}
	}

	public void Right (){
		if (EnEjecucionComandos == false) {
			bool mmm = false;
			if (ContadorInstrucciones < sizeComandos) {
				if (mmm == false) {

					int temporal =int.Parse(numberOfPases.text)-1;
					numberOfPases.text = temporal.ToString();

					TipoEjecucion = 3;
					comandos [ContadorInstrucciones].GetComponent<Image> ().sprite = right;
					ContadorInstrucciones += 1;
					Pair pair_ = new Pair (new Vector3 (0, 0, -numero_pasos_dados), -1);
					ListaAcumuladorInstrucciones.Add (pair_);
					SCarrow.RightAqrrow ();

					mmm = true;
				} 
			}
		}
	}

	public void Back (){
		if (EnEjecucionComandos == false) {
			bool mmm = false;
			if (ContadorInstrucciones < sizeComandos) {
					
				if (ContadorInstrucciones > 0) {

					int temporal =int.Parse(numberOfPases.text)+1;
					numberOfPases.text = temporal.ToString();

					comandos [ListaAcumuladorInstrucciones.Count - 1].GetComponent<Image> ().sprite = SpriteDefault;
					ListaAcumuladorInstrucciones.RemoveAt (ListaAcumuladorInstrucciones.Count - 1);
					ContadorInstrucciones--;

					SCarrow.DeleteArrow ();
				}
			} else {
				if (ContadorInstrucciones > 0) {
					comandos [ListaAcumuladorInstrucciones.Count - 1].GetComponent<Image> ().sprite = SpriteDefault;
					ListaAcumuladorInstrucciones.RemoveAt (ListaAcumuladorInstrucciones.Count - 1);
					ContadorInstrucciones--;
				}
				SCarrow.DeleteArrow ();
			}
		}
	}

	public void Enter (){
		ParticulaFree.transform.position = this.transform.position+posicionAdicional;
		ParticulaPlayer.SetActive (false);
		ParticulaFree.SetActive (true);

		if (EnEjecucionComandos == false) {
			if (ContadorInstrucciones < sizeComandos) {
				ContadorInstrucciones = 0;
				ArmarSecuenciaInstruciones ();
				EjecutarSecuencias = 1;
				n_activador = 1;
				EnEjecucionComandos = true;
			} else {
				ContadorInstrucciones = 0;
				ArmarSecuenciaInstruciones ();
				EjecutarSecuencias = 1;
				n_activador = 1;
				EnEjecucionComandos = true;
			}
		}
		SCarrow.SpaceArrow ();

	}


}