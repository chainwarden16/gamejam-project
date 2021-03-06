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
    List<int> solucionCubo = new List<int>() { 0, 5, 1, 5, 4, 3, 1, 2, 3, 5, 4, 4, 1, 0, 0, 1, 5, 1, 2, 5, 2, 3, 4, 2, 4, 3, 5 };

    public List<LadoCubo> ladosFisicos;
    public List<Material> materialesColores;
    public GameObject contenedorCubo;
    public GameObject contenedorTextoCubo;

    GameManager manager;
    public Button botonCerrarPuzle;

    [Header("Audio")]
    AudioController audioC;
    public AudioClip cancelar, completo;
    bool estaResueltoYa;


    void Start() //habr? 6 colores aleatorios: rojo, azul, amarillo, verde, blanco y morado. Ir?n numerados de 0 a 5
    {
        audioC = FindObjectOfType<AudioController>();
        manager = FindObjectOfType<GameManager>();
        //camara = Camera.main;
        ladosFisicos = FindObjectsOfType<LadoCubo>().ToList();

        for (int i = 0; i < ladosFisicos.Count; i++)
        {

            //int colorInicial = solucionCubo[i];
            int colorInicial = Random.Range(0, 6);
            ladosCubo.Add(colorInicial);
            //solucionCubo.Add(Random.Range(0, 6));
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

    private void Update()
    {
        if(estaResueltoYa)
        {
            audioC = FindObjectOfType<AudioController>();

        }
    }


    public void CerrarPuzle()
    {
        audioC = FindObjectOfType<AudioController>();

        if (audioC != null)
        {
            audioC.PlaySFX(cancelar);
        }

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

        if (manager != null && manager.GetPuzlesResueltos()[2])
        {
            audioC = FindObjectOfType<AudioController>();

            if (audioC != null)
            {
                audioC.PlaySFX(completo);
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
