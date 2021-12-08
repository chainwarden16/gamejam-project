using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuecoPieza : MonoBehaviour
{
    public int hueco;
    Puzle8 puzle;

    private void Start()
    {
        puzle = FindObjectOfType<Puzle8>();
    }

    private void OnMouseDown()
    {
        PiezaJigsaw pie = puzle.GetPiezaSeleccionada();

        if (pie != null)
        {

            if (puzle.GetPiezasColocadas()[hueco] == null)
            {
                pie.gameObject.transform.position = gameObject.transform.position;
                puzle.GetPiezasColocadas()[hueco] = pie.gameObject;
                pie.SetHuecoActual(hueco, gameObject.GetComponent<BoxCollider>());
                puzle.DeseleccionarPieza();
                puzle.ComprobarEstadoPuzle();
            }


        }
    }
}
