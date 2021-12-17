using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MovRegreso2 : MonoBehaviour
{
    [SerializeField]
    int nivelPosicion;

    public GameObject nivel0, nivel1, nivel2, nivel3;
    public GameObject botonAtras;
    DespSala2 desplazamiento;
    Camera camara;
    public Button abrirPuzle1, abrirPuzle2, abrirPuzle3, botonMicro, botonDentroMicro, botonPuerta;
    public TextMeshProUGUI textoMicro, textoReloj;

    private void Start()
    {
        camara = Camera.main;

        desplazamiento = FindObjectOfType<DespSala2>();
    }

    public void SetNivelPosicion(int posicionNueva)
    {

        nivelPosicion = posicionNueva;
        if (nivelPosicion > 0 && botonAtras != null)
        {
            botonAtras.GetComponent<Button>().interactable = true;
            botonAtras.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
        }

    }

    public int GetPosicionNueva()
    {
        return nivelPosicion;
    }

    public void RegresarAtras()
    {



        switch (nivelPosicion)
        {
            case 1:
                if (nivel0 != null)
                {

                    botonAtras.GetComponent<Button>().interactable = false;
                    botonAtras.GetComponent<Button>().image.color = new Color(1, 1, 1, 0.5f);

                    abrirPuzle1.interactable = true;
                    abrirPuzle2.interactable = true;
                    abrirPuzle3.interactable = true;
                    botonPuerta.interactable = true;
                    botonDentroMicro.interactable = false;
                    botonMicro.interactable = true;

                    textoMicro.gameObject.SetActive(false);
                    textoReloj.gameObject.SetActive(true);

                    camara.transform.position = nivel0.transform.position;
                    camara.transform.rotation = nivel0.transform.rotation;

                }
                break;
            case 2:
                if (nivel1 != null)
                {

                    camara.transform.position = nivel1.transform.position;
                    camara.transform.rotation = nivel1.transform.rotation;

                    abrirPuzle1.interactable = false;
                    abrirPuzle2.interactable = false;
                    abrirPuzle3.interactable = false;
                    botonDentroMicro.interactable = true;
                    botonMicro.interactable = false;

                    textoMicro.gameObject.SetActive(true);
                }

                break;
            case 3:
                if (nivel3 != null)
                {

                    textoMicro.gameObject.SetActive(false);

                    camara.transform.position = nivel2.transform.position;
                    camara.transform.rotation = nivel2.transform.rotation;

                }
                break;

        }      
        
        nivelPosicion--;
    }
}
