using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Libro", menuName ="Sala1/Libro")]
public class LibroScriptable : ScriptableObject
{
    [Tooltip("Imagen con la portada")]
    public Sprite portada;
    [Tooltip("Índice en la lista de libros")]
    public int numeroIndice;
    [Tooltip("0 = blue, 1 = green, 2 = red, 3 = yellow")]
    public int color;
}
