using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Varilla : MonoBehaviour
{
    [SerializeField]
    List<Donut> discos;
    Puzle6 puzle;

    private void Start()
    {
        puzle = FindObjectOfType<Puzle6>();
    }

    public void DepositarDisco()
    {
        discos.Add(puzle.GetDiscoSeleccionado());
        //habría que moverlos según el puesto en el que estén dentro de la lista
        puzle.GetDiscoSeleccionado().gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1.16f * discos.Count);
        puzle.GetDiscoSeleccionado().SetVarilla(this);
        puzle.DeseleccionarDisco();
        puzle.ComprobarEstadoHanoi();
    }

    public bool ComprobarDepositarDisco()
    {
        bool sePuede = true;

        int tamañoLista = discos.Count;

        if (discos.Count > 3 || discos[tamañoLista - 1].GetSize() < puzle.GetDiscoSeleccionado().GetSize())
        {
            sePuede = false;
        }

        return sePuede;
    }

    public bool ComprobarRetirarDisco(Donut disk)
    {
        bool sePuede = false;

        int indiceDonut = discos.IndexOf(disk);

        if (indiceDonut != -1 && indiceDonut == discos.Count - 1)
        {
            sePuede = true;
            Debug.Log("Se puede retirar este disco");
        }

        return sePuede;
    }

    public List<Donut> GetDiscos()
    {
        return discos;
    }

    public void RetirarDisco(Donut disk)
    {

        discos.Remove(disk);

    }

    private void OnMouseDown()
    {

        if (puzle.GetDiscoSeleccionado() != null)
        {

            if (discos.Count != 0) //si la varilla contiene discos, se compara si se puede colocar. Si no hay discos, no hay impedimentos
            {

                if (ComprobarDepositarDisco())
                {
                    DepositarDisco();
                }

            }
            else
            {
                DepositarDisco();
            }

        }

    }

}
