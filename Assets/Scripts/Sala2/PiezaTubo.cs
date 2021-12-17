using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaTubo : MonoBehaviour
{
    [SerializeField]
    int estadoGiro = 1; //0 = recto, 1 = giro a la derecha, 2 = bocabajo, 3 = giro a la izquierda. Todas las piezas empiezan por defecto en 1 (mirando a la derecha)
    Puzle5 puzle;

    private void Start()
    {
        puzle = FindObjectOfType<Puzle5>();
        estadoGiro = 1;
    }

    public void GirarPieza()
    {
        gameObject.transform.Rotate(0, 0, -90);
        SetEstadoGiro();
        puzle.ComprobarEstadoPuzle();
    }

    public int GetEstadoGiro()
    {
        return estadoGiro;
    }

    public void SetEstadoGiro()
    {
        if (estadoGiro < 3)
        {
            estadoGiro++;
        }
        else
        {
            estadoGiro = 0;
        }
    }

    private void OnMouseDown()
    {
        if (!puzle.HaResueltoPuzle())
        {
            GirarPieza();
        }
        else
        {
            Debug.Log("Puzle 5 resuelto");
        }
    }

    private void OnMouseOver()
    {
        //Debug.Log("Estoy sobre la pieza "+gameObject.name+" que tiene estadoGiro "+estadoGiro);
    }

}
