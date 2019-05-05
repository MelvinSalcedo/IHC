using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptArrow : MonoBehaviour {
	[Header("Parent")]
	public GameObject Parent;
	[Header("Arrows material")]
	public Material mt_arrowBlue;
	public Material mt_arrowRed;
	/*public Material mt_down;
	public Material mt_left;
	public Material mt_right;*/

	[Header("DistanciaPasos")]
	public float numero_pasos_dados = 2.00f;

	[Header("Player")]
	public Transform jugador;


	// PRIVATE
	[HideInInspector]
	public int ContadorInstrucciones = 0;
	private Vector3 PosicionInicial;

	private GameObject ArrowSequence;

	// Direccionales 
	// Listas 
	[HideInInspector]
	public List<char> ListaPosiciones = new List<char>();
	[HideInInspector]
	public List<GameObject> ListaAcumuladorInstruccionesMT= new List<GameObject>();

	private GameObject temp;
	[HideInInspector]
	public Vector3 LP;

	[HideInInspector]
	public bool BoolPermitirPressBotonos;

	void Start () {
		BoolPermitirPressBotonos = true;
		LP = this.transform.position;
	}

	public void CreatePlane(Vector3 LastPosition,Material mt){
		
		ArrowSequence = GameObject.CreatePrimitive(PrimitiveType.Plane);
		ArrowSequence.transform.position = LastPosition;
		ArrowSequence.transform.localScale= new Vector3(0.23034f,0.2f,0.23034f);
		ArrowSequence.transform.position =new Vector3(LastPosition.x,-0.726f,LastPosition.z);
		ArrowSequence.GetComponent<Renderer>().material = mt;
		PosicionInicial = this.transform.position;
		//ArrowSequence.gameObject.AddComponent<BoxCollider>(1,1,1,);
		ArrowSequence.transform.parent = Parent.transform.transform;
		ArrowSequence.gameObject.tag = "pared";
	}
		
	void Update(){
		crear_cubos ();
	}
	void crear_cubos(){
		if (BoolPermitirPressBotonos == true) {
			if (ContadorInstrucciones < 10) {
				if (Input.GetMouseButtonDown (1)) {
					if (ContadorInstrucciones > 0) {
						ContadorInstrucciones--;
						int children = Parent.transform.childCount;
						Destroy (Parent.transform.GetChild (children - 1).gameObject);

						if (ListaPosiciones [ListaPosiciones.Count - 1] == 'w') {
							LP -= new Vector3 (numero_pasos_dados, 0, 0);
						} else if (ListaPosiciones [ListaPosiciones.Count - 1] == 's') {
							LP -= new Vector3 (-numero_pasos_dados, 0, 0);
						} else if (ListaPosiciones [ListaPosiciones.Count - 1] == 'a') {
							LP -= new Vector3 (0, 0, numero_pasos_dados);
						} else if (ListaPosiciones [ListaPosiciones.Count - 1] == 'd') {
							LP -= new Vector3 (0, 0, -numero_pasos_dados);
						}
						ListaPosiciones.RemoveAt (ListaPosiciones.Count - 1);



					}
				} else if (Input.GetKeyDown ("w")) {
					LP += new Vector3 (numero_pasos_dados, 0, 0);
					CreatePlane (LP, mt_arrowBlue);
					ContadorInstrucciones++;
					ListaPosiciones.Add ('w');

				} else if (Input.GetKeyDown ("s")) {
					LP += new Vector3 (-numero_pasos_dados, 0, 0);
					CreatePlane (LP, mt_arrowBlue);
					ContadorInstrucciones++;
					ListaPosiciones.Add ('s');

				} else if (Input.GetKeyDown ("a")) {
					LP += new Vector3 (0, 0, numero_pasos_dados);
					CreatePlane (LP, mt_arrowBlue);
					ContadorInstrucciones++;
					ListaPosiciones.Add ('a');

				} else if (Input.GetKeyDown ("d")) {
					LP += new Vector3 (0, 0, -numero_pasos_dados);
					CreatePlane (LP, mt_arrowBlue);
					ContadorInstrucciones++;
					ListaPosiciones.Add ('d');

				} else if (Input.GetKeyDown ("space")&&ContadorInstrucciones>0) {
					BoolPermitirPressBotonos = false;
					ListaPosiciones.Clear ();
					ContadorInstrucciones = 0;
					
				}
			} else {
				if (Input.GetMouseButtonDown (1)) {
					if (ContadorInstrucciones > 0) {
						if (ContadorInstrucciones > 0) {
							ContadorInstrucciones--;
							int children = Parent.transform.childCount;
							Destroy (Parent.transform.GetChild (children - 1).gameObject);

							if (ListaPosiciones [ListaPosiciones.Count - 1] == 'w') {
								LP -= new Vector3 (numero_pasos_dados, 0, 0);
							} else if (ListaPosiciones [ListaPosiciones.Count - 1] == 's') {
								LP -= new Vector3 (-numero_pasos_dados, 0, 0);
							} else if (ListaPosiciones [ListaPosiciones.Count - 1] == 'a') {
								LP -= new Vector3 (0, 0, numero_pasos_dados);
							} else if (ListaPosiciones [ListaPosiciones.Count - 1] == 'd') {
								LP -= new Vector3 (0, 0, -numero_pasos_dados);
							}
							ListaPosiciones.RemoveAt (ListaPosiciones.Count - 1);
						}
					}
				} else if (Input.GetKeyDown ("space") && ContadorInstrucciones>0) {
					ListaPosiciones.Clear ();
					ContadorInstrucciones = 0;
					BoolPermitirPressBotonos = false;

				}
			}
	
		}
			
	}
}
