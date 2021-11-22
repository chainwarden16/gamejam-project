using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salida : MonoBehaviour
{

    Puzle1 puzle;

    private void Start()
    {
        puzle = FindObjectOfType<Puzle1>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && puzle != null)
        {
            puzle.ReiniciarMarcadores();
        }
    }
}
