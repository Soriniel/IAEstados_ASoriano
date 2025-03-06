using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Estado;

public class AtacarEnemigo : Estado

{
    public AtacarEnemigo(EnemigoIA enemigo) : base()

    {
        Debug.Log("ATACARENEMIGO");
        nombre = ESTADO.ATACARENEMIGO;
        inicializarVariables(enemigo);
    }

    public override void Entrar()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAA");
        enemigoIA.transform.localScale = new Vector3(4f, 4f, 4f);
        animator.SetBool("Ataque", true);
        // Le pondríamos la animación de disparar, o lo que sea...
        base.Entrar();
    }

    public override void Actualizar()
    {
        enemigoIA.transform.LookAt(enemigoIA.seguirenemigo);
        Vector3 direction = enemigoIA.enemigo.transform.position - enemigoIA.aliado.transform.position;
        enemigoIA.aliado.transform.position += direction.normalized * 4f * Time.deltaTime;
    }

    public override void Salir()
    {
        // Le resetearíamos la animación de disparar, detener las corrutinas, o lo que sea...
        base.Salir();
    }
}
