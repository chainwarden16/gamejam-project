using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Puzle3 : MonoBehaviour
{

    [SerializeField]
    List<int> ladosCubo = new List<int>();
    [SerializeField]
    List<int> solucionCubo = new List<int>();

    public List<LadoCubo> ladosFisicos;
    public List<Material> materialesColores;
    public GameObject contenedorCubo;
    public GameObject contenedorTextoCubo;

    GameManager manager;
    public Button botonCerrarPuzle;
    //public Button botonAbrirPuzle;

    //public DesplSala1 desp;
    //public Button botonAtras;
    //public GameObject posicionRetorno;
    //public GameObject posicionVerPuzle;
    //Camera camara;

    void Start() //habrá 6 colores aleatorios: rojo, azul, amarillo, verde, blanco y morado. Irán numerados de 0 a 5
    {
        manager = FindObjectOfType<GameManager>();
        //camara = Camera.main;
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
        foreach (LadoCubo lad in ladosFisicos)
        {
            Debug.Log(j);
            j++;
            lad.CambiarColorLadoInicio(ladosCubo[lad.GetIndice()]);
        }

    }

    /*
    public void AbrirPuzle()
    {
        //botonAtras.interactable = false;
        //contenedorCubo.SetActive(true);
        //botonCerrarPuzle.interactable = true;
        //botonAbrirPuzle.interactable = false;
        //contenedorTextoCubo.SetActive(true);

        //se posiciona y rota la cámara
        //camara.transform.position = posicionVerPuzle.transform.position;
        //camara.transform.rotation = posicionVerPuzle.transform.rotation;

    }
    */
    public void CerrarPuzle()
    {
        //botonAtras.interactable = true;
        //contenedorCubo.SetActive(false);
        //botonCerrarPuzle.interactable = false;
        //botonAbrirPuzle.interactable = true;
        //contenedorTextoCubo.SetActive(false);

        //se devuelve la cámara al lugar que debería, con la rotación esperada
        //camara.transform.position = posicionRetorno.transform.position;
        //camara.transform.rotation = posicionRetorno.transform.rotation;

        Initiate.Fade("Sala1 old", Color.black, 1f);
    }

    public bool ComprobarSiEstaResuelto()
    {
        bool estaResuelto = true;

        for (int i = 0; i < ladosCubo.Count; i++)
        {
            if (ladosCubo[i] != solucionCubo[i])
            {
                estaResuelto = false;
                break;
            }
        }
        //desp.SetB3(estaResuelto);
        if (manager != null)
        {

            manager.SetPuzleResuelto(2, estaResuelto);
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
