using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzle2 : MonoBehaviour
{
    List<Libro> libros;
    List<Libro> librosSolucion;
    public List<GameObject> datosLibros;
    const int numeroLibros = 18;

    // Start is called before the first frame update
    void Start()
    {
        //Se escoge 18 libros aleatorios de entre los 24 disponibles y se colocan. Luego, se mira cuál sería su orden correcto (tanto alfabético como por color) y se guarda para compararlo
        //cada vez que el jugador intercambie dos libros de lugar

        List<int> indices = new List<int>();

        Vector2 posicionInicial;

        for(int i = 0; i < 24; i++)
        {

            indices.Add(i);

        }

        for(int i = 0; i < numeroLibros; i++)
        {
            int rand = Random.Range(0, indices.Count);
            if(i < 9)
            {
                posicionInicial = new Vector2(-14f + i*3.5f, 7.6f);
            }
            else
            {
                posicionInicial = new Vector2(-14f + i * 3.5f, 2.35f);
            }
            GameObject book = Instantiate(datosLibros[rand], posicionInicial, Quaternion.identity); //colocar la posicion correcta al generarlos
            libros.Add(book.GetComponent<Libro>());
            indices.Remove(rand);
        }

        //Se ordenan los libros en otra lista para ver qué orden es el correcto

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
