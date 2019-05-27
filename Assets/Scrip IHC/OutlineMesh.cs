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

	private Animator anim;

	private GameObject objVariableGlobales;
	private VariablesGlobales VarGlobals;
	private int numberClickThisScript = new int();
	private bool St_Courrutine = false;
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
			if (St_Courrutine == false) {
				StartCoroutine (Timer ());
				St_Courrutine = true;
			}

			if (obj != null) {
				Destroy (obj);
			}
		}
	}

	void OnMouseOver()
	{
		if (VarGlobals.SectionCritic == 1) {
			skinnedMeshRenderer.material = mt_outline;
		}

	}

	void OnMouseExit()
	{	
		if (VarGlobals.SectionCritic == 1) {
			skinnedMeshRenderer.material = mt_real;
		}
	}

	void OnMouseDown ()
	{

		if (numberClickThisScript == 0) {
			
			if (VarGlobals.SectionCritic == 1 && VarGlobals.I_CountFishesClicked < 3) {
				fc.ExecuteBlock ("Alerta");
				VarGlobals.countFishesClicked ();
			}
		}
		numberClickThisScript++;
	}

	IEnumerator Timer(){
		/*while(0.5f < transform.localScale.x){
			transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * 5.0f;
			yield return null;
		}*/
		yield return new WaitForSeconds(5.0f);
		Destroy (this.gameObject);
	}
}
