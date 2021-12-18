using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzle8 : MonoBehaviour
{
    const int sizePuzle = 24;
    [SerializeField]
    PiezaJigsaw piezaSeleccionada;

    [SerializeField]
    List<int> solucionPuzle = new List<int>() { };
    [SerializeField]
    List<GameObject> piezasColocadas = new List<GameObject>() { };

    public GameObject puzleResuelto;
    public List<GameObject> piezasPuzle;
    public TextMeshProUGUI textoSolucion1, textoSolucion2, textoSolucion3, textoSolucion4;

    bool estaResuelto;
    GameManager manager;

    [Header("Solución puzle 9")]
    List<int> posiblesValores1 = new List<int> { 3, 5, 8 }; //azul
    List<int> posiblesValores2 = new List<int> { 1, 4, 9 }; //rojo
    List<int> posiblesValores3 = new List<int> { 6, 0 }; //verde
    List<int> posiblesValores4 = new List<int> { 2, 7 }; //amarillo

    [SerializeField]
    int valor1, valor2, valor3, valor4;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        for (int i = 0; i < sizePuzle; i++)
        {
            solucionPuzle.Add(i);
            piezasColocadas.Add(null);
        }


        if (PlayerPrefs.GetInt("Digito1", -1) == -1)
        {
            valor1 = posiblesValores1[Random.Range(0, 3)];
            valor2 = posiblesValores2[Random.Range(0, 3)];
            valor3 = posiblesValores3[Random.Range(0, 2)];
            valor4 = posiblesValores4[Random.Range(0, 2)];

            PlayerPrefs.SetInt("Digito1", valor1);
            PlayerPrefs.SetInt("Digito2", valor2);
            PlayerPrefs.SetInt("Digito3", valor3);
            PlayerPrefs.SetInt("Digito4", valor4);
        }
        else
        {
            valor1 = PlayerPrefs.GetInt("Digito1");
            valor2 = PlayerPrefs.GetInt("Digito2");
            valor3 = PlayerPrefs.GetInt("Digito3");
            valor4 = PlayerPrefs.GetInt("Digito4");
        }


        textoSolucion1.text = valor1.ToString();
        textoSolucion2.text = valor2.ToString();
        textoSolucion3.text = valor3.ToString();
        textoSolucion4.text = valor4.ToString();

        if (manager != null)
        {
            bool estaYaHecho = manager.GetPuzlesResueltos()[7];

            if (estaYaHecho)
            {
                estaResuelto = true;
                HacerAparecerSolucion();


            }
            else
            {
                textoSolucion1.gameObject.SetActive(false);
                textoSolucion2.gameObject.SetActive(false);
                textoSolucion3.gameObject.SetActive(false);
                textoSolucion4.gameObject.SetActive(false);

                puzleResuelto.SetActive(false);
            }

        }
    }

    public void SeleccionarPieza(PiezaJigsaw pieza)
    {
        piezaSeleccionada = pieza;
        int indice = pieza.GetHuecoIndiceActual();
        pieza.GetComponentInChildren<SpriteRenderer>().color = new Color(0, 1, 0, 1);

        if (indice >= 0)
        {

            piezasColocadas[indice] = null;

        }
    }

    public bool GetEstaResuelto()
    {
        return estaResuelto;
    }

    public PiezaJigsaw GetPiezaSeleccionada()
    {

        return piezaSeleccionada;

    }

    public List<GameObject> GetPiezasColocadas()
    {
        return piezasColocadas;
    }

    public void ComprobarEstadoPuzle()
    {
        bool resuelto = true;

        for (int i = 0; i < solucionPuzle.Count / 2; i++)
        {

            if (piezasColocadas[i] != null)
            {
                PiezaJigsaw pieza = piezasColocadas[i].GetComponent<PiezaJigsaw>();
                if (pieza != null && pieza.GetIndice() != solucionPuzle[i])
                {
                    resuelto = false;
                    break;
                }
            }
            else
            {
                resuelto = false;
                break;
            }


        }

        if (manager != null)
        {
            manager.SetPuzleResuelto(7, resuelto);
        }

        estaResuelto = resuelto;

        if (estaResuelto)
        {
            HacerAparecerSolucion();
        }
    }

    public void DeseleccionarPieza()
    {
        piezaSeleccionada.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        piezaSeleccionada = null;
    }

    public void SaltarPuzle()
    {
        estaResuelto = true;
        if (manager != null)
        {
            manager.SetPuzleResuelto(7, true);
        }

        //aparecen las piezas ordenadas y el texto de la solucion
    }

    public void CerrarPuzle()
    {
        Initiate.Fade("Sala3", Color.black, 1f);
    }

    private void HacerAparecerSolucion()
    {
        puzleResuelto.SetActive(true);
        foreach (GameObject piezaP in piezasPuzle)
        {
            piezaP.SetActive(false);
        }
        textoSolucion1.gameObject.SetActive(true);
        textoSolucion2.gameObject.SetActive(true);
        textoSolucion3.gameObject.SetActive(true);
        textoSolucion4.gameObject.SetActive(true);
    }

}
