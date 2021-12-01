using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    int size;

    public bool SePuedeColocarEncima(int tamaño)
    {
        return size < tamaño;
    }

    
}
