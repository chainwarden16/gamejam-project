using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzle9 : MonoBehaviour
{
    bool estaResuelto;

    [SerializeField]
    bool boton1, boton2, boton3, boton4;

    [SerializeField]
    int valor1, valor2, valor3, valor4;
    public SpriteRenderer luz1, luz2, luz3, luz4;
    public Sprite luzVerde, luzRoja;

    public TextMeshProUGUI textoContador;
    int contador;
    float temporizador;

    GameManager manager;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();

        valor1 = PlayerPrefs.GetInt("Digito1", -1);
        valor2 = PlayerPrefs.GetInt("Digito2", -1);
        valor3 = PlayerPrefs.GetInt("Digito3", -1);
        valor4 = PlayerPrefs.GetInt("Digito4", -1);

        contador = 0;
        textoContador.text = contador.ToString();

    }

    private void Update()
    {
        if (!estaResuelto)
        {

            if (contador >= 99.9f)
            {
                contador = 0;
            }

            if (temporizador >= 1f)
            {
                temporizador = 0;
                contador++;
            }

            temporizador += Time.deltaTime;

            if (contador < 10)
            {
                textoContador.text = "0" + contador.ToString();
            }
            else
            {

                textoContador.text = contador.ToString();
            }


        }
    }

    public void ComprobarEstadoPuzle()
    {
        bool estadoResuelto;

        if (boton1 && boton2 && boton3 && boton4)
        {
            estadoResuelto = true;
        }
        else
        {
            estadoResuelto = false;
        }

        if(manager != null)
        {
            manager.SetPuzleResuelto(8, estadoResuelto);
        }

        estaResuelto = estadoResuelto;
    }

    public bool GetEstaResuelto()
    {
        return estaResuelto;
    }

    public void PresionarBoton(int color)
    {
        int cifra1 = contador / 10;
        int cifra2 = contador % 10;

        Debug.Log(cifra1 + " ," + cifra2);


        switch (color)
        {
            case 0: //azul
                if (cifra1 == valor1 || cifra2 == valor1)
                {
                    boton1 = true;
                    //se cambia la imagen del primer boton
                }
                else
                {
                    boton1 = false;
                    boton2 = false;
                    boton3 = false;
                    boton4 = false;
                    //se cambian todos los botones
                }
                break;
            case 1: //rojo
                if (cifra1 == valor2 || cifra2 == valor2)
                {
                    boton2 = true;
                    //se cambia la imagen del primer boton
                }
                else
                {
                    boton1 = false;
                    boton2 = false;
                    boton3 = false;
                    boton4 = false;
                    //se cambian todos los botones
                }
                break;
            case 2: //verde
                if (cifra1 == valor3 || cifra2 == valor3)
                {
                    boton3 = true;
                    //se cambia la imagen del primer boton
                }
                else
                {
                    boton1 = false;
                    boton2 = false;
                    boton3 = false;
                    boton4 = false;
                    //se cambian todos los botones
                }
                break;
            case 3: //amarillo
                if (cifra1 == valor4 || cifra2 == valor4)
                {
                    boton4 = true;
                    //se cambia la imagen del primer boton
                }
                else
                {
                    boton1 = false;
                    boton2 = false;
                    boton3 = false;
                    boton4 = false;
                    //se cambian todos los botones
                }
                break;
        }
    }

    public void SaltarPuzle()
    {
        estaResuelto = true;
    }

    public void CerrarPuzle9()
    {
        Initiate.Fade("Sala3", Color.black, 1f);
    }

}
