using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaJigsaw : MonoBehaviour
{
    public int indice;
    [SerializeField]
    int indiceHueco;
    [SerializeField]
    BoxCollider hueco;
    Vector3 posicionOriginal;

    Puzle8 puzle;

    private void Start()
    {
        indiceHueco = -1;
        posicionOriginal = transform.position;
        puzle = FindObjectOfType<Puzle8>();
    }

    public int GetIndice()
    {
        return indice;
    }


    public void SetHuecoActual(int huecoNuevo, BoxCollider collider)
    {
        indiceHueco = huecoNuevo;
        hueco = collider;
    }

    public int GetHuecoIndiceActual()
    {
        return indiceHueco;
    }


    public void RegresarPieza()
    {
        gameObject.transform.position = posicionOriginal;
    }

    public void CambiarPosicionOriginal(Vector3 nuevaPosicion)
    {
        posicionOriginal = nuevaPosicion;
    }

    private void OnMouseOver()
    {

        if (!puzle.GetEstaResuelto())
        {

            if (Input.GetButtonDown("Fire1"))
            {

                if (puzle.GetPiezaSeleccionada() == null)
                {
                    puzle.SeleccionarPieza(this);
                }

                else if (puzle.GetPiezaSeleccionada() == this)
                {
                    if (indiceHueco >= 0)
                    {

                        puzle.GetPiezasColocadas()[indiceHueco] = gameObject;
                    }

                    puzle.DeseleccionarPieza();
                    puzle.ComprobarEstadoPuzle();
                }

            }



        }

    }

}
