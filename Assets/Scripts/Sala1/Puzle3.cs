using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Puzle3 : MonoBehaviour
{

    [SerializeField]
    List<int> ladosCubo = new List<int>();
    [SerializeField]
    List<int> solucionCubo = new List<int>();
    public List<LadoCubo> ladosFisicos;
    public List<Material> materialesColores;

    void Start() //habr� 6 colores aleatorios: rojo, azul, amarillo, verde, blanco y morado. Ir�n numerados de 0 a 5
    {
        ladosFisicos = FindObjectsOfType<LadoCubo>().ToList();

        for (int i = 0; i < ladosFisicos.Count; i++)
        {

            int colorInicial = Random.Range(0, 6);
            ladosCubo.Add(colorInicial);
            solucionCubo.Add(Random.Range(0, 6));
            ladosFisicos[i].SetIndice(i);

            ladosFisicos[i].gameObject.AddComponent<BoxCollider>();
        }
        int j = 0;
        foreach(LadoCubo lad in ladosFisicos)
        {
            Debug.Log(j);
            j++;
            lad.CambiarColorLadoInicio(ladosCubo[lad.GetIndice()]);
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

    public void SetEstadoCubo(int numero, int indice)
    {
        ladosCubo[indice] = numero;
    }

    public List<Material> GetColoresMateriales()
    {
        return materialesColores;
    }

}
