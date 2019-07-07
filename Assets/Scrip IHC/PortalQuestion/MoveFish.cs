using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class MoveFish : MonoBehaviour {
	[Header("FC")]
	public Flowchart fc;

	[Header("Material Real")]
	public Material mt_real;

	[Header("Material Outline")]
	public Material mt_outline;

	[Header("skinnedMeshRenderer")]
	public SkinnedMeshRenderer skinnedMeshRenderer;
	public Transform FinalPosition;
	private Animator anim;
	private GameObject objVariableGlobales;
	private VariablesGlobales VarGlobals;
	private int SectionCritic=0;
	private UnityEngine.AI.NavMeshAgent navmesh;
	void Start(){
		anim = GetComponent<Animator> ();
		objVariableGlobales = GameObject.Find ("Main Character");
		VarGlobals = objVariableGlobales.GetComponent<VariablesGlobales> ();
		skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
		navmesh = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}


	void OnMouseOver()
	{
		if (SectionCritic == 0) {
			skinnedMeshRenderer.material = mt_outline;
		}

	}

	void OnMouseExit()
	{	
		if (SectionCritic == 0) {
			skinnedMeshRenderer.material = mt_real;
		}
	}

	void OnMouseDown ()
	{
		skinnedMeshRenderer.material = mt_outline;
		SectionCritic = 1;
		skinnedMeshRenderer.material = mt_real;
		navmesh.destination = FinalPosition.position;
	}
	void OnTriggerEnter(Collider col){
		print ("______");
		if (col.tag == "pez") {
			VarGlobals.ContadorPecesEncerrados++;
			print (VarGlobals.ContadorPecesEncerrados);
			if (VarGlobals.ContadorPecesEncerrados == 4 ) {
				fc.ExecuteBlock ("PortalQuestion1");
			}
			if (VarGlobals.ContadorPecesEncerrados == 8 ) {
				fc.ExecuteBlock ("PortalQuestion2");
			}
		}
	}

}
