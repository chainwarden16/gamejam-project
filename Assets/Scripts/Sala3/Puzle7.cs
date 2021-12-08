using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Puzle7 : MonoBehaviour
{
    public TextMeshProUGUI textoPantalla;

    bool estaResuelto;

    const string resultado = "8532110";

    public void ComprobarEstadoPuzle()
    {
        if(textoPantalla.text == resultado)
        {
            estaResuelto = true;
        }
    }

    public bool EstaResuelto()
    {
        return estaResuelto;
    }

}
