using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ScriptArrow : MonoBehaviour {
	[Header("Fungus")]
	public Flowchart fc;
	[Header("GameObject whit script VarGlobals")]
	public GameObject GameObjectVarGlobals;
	private VariablesGlobales cs_VarGlobals;

	[Header("Parent")]
	public GameObject Parent;

	[Header("Arrows material")]
	public Material[] mt_arrowBlue;
	public Material mt_arrowRed;

	[Header("DistanciaPasos")]
	public float numero_pasos_dados = 2.00f;

	[Header("Player")]
	public Transform jugador;

	//>>>>>>>>>>>>>>>>>>>>>>><
	[HideInInspector]
	public AudioSource  source;
	[Header("sound")]
	public AudioClip clip_pressButton;
	//>>>>>>>>>>>>>>>>>>>>>>

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
	public int NumberArrow=0;



	private int InstruccionPlayDeleteOneShot = 0;

	void Start () {
		source = GetComponent<AudioSource> ();
		LP = this.transform.position;
		GameObjectVarGlobals = GameObject.FindWithTag ("VariablesGlobales");
		cs_VarGlobals = GameObjectVarGlobals.GetComponent<VariablesGlobales> ();

	}

	public void ClearCsArrow(){
		ListaPosiciones.Clear ();
		cs_VarGlobals.Bool_PermitirPressBotonos = true;
		ContadorInstrucciones=0;
		NumberArrow = 0;
		LP = transform.position;
		fc.ExecuteBlock ("chocar");
	}

	public void reproducirSonido(){
		source.PlayOneShot (clip_pressButton);
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

	public void GnerateImageArrow(char Key,Vector3 NumpasosDados)	{
		reproducirSonido ();
		if (NumberArrow < mt_arrowBlue.Length) {
			
			if (InstruccionPlayDeleteOneShot == 1) {
				fc.ExecuteBlock ("eliminar");
				InstruccionPlayDeleteOneShot = -1;
			}
			else if (InstruccionPlayDeleteOneShot == 0) {
				fc.ExecuteBlock ("play");

			}

			LP += NumpasosDados;
			CreatePlane (LP, mt_arrowBlue [NumberArrow]);
			ContadorInstrucciones++;
			fc.ExecuteBlock (ContadorInstrucciones.ToString());
			ListaPosiciones.Add (Key);
			NumberArrow++;
		}
	}

	public void DeleteArrow(){
		int children = Parent.transform.childCount;
		reproducirSonido ();
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
		ContadorInstrucciones--;
		NumberArrow--;

	}

	public void UpAqrrow(){
		Vector3 N= new Vector3 (numero_pasos_dados, 0, 0);
		GnerateImageArrow ('w',N);
	}

	public void DownAqrrow(){
		Vector3 N=new Vector3 (-numero_pasos_dados, 0, 0);
		GnerateImageArrow ('s',N);
	}

	public void RightAqrrow(){
		Vector3 N= new Vector3 (0, 0, -numero_pasos_dados);
		GnerateImageArrow ('d',N);
	}

	public void LeftAqrrow(){
		Vector3 N= new Vector3 (0, 0, numero_pasos_dados);
		GnerateImageArrow ('a',N);
	}

	public void SpaceArrow(){
		reproducirSonido ();
		if (InstruccionPlayDeleteOneShot == 0) {
			InstruccionPlayDeleteOneShot = 1;

		}

		NumberArrow = 0;
		cs_VarGlobals.Bool_PermitirPressBotonos = false;
		ListaPosiciones.Clear ();
		NumberArrow = 0;
		ContadorInstrucciones = 0;
	}
}
