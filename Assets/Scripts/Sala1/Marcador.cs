using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marcador : MonoBehaviour
{

    public int numeroMarcador;
    Puzle1 puzle;

    private void Start()
    {
        puzle = FindObjectOfType<Puzle1>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && puzle != null)
        {
            puzle.SetMarcadorActivado(numeroMarcador);
            puzle.SetPosicionBolaInicio();
            puzle.MostrarCombinacion();
        }
    }
}
