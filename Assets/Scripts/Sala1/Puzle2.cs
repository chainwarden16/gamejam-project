using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Puzle2 : MonoBehaviour
{
    [SerializeField]
    List<Libro> libros = new List<Libro>();
    [SerializeField]
    List<Libro> librosSolucion = new List<Libro>();
    public List<GameObject> datosLibros;
    const int numeroLibros = 18; //debería ser un número divisible entre el número de baldas de la estantería

    [SerializeField]
    List<int> indices = new List<int>();

    public GameObject puzleContenedor;
    public GameObject textoPuzle;
    [SerializeField]
    Vector2 posicionActual;
    [SerializeField]
    Vector2 posicionObjetivo;
    GameObject l1, l2;

    float xInicial;
    float yInicial;
    float zInicial;

    bool estaResuelto;


    public Button cerrarPuzle;
    GameManager manager;

    [Header("Audio")]
    AudioController audioC;
    public AudioClip cancelar, completo, seleccionar;


    // Start is called before the first frame update
    void Start()
    {
        audioC = FindObjectOfType<AudioController>();
        manager = FindObjectOfType<GameManager>();

        //Se escoge 18 libros aleatorios de entre los 24 disponibles y se colocan. Luego, se mira cuál sería su orden correcto (tanto alfabético como por color) y se guarda para compararlo
        //cada vez que el jugador intercambie dos libros de lugar

        List<Libro> librosAux = new List<Libro>();

        Vector2 posicionInicial;

        int j = 0;

        for (int i = 0; i < 24; i++)
        {

            indices.Add(i);

        }

        for (int i = 0; i < numeroLibros; i++)
        {
            int rand = Random.Range(0, indices.Count);

            if (i < numeroLibros / 2)
            {
                posicionInicial = new Vector2(-14f + j * 3.5f, 7.6f);
                j++;
            }
            else if (i == numeroLibros / 2)
            {
                j = 0;
                posicionInicial = new Vector2(-14f + j * 3.5f, -2.35f);
                j++;

            }
            else
            {
                posicionInicial = new Vector2(-14f + j * 3.5f, -2.35f);
                j++;
            }
            GameObject book = Instantiate(datosLibros[indices[rand]], posicionInicial, Quaternion.identity); //colocar la posicion correcta al generarlos
            book.transform.SetParent(puzleContenedor.transform);
            book.GetComponentInChildren<SpriteRenderer>().sprite = book.GetComponent<Libro>().GetDatosLibro().portada;
            libros.Add(book.GetComponent<Libro>());
            //Debug.Log("El indice que se elimina es: " + rand + ", que es: " + indices[rand]);
            indices.RemoveAt(rand);

        }

        //Se ordenan los libros en otra lista para ver qué orden es el correcto, primero por color y luego por index
        librosSolucion = libros.OrderBy(lib => lib.GetDatosLibro().color).ThenBy(lib => lib.GetDatosLibro().numeroIndice).ToList();


    }

    // Update is called once per frame
    void Update()
    {

        if (estaResuelto)
        {
            //se proporciona el objeto y se impide que se pueda seguir manipulando los libros
            Debug.Log("¡Resuelto!");
            audioC = FindObjectOfType<AudioController>();

            foreach (Libro li in libros)
            {
                li.enabled = false;

            }
            if (manager != null)
            {

                manager.SetPuzleResuelto(1, true);

            }
        }
        else
        {
            //SeleccionarLibro();
        }

    }



    public void CerrarPuzleLibros()
    {
        audioC = FindObjectOfType<AudioController>();

        if (audioC != null)
        {
            audioC.PlaySFX(cancelar);
        }

        Initiate.Fade("Sala1 old", Color.black, 1f);
    }

    public void SeleccionarLibro(GameObject lib)
    {


        if (posicionActual == Vector2.zero)
        {

            l1 = lib;
            posicionActual = lib.transform.position;
            lib.GetComponent<Libro>().GetComponentInChildren<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.7f, 1);
            audioC = FindObjectOfType<AudioController>();

            if (audioC != null)
            {
                audioC.PlaySFX(seleccionar);
            }

        }
        else
        {
            l1.GetComponent<Libro>().GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1);
            l2 = lib;
            posicionObjetivo = lib.transform.position;
            IntercambiarLibros(l1, l2);
        }


    }

    public void IntercambiarLibros(GameObject libro1, GameObject libro2)
    {
        libro1.transform.position = posicionObjetivo;
        libro2.transform.position = posicionActual;
        l1 = null;
        l2 = null;
        posicionActual = Vector2.zero;
        posicionObjetivo = Vector2.zero;
        //int indice1 = libro1.GetComponent<Libro>().GetDatosLibro().
        if (!estaResuelto)
        {
            SwapElements(libros, libros.IndexOf(libro1.GetComponent<Libro>()), libros.IndexOf(libro2.GetComponent<Libro>()));

            bool verSiEstaResuelto = ComprobarSiEstaResuelto();
            SetEstaResuelto(verSiEstaResuelto);

            if (verSiEstaResuelto)
            {
                if (audioC != null)
                {
                    audioC.PlaySFX(completo);
                }
            }

        }
        else
        {
            if (audioC != null)
            {
                audioC.PlaySFX(completo);
            }
        }
    }

    public void SwapElements(List<Libro> list, int indexA, int indexB)
    {
        Libro tmp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = tmp;
    }

    public bool ComprobarSiEstaResuelto()
    {
        bool resuelto = true;

        for (int i = 0; i < libros.Count; i++)
        {
            if (libros[i] != librosSolucion[i])
            {
                resuelto = false;
            }
        }

        if (resuelto)
        {
            if (audioC != null)
            {
                audioC.PlaySFX(completo);
            }
        }

        return resuelto;
    }

    public void SetEstaResuelto(bool valor)
    {
        if (manager != null)
        {
            manager.SetPuzleResuelto(1, valor);
        }

        if (estaResuelto)
        {
            audioC = FindObjectOfType<AudioController>();

            if (audioC != null)
            {
                audioC.PlaySFX(completo);
            }
        }

        estaResuelto = valor;
    }
}
