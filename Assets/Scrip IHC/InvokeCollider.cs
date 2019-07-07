using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class InvokeCollider : MonoBehaviour {

    // Use this for initialization
    public Transform PosInicial;

    private GameObject GameObjectVarGlobals;
    private VariablesGlobales cs_VarGlobals;

    void Start () {
        GameObjectVarGlobals = GameObject.FindWithTag("VariablesGlobales");
        cs_VarGlobals = GameObjectVarGlobals.GetComponent<VariablesGlobales>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jugador") {
            cs_VarGlobals.SeeYat(PosInicial);
            this.gameObject.SetActive(false);
        }
    }
}
