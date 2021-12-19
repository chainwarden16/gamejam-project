using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuzles : MonoBehaviour
{

    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void AbrirPuzle1()
    {

        if (!ComprobarSiEstaResuelto(0))
        {

            Initiate.Fade("Puzle1", Color.black, 1f);

        }

    }

    public void AbrirPuzle2()
    {

        if (!ComprobarSiEstaResuelto(1))
        {
            Initiate.Fade("Puzle2", Color.black, 1f);
        }
    }

    public void AbrirPuzle3()
    {

        if (!ComprobarSiEstaResuelto(2))
        {
            Initiate.Fade("Puzle3", Color.black, 1f);
        }
    }

    public void AbrirPuzle4()
    {

        if (!ComprobarSiEstaResuelto(3))
        {
            Initiate.Fade("Puzle4", Color.black, 1f);
        }
    }

    public void AbrirPuzle5()
    {

        if (!ComprobarSiEstaResuelto(4))
        {
            Initiate.Fade("Puzle5", Color.black, 1f);
        }
    }

    public void AbrirPuzle6()
    {

        if (!ComprobarSiEstaResuelto(5))
        {
            Initiate.Fade("Puzle6", Color.black, 1f);
        }
    }

    public void AbrirPuzle7()
    {

        if (!ComprobarSiEstaResuelto(6))
        {
            Initiate.Fade("Puzle7", Color.black, 1f);
        }
    }

    public void AbrirPuzle8()
    {

        Initiate.Fade("Puzle8", Color.black, 1f);

    }

    public void AbrirPuzle9()
    {

        if (!ComprobarSiEstaResuelto(8))
        {
            Initiate.Fade("Puzle9", Color.black, 1f);
        }
    }

    public bool ComprobarSiEstaResuelto(int indicePuzle)
    {
        bool estaHecho = false;

        if (manager != null)
        {
            if (manager.GetPuzlesResueltos()[indicePuzle])
            {
                estaHecho = true;
            }

        }

        return estaHecho;
    }

}
