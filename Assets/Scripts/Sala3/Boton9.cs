using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton9 : MonoBehaviour
{
    public int numeroAPulsar;

    Puzle9 puzle;

    private void Start()
    {
        puzle = FindObjectOfType<Puzle9>();
    }

    public void Pulsar()
    {
        if (!puzle.GetEstaResuelto())
        {
            puzle.PresionarBoton(numeroAPulsar);
            puzle.ComprobarEstadoPuzle();
        }
        else
        {
            Debug.Log("Meeeeeec, ¡error! ¡Ya está resuelto!");
        }
    }


}
