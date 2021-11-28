using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadoCubo : MonoBehaviour
{
    public int indice;
    MeshRenderer meshCara;
    List<Material> materialesColores;
    CuboRubik cubo;

    private void Start()
    {
        meshCara = gameObject.GetComponent<MeshRenderer>(); //habrá 6 colores aleatorios: rojo, azul, amarillo, verde, blanco y morado. Irán numerados de 0 a 5
        materialesColores = FindObjectOfType<CuboRubik>().GetColoresMateriales();
        cubo = FindObjectOfType<CuboRubik>();
    }

    public void CambiarColorLado() //cambia el color de esa cara con un clic
    {
        int numero = cubo.GetEstadoCubo()[indice];

        if (numero < 5)
        {
            numero++;
        }
        else
        {
            numero = 0;
        }
        meshCara.material = materialesColores[numero];

    }

}
