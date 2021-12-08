using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comodin : MonoBehaviour
{

    [Header("Puzles del juego que se pueden saltar")]
    Puzle4 puzle4;
    Puzle5 puzle5;
    Puzle6 puzle6;
    Puzle7 puzle7;
    Puzle8 puzle8;
    Puzle9 puzle9;

    GameObject menuConfirmacion;
    GameManager manager;
    Inventario inventario;

    void Start()
    {
        puzle4 = FindObjectOfType<Puzle4>();
        puzle5 = FindObjectOfType<Puzle5>();
        puzle6 = FindObjectOfType<Puzle6>();
        puzle7 = FindObjectOfType<Puzle7>();
        puzle8 = FindObjectOfType<Puzle8>();
        puzle9 = FindObjectOfType<Puzle9>();

        menuConfirmacion = GameObject.Find("MenuConfirmacion");
        manager = FindObjectOfType<GameManager>();
        inventario = FindObjectOfType<Inventario>();
    }

    public void SaltarPuzle()
    {
        switch (manager.GetPuzleActual())
        {
            case 4:
                puzle4.SaltarPuzle();
                break;
            case 5:
                puzle5.SaltarPuzle();
                break;
            case 6:
                puzle6.SaltarPuzle();
                break;
            case 7:
                puzle7.SaltarPuzle();
                break;
            case 8:
                puzle8.SaltarPuzle();
                break;
            case 9:
                puzle9.SaltarPuzle();
                break;
            default:
                break;
        }

        Objeto obje = inventario.GetObjetoSeleccionado();
        int indice;

        if (obje.GetNombre() == "Skip Token")
        {
            indice = inventario.GetObjetos().IndexOf(obje);

            inventario.EliminarObjeto(indice); //debe ser el comodín

        }
        else
        {
            foreach (Objeto objet in inventario.GetObjetos())
            {
                if (objet.GetNombre() == "Skip Token")
                {

                    indice = inventario.GetObjetos().IndexOf(objet);

                    inventario.EliminarObjeto(indice); //debe ser el comodín

                }
            }
        }

        inventario.DeseleccionarObjeto();

    }

    public void AbrirMenuConfirmacion()
    {
        menuConfirmacion.SetActive(true);
    }

    public void CerrarMenuConfirmacion()
    {

        menuConfirmacion.SetActive(false);

    }
}
