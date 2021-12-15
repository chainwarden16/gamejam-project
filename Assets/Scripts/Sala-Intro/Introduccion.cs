using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Introduccion : MonoBehaviour
{
    public GameObject papelInstrucciones;
    public GameObject botonLeer;
    public GameObject salida;

    Camera camaraPrincipal;

    bool haLeido = false;

    private void Start()
    {
        papelInstrucciones.SetActive(false);
        salida.GetComponent<Button>().interactable = false;
        salida.SetActive(false);
        camaraPrincipal = Camera.main;
    }

    public void EmpezarEscapeRoom()
    {
        Initiate.Fade("Sala1", Color.black, 1f);
    }

    public void LeerPapel()
    {
        if (!haLeido)
        {
            botonLeer.GetComponent<Button>().interactable = false;
            botonLeer.SetActive(false);
            papelInstrucciones.SetActive(true);
            papelInstrucciones.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            Canvas.ForceUpdateCanvases();
            haLeido = true;
            salida.SetActive(true);
            salida.GetComponent<Button>().interactable = true;
            camaraPrincipal.transform.position = new Vector3(-3.6f, -0.8f, -10.28f);
            camaraPrincipal.transform.Rotate(0, 45, 0);

        }

    }

    public void CerrarPapel()
    {
        papelInstrucciones.SetActive(false);
        botonLeer.SetActive(false);
        Canvas.ForceUpdateCanvases();
    }


}
