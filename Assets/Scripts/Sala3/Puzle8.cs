using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzle8 : MonoBehaviour
{
    const int sizePuzle = 24;
    [SerializeField]
    PiezaJigsaw piezaSeleccionada;

    [SerializeField]
    List<int> solucionPuzle = new List<int>() { };
    [SerializeField]
    List<GameObject> piezasColocadas = new List<GameObject>() { };

    bool estaResuelto;

    void Start()
    {
        for (int i = 0; i < sizePuzle; i++)
        {
            solucionPuzle.Add(i);
            piezasColocadas.Add(null);
        }
    }

    public void SeleccionarPieza(PiezaJigsaw pieza)
    {
        piezaSeleccionada = pieza;
        int indice = pieza.GetHuecoIndiceActual();

        if (indice >= 0)
        {

            piezasColocadas[indice] = null;
        
        }
    }

    public bool GetEstaResuelto()
    {
        return estaResuelto;
    }

    public PiezaJigsaw GetPiezaSeleccionada()
    {

        return piezaSeleccionada;

    }

    public List<GameObject> GetPiezasColocadas()
    {
        return piezasColocadas;
    }

    public void ComprobarEstadoPuzle()
    {
        bool resuelto = true;

        for (int i = 0; i < solucionPuzle.Count/2; i++)
        {

            if (piezasColocadas[i] != null)
            {
                PiezaJigsaw pieza = piezasColocadas[i].GetComponent<PiezaJigsaw>();
                if (pieza != null && pieza.GetIndice() != solucionPuzle[i])
                {
                    resuelto = false;
                    break;
                }
            }
            else
            {
                resuelto = false;
                break;
            }


        }

        estaResuelto = resuelto;
    }

    public void DeseleccionarPieza()
    {
        piezaSeleccionada = null;
    }

    public void SaltarPuzle()
    {
        estaResuelto = true;
        //aparecen las piezas ordenadas y el texto de la solucion
    }

}
