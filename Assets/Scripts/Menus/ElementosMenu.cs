using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementosMenu : MonoBehaviour
{
    public List<Sprite> estaticas;
    public List<Sprite> distorsiones;

    public Image imagenFondoTV;
    public Image imagenEstatica;

    double tiempoEstatica = 0.1;

    double temporizadorDistorsion = 5;
    double temporizadorEstatica = 0.1;
    double temporizadorVueltaNormal = 0.1;

    void Update()
    {
        if (imagenFondoTV != null && imagenEstatica != null)
        {

            temporizadorDistorsion -= Time.deltaTime;
            temporizadorEstatica -= Time.deltaTime;
            temporizadorVueltaNormal -= Time.deltaTime;

            if (temporizadorEstatica < 0)
            {
                temporizadorEstatica = tiempoEstatica;
                int rando = Random.Range(0, estaticas.Count);
                imagenEstatica.sprite = estaticas[rando];
            }

            if (temporizadorDistorsion < 0)
            {
                temporizadorVueltaNormal = 0.1;
                temporizadorDistorsion = Random.Range(5, 10);
                int rando = Random.Range(1, distorsiones.Count);
                imagenFondoTV.sprite = distorsiones[rando];
            }

            if (temporizadorVueltaNormal < 0)
            {
                temporizadorVueltaNormal = 0.1;
                imagenFondoTV.sprite = distorsiones[0];
            }

        }

    }
}
