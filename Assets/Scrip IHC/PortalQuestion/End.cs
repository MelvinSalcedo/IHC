using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class End : MonoBehaviour {
    [Header("Fungus")]
    public Flowchart fc;
    // Use this for initialization
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Jugador")
        {
            fc.ExecuteBlock("fin");
        }
    }
}
