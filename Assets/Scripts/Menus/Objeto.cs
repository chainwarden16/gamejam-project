using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public ObjetoScriptable datos;


    public string GetNombre()
    {
        return datos.nombre;
    }

    public string GetDescripcion()
    {
        return datos.descripcion;
    }

    public Sprite GetImagen()
    {
        return datos.imagen;
    }

}
