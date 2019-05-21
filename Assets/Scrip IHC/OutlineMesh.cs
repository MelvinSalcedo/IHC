using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class OutlineMesh : MonoBehaviour {
	

	[Header("Flowchart General")]
	public Flowchart fc;
	[Header("Pase al siguiente nivel")]
	public GameObject obj;

	[Header("Abrir nivel 2")]
	public Animator anim_;
	[Header("Material Real")]
	public Material mt_real;

	[Header("Material Outline")]
	public Material mt_outline;

	[Header("skinnedMeshRenderer")]
	public SkinnedMeshRenderer skinnedMeshRenderer;

	[Header("Numero de Pez")]
	public int NumeroPez;

	[Header("Script OutlineMesh")]
	public Pregunta1 sc_P1;


	private Animator anim;

	private GameObject objVariableGlobales;
	private VariablesGlobales VarGlobals;
	private int numberClickThisScript = new int();
	void Start(){
		
		objVariableGlobales = GameObject.Find ("Main Character");
		VarGlobals = objVariableGlobales.GetComponent<VariablesGlobales> ();

		anim = GetComponent<Animator> ();

		skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

	}
	void Update(){
		
		if (VarGlobals.I_CountFishesClicked < 3) {
		} 
		else {
			anim.SetBool ("Walk",true);
			anim_.enabled = true;
			if (obj != null) {
				Destroy (obj);
			}
		}

	}

	void OnMouseOver()
	{
		if (sc_P1.SectionCritic == 1) {
			skinnedMeshRenderer.material = mt_outline;
		}

	}

	void OnMouseExit()
	{	if (sc_P1.SectionCritic == 1) {
			skinnedMeshRenderer.material = mt_real;
		}
	}

	void OnMouseDown ()
	{

		if (numberClickThisScript == 0) {
			if (sc_P1.SectionCritic == 1 && VarGlobals.I_CountFishesClicked < 3) {
				fc.ExecuteBlock ("Alerta");
				VarGlobals.countFishesClicked ();
				StartCoroutine (Scale ());
			}
		}
		numberClickThisScript++;
	}


	IEnumerator Scale(){
		while(0.5f < transform.localScale.x){
			transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * 5.0f;
			yield return null;
		}

		yield return new WaitForSeconds(0.0f);
		//Destroy (this.gameObject);
		//this.gameObject.rende

	}

}
