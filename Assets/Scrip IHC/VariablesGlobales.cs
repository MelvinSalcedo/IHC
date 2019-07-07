using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class VariablesGlobales : MonoBehaviour {

	// Use this for initialization
	//[Header("Numeros")]
	//public AudtrigerCamNext;

	[Header("Flowchar")]
	public Flowchart fc;

	[Header("CmabasPeces")]
	public GameObject[] pez;

	[Header("GameObject peces")]
	public GameObject[] peces;

	[HideInInspector]
	public int contadorPez=-1;

	[HideInInspector]
	public int I_CountFishesClicked=0;

	[HideInInspector]
	public int offset = 0;

	[HideInInspector]
	public bool Bool_PermitirPressBotonos;

	[HideInInspector]
	public int SectionCritic=0;

	[HideInInspector]
	public int ContadorPecesEncerrados=0;

	public int ContadorNumeroPasos=0;
	public int NP=0;


	[HideInInspector]
	public bool EnEjecucionComandos=false;

    [HideInInspector]
    public int I_BeginPlay = 0;

    [HideInInspector]
    public int SumarPasitos = 0;

    [Header("Camaras")]
    public Transform Camara1;


    public Transform PosFinal;

    [Header("mostrar pasitos")]
    public GameObject mostrarPasitos;
    void Start(){
		Bool_PermitirPressBotonos = true;
        StartCoroutine(BeginPlay());
    }

    public void V_sumarPasitos() {
        SumarPasitos = 1;
        mostrarPasitos.SetActive(false);
    }
    public void SeeYat(Transform PosInicia)
    {
        StartCoroutine(MoveCamera(PosInicia));

    }

    public void  countFishesClicked(){
		I_CountFishesClicked++;
		if (I_CountFishesClicked == 3) {
			//trigerCamNext.SetActive (true);
		}
	}

	public void activateCamvasPez(){
		pez [contadorPez].SetActive (true);
	}

	public void moverPecesEliminar(){
		for (int i = 0; i < peces.Length; i++) {
			if (peces [i] != null) {
				
			}
		}
	}

	public void PreguntaPasos(){
		//fc.ExecuteBlock ("pasos");
	}


	public void SetEnEjecucionComandos(bool ta){
		StartCoroutine (time(ta));

	}


	public void Reintentar(string name){
		fc.ExecuteBlock (name);
	}

	IEnumerator time(bool b){
		new WaitForSeconds (1.0f);
		EnEjecucionComandos = b;
		yield return new WaitForSeconds (0.0f);
	}

    IEnumerator BeginPlay()
    {
        while (I_BeginPlay == 0)
        {
            yield return new WaitForSeconds(15.0f);
            if (I_BeginPlay == 0)
            {
                fc.ExecuteBlock("Event Begin");
            }
        }
        if (I_BeginPlay == 1)
        { 
            fc.ExecuteBlock("NotEventBegin");
        }
        
    }
    IEnumerator MoveCamera(Transform PosInicial)
    {
        while (Camara1.position != PosFinal.position)
        {
            Camara1.position = Vector3.MoveTowards(Camara1.position,
                PosFinal.position, 5 * Time.deltaTime);
            Camara1.rotation = Quaternion.Slerp(Camara1.rotation,
                PosFinal.rotation, Time.deltaTime * 1);
            yield return null;
        }
        print("sdasdsadsa");
        yield return new WaitForSeconds(3.0f);
        while (Camara1.rotation != PosInicial.rotation)
        {
            Camara1.position = Vector3.MoveTowards(Camara1.position,
                PosInicial.position, 5 * Time.deltaTime);
            Camara1.rotation = Quaternion.Slerp(Camara1.rotation,
                PosInicial.rotation, Time.deltaTime * 1);
            yield return null;
        }
        print("fin");
    }
}
