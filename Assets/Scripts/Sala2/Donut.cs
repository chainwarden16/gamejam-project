using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    public int size;
    Puzle6 puzle;
    public Varilla varilla;
    Vector2 posicionOriginal; //por si se mueve a una zona no válida

    public Varilla VarillaMasProxima { get => varilla; set => varilla = value; }
    public Vector2 PosicionOriginal { get => posicionOriginal; set => posicionOriginal = value; }

    private void Start()
    {
        puzle = FindObjectOfType<Puzle6>();
    }

    public int GetSize()
    {
        return size;
    }

    public Varilla GetVarilla()
    {
        return varilla;
    }

    public void SetVarilla(Varilla vari)
    {
        varilla = vari;
    }

    private void OnMouseOver()
    {

        puzle = FindObjectOfType<Puzle6>();

        if (puzle.ComprobarSePuedeMoverDisco() && !puzle.HaResueltoPuzle())
        {

            if (Input.GetButtonDown("Fire1"))
            {
                if (puzle.GetDiscoSeleccionado() == null && varilla.ComprobarRetirarDisco(this))
                {

                    puzle.SeleccionarDisco(this);

                    varilla.RetirarDisco(this);

                }

                else if(puzle.GetDiscoSeleccionado() == this)
                {
                    varilla.DepositarDisco();
                }
                else
                {
                    Debug.Log(puzle.GetDiscoSeleccionado());
                    Debug.Log(varilla.ComprobarRetirarDisco(this));
                }


            }


        }
        else
        {
            Debug.Log("Comprobar se puede mover disco es: " + puzle.ComprobarSePuedeMoverDisco() + ", y HaResueltoPuzle es: " + puzle.HaResueltoPuzle());
        }
    }

}
