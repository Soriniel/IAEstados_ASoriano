using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


public class Atacar : Estado
{
    public Color azul = Color.blue;
    public Atacar(EnemigoIA enemigo) : base()
    {
        Debug.Log("ATACAR");
        nombre = ESTADO.ATACAR;
        inicializarVariables(enemigo);
    }

    public override void Entrar()
    {
        enemigoIA.transform.localScale = new Vector3(2f, 2f, 2f);
        enemigoIA.GetComponent<Renderer>().material.color = azul;
        // Le pondríamos la animación de disparar, o lo que sea...
        base.Entrar();
    }

    public override void Actualizar()
    {

        Vector3 direction = enemigoIA.jugador.transform.position - enemigoIA.aliado.transform.position;
        enemigoIA.aliado.transform.position += direction.normalized * 4f * Time.deltaTime;
        enemigoIA.transform.LookAt(enemigoIA.seguir);

        if (Vector3.Distance(enemigoIA.aliado.transform.position, enemigoIA.jugador.transform.position) >= 10)
        {
            enemigoIA.transform.localScale = new Vector3(1f, 1f, 1f);
            siguienteEstado = new Vigilar(enemigoIA); // Se pasa la referencia de enemigoIA
            faseActual = EVENTO.SALIR;
        }

        if (PuedeAtacar())
        {
            siguienteEstado = new AtacarEnemigo(enemigoIA); // Se pasa la referencia de enemigoIA
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
        if (Vector3.Distance(enemigoIA.aliado.transform.position, enemigoIA.enemigo.transform.position) <= 10f)
        {
            return true;
        }
        // ...
        return false; // El NPC NO ESTÁ lo suficientemente cerca para atacar al jugador.
    }
}