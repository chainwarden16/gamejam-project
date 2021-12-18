using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DespSala3 : MonoBehaviour
{
    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void TerminarPartida()
    {
        if(manager != null)
        {
            if(manager.GetPuzlesResueltos()[6] && manager.GetPuzlesResueltos()[7] && manager.GetPuzlesResueltos()[8])
            {
                manager.GuardarSalaCompletada(SceneManager.GetActiveScene().buildIndex+2, "Fin");
            }
        }
    }
}
