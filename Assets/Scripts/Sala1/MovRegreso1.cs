using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MovRegreso1 : MonoBehaviour
{
    int nivelPosicion;

    public GameObject nivel0, nivel1, nivel2, nivel3;
    public GameObject botonAtras;
    DesplSala1 desplazamiento;
    Camera camara;
    public Button boton;
    public Button abrirPuzle1, abrirPuzle2, abrirPuzle3;

    private void Start()
    {
        camara = Camera.main;
        
        desplazamiento = FindObjectOfType<DesplSala1>();
    }

    public void SetNivelPosicion(int posicionNueva)
    {

        nivelPosicion = posicionNueva;
        if(nivelPosicion > 0 && boton != null)
        {
            boton.interactable = true;
            boton.image.color = new Color(1, 1, 1, 1);
        }

    }

    public int GetPosicionNueva()
    {
        return nivelPosicion;
    }

    public void RegresarAtras()
    {
        
        List<Button> botonesSala = desplazamiento.GetBotonesSala();
        switch (nivelPosicion)
        {
            case 1:
                if (nivel0 != null)
                {
                    if (boton != null)
                    {

                        boton.interactable = false;
                        boton.image.color = new Color(1, 1, 1, 0.5f);
                        
                        for(int i = 0; i < botonesSala.Count-1; i++)
                        {
                            botonesSala[i].interactable = true;
                        }
                        abrirPuzle1.interactable = false;
                        abrirPuzle2.interactable = false;
                        abrirPuzle3.interactable = false;

                    }

                    camara.transform.position = nivel0.transform.position;
                    camara.transform.rotation = nivel0.transform.rotation;

                }
                break;
            case 2:
                if (nivel1 != null)
                {

                    camara.transform.position = nivel1.transform.position;
                    camara.transform.rotation = nivel1.transform.rotation;
                    botonesSala[botonesSala.Count - 1].interactable = true;
                }

                break;
            case 3:
                if (nivel3 != null)
                {

                    camara.transform.position = nivel2.transform.position;
                    camara.transform.rotation = nivel2.transform.rotation;

                }
                break;


        }
        nivelPosicion--;
    }

}
