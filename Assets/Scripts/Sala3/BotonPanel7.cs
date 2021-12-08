using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotonPanel7 : MonoBehaviour
{
    public int numeroAPulsar;

    public TextMeshProUGUI textoPantalla;

    Puzle7 puzle;

    private void Start()
    {
        puzle = FindObjectOfType<Puzle7>();
    }

    public void EscribirNumero()
    {
        if (textoPantalla.text.Length < 7 && !puzle.EstaResuelto())
        {
            textoPantalla.text += numeroAPulsar;
            puzle.ComprobarEstadoPuzle();
        }
    }


    public void BorrarTexto()
    {
        if (!puzle.EstaResuelto())
            textoPantalla.text = "";
    }

    public void BorrarUnCaracter()
    {
        if (textoPantalla.text != "" && !puzle.EstaResuelto())
        {
            textoPantalla.text = textoPantalla.text.Remove(textoPantalla.text.Length-1, 1);
        }
        else
        {
            Debug.Log("Está resuelto el puzle 7.");
        }
    }

}
