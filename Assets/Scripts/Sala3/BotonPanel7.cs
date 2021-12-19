using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotonPanel7 : MonoBehaviour
{
    public int numeroAPulsar;

    public TextMeshProUGUI textoPantalla;

    Puzle7 puzle;

    [Header("Audio")]
    AudioController audioC;
    public AudioClip seleccionar, cancelar;

    private void Start()
    {
        puzle = FindObjectOfType<Puzle7>();
    }

    public void EscribirNumero()
    {
        if (textoPantalla.text.Length < 7 && !puzle.EstaResuelto())
        {
            textoPantalla.text += numeroAPulsar;

            audioC = FindObjectOfType<AudioController>();
            if (audioC != null)
            {
                audioC.PlaySFX(seleccionar);
            }

            puzle.ComprobarEstadoPuzle();
        }
    }


    public void BorrarTexto()
    {
        if (!puzle.EstaResuelto())
        {

            audioC = FindObjectOfType<AudioController>();
            if (audioC != null)
            {
                audioC.PlaySFX(cancelar);
            }

            textoPantalla.text = "";
        }
    }

    public void BorrarUnCaracter()
    {
        if (textoPantalla.text != "" && !puzle.EstaResuelto())
        {
            audioC = FindObjectOfType<AudioController>();
            if (audioC != null)
            {
                audioC.PlaySFX(cancelar);
            }
            textoPantalla.text = textoPantalla.text.Remove(textoPantalla.text.Length-1, 1);
        }

    }

}
