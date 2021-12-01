using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    List<Objeto> objetosObtenidos = new List<Objeto>();
    Objeto objetoSeleccionado;
    void Start()
    {
        
    }

    public void MostrarInventario()
    {

    }

    public void SeleccionarObjeto(Objeto objeto)
    {
        objetoSeleccionado = objeto;
    }

    public void RecogerObjeto(Objeto objeto)
    {
        objetosObtenidos.Add(objeto);
    }

    public void EliminarObjeto(int indice)
    {
        objetosObtenidos.RemoveAt(indice);
    }

    public List<Objeto> GetObjetos()
    {
        return objetosObtenidos;
    }

    public Objeto GetObjetoSeleccionado()
    {
        return objetoSeleccionado;
    }

    public void DeseleccionarObjeto()
    {
        objetoSeleccionado = null;
    }

}
