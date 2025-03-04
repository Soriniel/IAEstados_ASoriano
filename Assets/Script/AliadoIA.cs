using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  // Added since we're using a navmesh.

public class EnemigoIA: MonoBehaviour
{
    Estado FSM;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.magenta;
        FSM = new Vigilar(this); // Ahora se le pasa el EnemigoIA al constructor
    }

    void Update()
    {
        FSM = FSM.Procesar(); // INICIAMOS LA FSM
    }
}