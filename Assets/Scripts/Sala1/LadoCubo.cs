using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LadoCubo : MonoBehaviour
{
    [SerializeField]
    int indice;
    SpriteRenderer meshCara;
    List<Material> materialesColores;
    Puzle3 cubo;

    public AudioClip completo;

    private void Start()
    {
        meshCara = gameObject.GetComponent<SpriteRenderer>(); //habrá 6 colores aleatorios: rojo, azul, amarillo, verde, blanco y morado. Irán numerados de 0 a 5
        materialesColores = FindObjectOfType<Puzle3>().GetColoresMateriales();
        cubo = FindObjectOfType<Puzle3>();
    }

    public void CambiarColorLado() //cambia el color de esa cara con un clic
    {
        if (!cubo.ComprobarSiEstaResuelto())
        {
            int numero = cubo.GetEstadoCubo()[indice];

            /*if (numero < 5)
            {
                numero++;
            }
            else
            {
                numero = 0;
            }
            //meshCara.material = materialesColores[numero];
            cubo.SetEstadoCubo(numero, indice);
            */
            switch (numero)
            {
                case 0: //rojo
                    meshCara.color = new Color(0, 1, 1, 1);
                    numero++;
                    break;
                case 1: //azul
                    meshCara.color = new Color(1, 1, 0, 1);
                    numero++;
                    break;
                case 2: //amarillo
                    meshCara.color = new Color(0, 1, 0, 1);
                    numero++;
                    break;
                case 3: //verde
                    meshCara.color = new Color(1, 1, 1, 1);
                    numero++;
                    break;
                case 4: // blanco
                    meshCara.color = new Color(1, 0, 1, 1);
                    numero++;
                    break;
                case 5: //morado
                    meshCara.color = new Color(1, 0, 0, 1);
                    numero = 0;
                    break;
            }
            cubo.SetEstadoCubo(numero, indice);

        }
        else
        {
            AudioController audioC = FindObjectOfType<AudioController>();


            if (audioC != null)
            {
                audioC.PlaySFX(completo);
            }

            List<LadoCubo> lados = FindObjectsOfType<LadoCubo>().ToList();
            foreach (LadoCubo lC in lados)
            {
                lC.enabled = false;
            }

        }


    }

    public void CambiarColorLadoInicio(int numero) //cambia el color de esa cara con un clic
    {

        /*if (numero < 5)
        {
            numero++;
        }
        else
        {
            numero = 0;
        }
        //meshCara.material = materialesColores[numero];
        cubo.SetEstadoCubo(numero, indice);
        */

        if (meshCara == null)
        {
            Debug.Log("Soy nulo y voy a agregarme");
            meshCara = GetComponent<SpriteRenderer>();
            Debug.Log("Ahora meshCara es: " + meshCara);
        }

        switch (numero)
        {
            case 0: //rojo
                meshCara.color = new Color(1, 0, 0, 1);
                break;
            case 1: //azul
                meshCara.color = new Color(0, 1, 1, 1);
                break;
            case 2: //amarillo
                meshCara.color = new Color(1, 1, 0, 1);
                break;
            case 3: //verde
                meshCara.color = new Color(0, 1, 0, 1);
                break;
            case 4: // blanco
                meshCara.color = new Color(1, 1, 1, 1);
                break;
            case 5: //morado
                meshCara.color = new Color(1, 0, 1, 1);
                break;
        }


    }

    public int GetIndice()
    {
        return indice;
    }

    public void SetIndice(int indi)
    {
        indice = indi;
    }

    private void OnMouseDown()
    {
        CambiarColorLado();
    }

    private void OnMouseOver()
    {
        Debug.Log(gameObject.name + ", " + gameObject.transform.parent.name + ", " + indice);
    }

}

