using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  // Added since we're using a navmesh.

public class EnemigoIA: MonoBehaviour
{
    Estado FSM;
    public GameObject jugador;
    public GameObject enemigo;
    public GameObject aliado;
    public Transform seguir;
    public Transform seguirenemigo;


    void Start()
    {
        enemigo = GameObject.FindWithTag("Enemigo");
        jugador = GameObject.FindWithTag("Player");
        aliado = GameObject.FindWithTag("Aliade");
        FSM = new Vigilar(this); // Ahora se le pasa el EnemigoIA al constructor
    }

    void Update()
    {
        FSM = FSM.Procesar(); // INICIAMOS LA FSM
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Debug.Log("Aliado ha tocado al enemigo. Ambos serán destruidos.");
            GameObject.Destroy(aliado);
            GameObject.Destroy(enemigo);
        }

    }
}