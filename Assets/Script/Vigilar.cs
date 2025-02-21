using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Constructor para VIGILAR
public class Vigilar : Estado
{
    public Vigilar(EnemigoIA enemigo) : base()
    {
        Debug.Log("VIGILAR");
        nombre = ESTADO.VIGILAR;
        inicializarVariables(enemigo);
    }

    public override void Entrar()
    {
        // Le pondríamos la animación de andar, calcular los puntos por los que patrulla, etc...

        base.Entrar();
    }

    public override void Actualizar()
    {
        // Le decimos que se vaya moviendo y patrullando...

        if (PuedeVerJugador())
        {
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
        // ...        
        return false; // DE MOMENTO NO
    }
}

