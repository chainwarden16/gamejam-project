using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Libro : MonoBehaviour
{

    public LibroScriptable libro;
    Puzle2 puzle2;

    private void Start()
    {
        puzle2 = FindObjectOfType<Puzle2>();
    }

    public void SetDatosLibro(LibroScriptable book)
    {
        libro = book;
    }

    public LibroScriptable GetDatosLibro()
    {
        return libro;
    }

    private void OnMouseDown()
    {
        if (!puzle2.ComprobarSiEstaResuelto())
        {

            puzle2.SeleccionarLibro(gameObject);

        }
    }

}
