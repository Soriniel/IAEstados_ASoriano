using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

// Constructor para VIGILAR
public class Vigilar : Estado
{
    public Color morado = Color.magenta;
    public GameObject jugador;

    public Vigilar(EnemigoIA enemigo) : base()
    {
        jugador = GameObject.FindWithTag("Player");
        aliado = GameObject.FindWithTag("Aliade");
        Debug.Log("VIGILAR");
        nombre = ESTADO.VIGILAR;
        inicializarVariables(enemigo);

    }

    public override void Entrar()
    {
        enemigoIA.GetComponent<Renderer>().material.color = morado;
        animator.SetBool("Caminar", false);
        // Le pondríamos la animación de andar, calcular los puntos por los que patrulla, etc...

        base.Entrar();
    }

    public override void Actualizar()
    {
        // Le decimos que se vaya moviendo y patrullando...
        if (PuedeVerJugador())
        {            
            animator.SetBool("Caminar", true);
            Debug.Log("Te sigo Rey");
            siguienteEstado = new Atacar(enemigoIA); // Se pasa la referencia de enemigoIA
            faseActual = EVENTO.SALIR;
        }
    }

    public override void Salir()
    {
        // Le resetearíamos la animación de andar, detener las corrutinas, o lo que sea...
        base.Salir();
    }

    // Puede el NPC ver el jugador?
    public bool PuedeVerJugador()
    {
        Debug.Log("NO TE VEOOOO");
        if (Vector3.Distance(aliado.transform.position, jugador.transform.position) <= 10f)
        {
            return true;
        }
            // ...        
            return false; // DE MOMENTO NO
    }
}

