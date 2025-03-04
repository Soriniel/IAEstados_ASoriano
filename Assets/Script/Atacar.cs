using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;


public class Atacar : Estado
{
    public GameObject jugador;
    public GameObject aliado;
    public Atacar(EnemigoIA enemigo) : base()
    {
        Debug.Log("ATACAR");
        jugador = GameObject.FindWithTag("Player");
        aliado = GameObject.FindWithTag("Aliade");
        nombre = ESTADO.ATACAR;
        inicializarVariables(enemigo);
    }

    public override void Entrar()
    {
        // Le pondríamos la animación de disparar, o lo que sea...
        base.Entrar();
    }

    public override void Actualizar()
    {

        Vector3 direction = jugador.transform.position - aliado.transform.position;
        aliado.transform.position += direction.normalized * 4f * Time.deltaTime;
        if (PuedeAtacar())
        {
            siguienteEstado = new Vigilar(enemigoIA); // Se pasa la referencia de enemigoIA
            faseActual = EVENTO.SALIR;
        }
    }

    public override void Salir()
    {
        // Le resetearíamos la animación de disparar, detener las corrutinas, o lo que sea...
        base.Salir();
    }








    public bool PuedeAtacar()
    {
        // ...
        return false; // El NPC NO ESTÁ lo suficientemente cerca para atacar al jugador.
    }
}