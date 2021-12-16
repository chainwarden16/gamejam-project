using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaSalidaIntro : MonoBehaviour
{

    Introduccion intro;

    private void Start()
    {
        intro = FindObjectOfType<Introduccion>();
    }

    private void OnMouseDown()
    {
        
        intro.EmpezarEscapeRoom();
    }

    private void OnMouseOver()
    {
        Debug.Log("Se puede salir");
    }
}
