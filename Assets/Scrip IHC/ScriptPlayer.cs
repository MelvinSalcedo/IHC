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


	[Header ("Text")]
	public Text numberOfPases;


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

	// Listas 
	private List<Vector3> ListaInstrucciones = new List<Vector3>();
	private List<Vector3> ListaAcumuladorInstrucciones= new List<Vector3>();

	private GameObject temp;
	private ScriptArrow SCarrow;
	private int lengTextInt;


	private Vector3 diferenciaDistancia;
	private float CuadradosDiferenciaDistancia;
	private Vector3 pair_ = new Vector3 ();

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
		
	void KeyDirections(char key){
		if (ContadorInstrucciones < sizeComandos) {
			if (key == 'w') {
				SCarrow.UpAqrrow ();
				pair_ = new Vector3 (numero_pasos_dados, 0, 0);
			} else if (key == 's') {
				SCarrow.DownAqrrow ();
				pair_ = new Vector3 (-numero_pasos_dados, 0, 0);
			} else if (key == 'a') {
				SCarrow.LeftAqrrow();
				pair_ = new Vector3 (0, 0, numero_pasos_dados);
			} else if (key == 'd') {
				SCarrow.RightAqrrow();
				pair_ = new Vector3 (0, 0, -numero_pasos_dados);
			}

			ContadorInstrucciones += 1;
			ListaAcumuladorInstrucciones.Add (pair_);
			int temporal = sizeComandos - ContadorInstrucciones;
			numberOfPases.text = temporal.ToString ();
		}

	}

	void KeySpace(){
		SCarrow.SpaceArrow ();
		ContadorInstrucciones = 0;
		ArmarSecuenciaInstruciones ();
		EjecutarSecuencias = 1;
		n_activador = 1;
		EnEjecucionComandos = true;
		ParticulaFree.transform.position = this.transform.position+posicionAdicional;
		ParticulaPlayer.SetActive (false);
		ParticulaFree.SetActive (true);
	}

	void KeyDelete(){
		if (ContadorInstrucciones > 0) {
			SCarrow.DeleteArrow ();
			ListaAcumuladorInstrucciones.RemoveAt (ListaAcumuladorInstrucciones.Count - 1);
			ContadorInstrucciones--;
			int temporal = int.Parse (numberOfPases.text) + 1;
			numberOfPases.text = temporal.ToString ();
		}
	}

	void crear_cubos(){
		if(ListaInstrucciones.Count==0){
			EnEjecucionComandos=false;
		}
		if (EnEjecucionComandos == false) {
			if (Input.GetMouseButtonDown (1)) {
				KeyDelete ();
			} else if (Input.GetKeyDown ("space") ) {
				KeySpace ();
			} else if (Input.GetKeyDown ("w") || Input.GetKeyDown ("up")) {
				KeyDirections ('w');
			} else if (Input.GetKeyDown ("s") || Input.GetKeyDown ("down")) {
				KeyDirections ('s');
			} else if (Input.GetKeyDown ("a") || Input.GetKeyDown ("left")) {
				KeyDirections ('a');
			} else if (Input.GetKeyDown ("d") || Input.GetKeyDown ("right")) {
				KeyDirections ('d');				}
			} else {
				if (Input.GetMouseButtonDown (1)) {
					KeyDelete ();
				} else if (Input.GetKeyDown ("space")) {
					KeySpace ();
				}	
			}
	}
		
	void play(){
		if (ListaInstrucciones.Count > 0) {
			if (n_activador == 1) {
				cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.position = P_I_P_segundo.transform.position + ListaInstrucciones [0];
				P_I_P_segundo.transform.position = cube.transform.position;
				cube.GetComponentInChildren<Renderer> ().enabled = false;
				n_activador = 0;
			}
			diferenciaDistancia = this.transform.position - cube.transform.position;
			CuadradosDiferenciaDistancia = diferenciaDistancia.sqrMagnitude;
			navmesh.destination = cube.transform.position;

			if (CuadradosDiferenciaDistancia <= 0.2f) {
				int temporal = int.Parse(numberOfPases.text)+1;

				numberOfPases.text = temporal.ToString();

				ContadorListaInstrucciones++;
				ListaInstrucciones.RemoveAt (0);

				n_activador = 1;

				if (ContadorListaInstrucciones == begin) {
					ParticulaPlayer.SetActive (true);
					ParticulaFree.SetActive (false);
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
		if(target.tag=="inicio"){
			arriba = false;
			numberOfPases.text = "10";
			eliminar_instrucionnes ();
			P_I_P_segundo.transform.position =PosicionInicial;
			jugador.position = PosicionInicial;
			navmesh.destination = PosicionInicial;	
			//->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			for(int y = 0; y < Parent.transform.childCount; y++){
				Destroy(Parent.transform.GetChild(y).gameObject);
			}
			SCarrow.ClearCsArrow ();
			ParticulaFree.transform.position =jugador.position+posicionAdicional;
			ParticulaPlayer.SetActive (true);
			ParticulaFree.SetActive (false);

		}
	}

////////////////////////////////////////////
	public void Up (){
		KeyDirections ('w');
	}

	public void Down (){
		KeyDirections ('s');
	}

	public void Left (){
		KeyDirections ('a');
	}

	public void Right (){
		KeyDirections ('d');
	}

	public void Back (){
		if (ContadorInstrucciones > 0) {
			KeyDelete ();
		}
	}

	public void Enter (){
		KeySpace ();
	}


}