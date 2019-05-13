using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMesh : MonoBehaviour {

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

	void Start(){
		skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

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
		if (sc_P1.SectionCritic == 1) {
			StartCoroutine (Scale ());
		}
	}


	IEnumerator Scale(){
		while(0.5f < transform.localScale.x){
			transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * 5.0f;
			yield return null;
		}
		yield return new WaitForSeconds(0.0f);
		Destroy (this.gameObject);

	}

}
