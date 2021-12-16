using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class Puzle1 : MonoBehaviour
{
    public GameObject laberintoTablero;
    Vector2 posicionInicialBola = new Vector2(0.75f, -9.5f);
    string numeroRevelado;

    public List<TextMeshProUGUI> textoMarcadores;
    public List<GameObject> marcadores;
    public List<bool> marcadoresActivados;

    public GameObject bolaMetal;
    bool estaResuelto = false;

    public DesplSala1 desp;
    public Button botonAtras;

    Camera camara;
    public Button abrirPuzle;
    public Button cerrarPuzle;
    public GameObject posicionRetorno;

    private void Start()
    {
        camara = Camera.main;

        numeroRevelado = Random.Range(1000, 10000).ToString();
        for (int i = 0; i < 4; i++)
        {

            textoMarcadores[i].text = numeroRevelado[i].ToString();
            marcadores[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            Debug.Log("La cifra en la posición " + i + " es: " + textoMarcadores[i].text);
            Debug.Log("Y el número completo es: " + numeroRevelado);
            textoMarcadores[i].gameObject.SetActive(false);

        }
    }

    public void AbrirLaberinto()
    {
        
        laberintoTablero.gameObject.SetActive(true);
        bolaMetal.SetActive(true);
        botonAtras.interactable = false;
        cerrarPuzle.interactable = true;
        abrirPuzle.interactable = false;
        //desplazar la cámara al punto determinado, con la rotación adecuada

    }

    public void CerrarLaberinto()
    {
        cerrarPuzle.interactable = false;
        abrirPuzle.interactable = true;
        //se recoloca la bola en el inicio
        bolaMetal.transform.position = posicionInicialBola;
        laberintoTablero.gameObject.SetActive(false);
        botonAtras.interactable = true;
        //devolver la cámara al punto que debería estar, con la rotación adecuada
        camara.transform.position = posicionRetorno.transform.position;
        camara.transform.rotation = posicionRetorno.transform.rotation;
    }

    public void ReiniciarMarcadores()
    {
        //Si el jugador lleva la bola a la salida, se reinician los contadores y se devuelve la pelota al punto de inicio
        for (int i = 0; i < marcadores.Count; i++)
        {
            marcadores[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            marcadoresActivados[i] = false;
            //textoMarcadores[i].gameObject.SetActive(false);
        }
        bolaMetal.transform.position = posicionInicialBola;
    }

    public void MostrarCombinacion()
    {
        bool yaEstanTodos = true;
        for (int i = 0; i < marcadoresActivados.Count; i++)
        {
            if (marcadoresActivados[i] == false)
            {
                yaEstanTodos = false;
                break;
            }

        }

        if (yaEstanTodos)
        {
            estaResuelto = true;
            desp.SetB1(estaResuelto);
            /*foreach (TextMeshProUGUI texto in textoMarcadores)
            {
                texto.gameObject.SetActive(true);
            }*/
        }

    }

    public string GetNumeroRevelado()
    {
        return numeroRevelado;
    }

    public void SetMarcadorActivado(int inde)
    {
        marcadoresActivados[inde] = true;
        marcadores[inde].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    public void SetPosicionBolaInicio()
    {
        bolaMetal.transform.position = posicionInicialBola;
    }

    public bool GetEstaResuelto()
    {
        return estaResuelto;
    }

}
