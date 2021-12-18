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

    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void ComprobarEstadoPuzle()
    {
        if (textoPantalla.text == resultado)
        {
            estaResuelto = true;
            if (manager != null)
            {

                manager.SetPuzleResuelto(6, true);

            }
        }
    }

    public bool EstaResuelto()
    {
        return estaResuelto;
    }

    public void SaltarPuzle()
    {
        estaResuelto = true;
    }

    public void CerrarPuzle7()
    {
        Initiate.Fade("Sala3", Color.black, 1f);
    }

}
