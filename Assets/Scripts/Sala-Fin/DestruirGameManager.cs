using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirGameManager : MonoBehaviour
{
    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();

        if(manager != null)
        {
            Destroy(manager.gameObject);
        }
    }

}
