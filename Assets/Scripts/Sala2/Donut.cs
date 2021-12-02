using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    public int size;
    Puzle6 puzle;
    GameObject varillaMasProxima;
    Vector2 posicionOriginal; //por si se mueve a una zona no válida

    public GameObject VarillaMasProxima { get => varillaMasProxima; set => varillaMasProxima = value; }
    public Vector2 PosicionOriginal { get => posicionOriginal; set => posicionOriginal = value; }

    private void Start()
    {
        puzle = FindObjectOfType<Puzle6>();
    }

    public bool SePuedeColocarEncima(int tamaño)
    {
        return size < tamaño;
    }

    public int GetSize()
    {
        return size;
    }



    private void OnMouseOver()
    {
        if (puzle.ComprobarSePuedeMoverDisco() && !puzle.HaResueltoPuzle())
        {
            Debug.Log("Me haces clic");
            if (Input.GetButtonDown("Fire1") && puzle.GetDiscoSeleccionado() == null)
            {
                puzle.SeleccionarDisco(this);
                Vector2 posicionRaton = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                gameObject.transform.position = posicionRaton;
            }

            if (Input.GetButton("Fire1") && puzle.GetDiscoSeleccionado() == this)
            {
                Vector2 posicionRaton = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                gameObject.transform.position = posicionRaton;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                puzle.SeleccionarDisco(null);
                //Hay que recolocar la pieza tanto en la barra correcta como en la posición de la lista (y posición física)
                
                //Se toman las varillas
                List<List<Donut>> varillas = puzle.GetEstadoVarillas();

                //Se comprueba sobre cuál se quiere colocar el donut

                

                puzle.ComprobarEstadoHanoi();
            }
        }
    }

    private void OnMouseDrag()
    {
        if (Input.GetButton("Fire1") && puzle.GetDiscoSeleccionado() == this && !puzle.HaResueltoPuzle())
        {
            Vector2 posicionRaton = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            gameObject.transform.position = posicionRaton;
        }
    }

}
