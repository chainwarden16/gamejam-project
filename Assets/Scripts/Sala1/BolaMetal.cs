using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMetal : MonoBehaviour
{
    Rigidbody2D rb;
    int velocidadBola = 80; //40
    Puzle1 puzle;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        puzle = FindObjectOfType<Puzle1>();
    }
    void LateUpdate()
    {
        DesplazarBola();
    }
    public void DesplazarBola()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 60f;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * 60f;

        bool seProhibeMovimiento = puzle.GetEstaResuelto();

        if (!seProhibeMovimiento)
        {

            if (x != 0)
            {
                rb.velocity = new Vector2(velocidadBola * x, 0f);
            }
            else if (y != 0)
            {
                rb.velocity = new Vector2(0f, velocidadBola * y);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

        }


    }


}
