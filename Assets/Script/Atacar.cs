using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Atacar : Estado
{
    public Atacar(EnemigoIA enemigo) : base()
    {
        Debug.Log("ATACAR");
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

        if (!PuedeAtacar())
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