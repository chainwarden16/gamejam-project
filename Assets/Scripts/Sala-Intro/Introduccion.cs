using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Introduccion : MonoBehaviour
{
    public GameObject papelInstrucciones;
    public GameObject botonLeer;

    private void Start()
    {
        papelInstrucciones.SetActive(false);
    }

    public void EmpezarEscapeRoom()
    {
        Initiate.Fade("Sala1", Color.black, 1f);
    }

    public void LeerPapel()
    {
        botonLeer.SetActive(false);
        papelInstrucciones.SetActive(true);
        papelInstrucciones.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        Canvas.ForceUpdateCanvases();
    }

    public void CerrarPapel()
    {
        DestroyImmediate(papelInstrucciones.gameObject);
        DestroyImmediate(botonLeer.gameObject);
        Canvas.ForceUpdateCanvases();
    }

}
