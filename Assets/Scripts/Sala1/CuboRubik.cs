using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CuboRubik : MonoBehaviour
{

    [SerializeField]
    List<int> ladosCubo = new List<int>();
    [SerializeField]
    List<int> solucionCubo = new List<int>();
    public List<LadoCubo> ladosFisicos;
    public List<Material> materialesColores;

    void Start() //habrá 6 colores aleatorios: rojo, azul, amarillo, verde, blanco y morado. Irán numerados de 0 a 5
    {
        ladosFisicos = FindObjectsOfType<LadoCubo>().ToList();
        Debug.Log(ladosFisicos.Count);

        for (int i = 0; i < ladosFisicos.Count; i++)
        {

            Debug.Log(i);
            ladosCubo.Add(Random.Range(0, 6));
            solucionCubo.Add(Random.Range(0, 6));


        }


    }

    public void CerrarPuzle()
    {

    }

    public bool ComprobarSiEstaResuelto()
    {
        bool estaResuelto = true;

        for(int i = 0; i < ladosCubo.Count; i++)
        {
            if(ladosCubo[i] != solucionCubo[i])
            {
                estaResuelto = false;
                break;
            }
        }

        return estaResuelto;
    }

    public List<int> GetEstadoCubo()
    {
        return ladosCubo;
    }

    public void SetEstadoCubo(int numero)
    {

    }

    public List<Material> GetColoresMateriales()
    {
        return materialesColores;
    }

}
