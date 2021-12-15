using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpcionesGameplay : MonoBehaviour
{
    #region Variables

    public GameObject uiMenu;
    public GameObject uiOpciones;

    OpcionesGameplay opciones;

    [Header("Elementos del menú de opciones")]
    public GameObject flechaDerMusica, flechaDerSFX, flechaIzqMusica, flechaIzqSFX;
    Button flechaDM, flechaIM, flechaDS, flechaIS;
    public Text cantidadMusica, cantidadSFX;

    [Header("Audio")]
    AudioController audioC;
    public AudioClip confirmar;
    [SerializeField]
    public static int musica;
    [SerializeField]
    public static int sfx;
    AudioSource sourceMusica, sourceSFX;

    MenuPausa controladorPausa;

    #endregion

    void Start()
    {
        opciones = FindObjectOfType<OpcionesGameplay>();
        controladorPausa = FindObjectOfType<MenuPausa>();
        
        uiMenu.SetActive(false);

        //operaciones del menú de pausa

        audioC = FindObjectOfType<AudioController>();
        sourceMusica = audioC.sourceMusica;
        sourceSFX = audioC.sourceSFX;

        musica = PlayerPrefs.GetInt("Música", 10);
        sfx = PlayerPrefs.GetInt("SFX", 10);

        flechaDM = flechaDerMusica.GetComponent<Button>();
        flechaIM = flechaIzqMusica.GetComponent<Button>();
        flechaDS = flechaDerSFX.GetComponent<Button>();
        flechaIS = flechaIzqSFX.GetComponent<Button>();
        cantidadMusica.text = musica.ToString();
        cantidadSFX.text = sfx.ToString();
        //hay que desactivar los botones según si se puede bajar su valor o no

        ComprobarFlechasMenu();

        opciones.enabled = false;
        uiOpciones.SetActive(false);
    }

    #region Operaciones del menú de pausa

    public void ReanudarJuego()
    {
        audioC.PlaySFX(confirmar);
        uiMenu.SetActive(false);
        Time.timeScale = 1;
        controladorPausa.SetEstaPausado(false);
        this.enabled = false;
    }

    public void CerrarAplicacion()
    {
        audioC.PlaySFX(confirmar);
        Application.Quit();
    }

    public void MostrarOpciones()
    {
        audioC.PlaySFX(confirmar);
        uiOpciones.SetActive(true);
        controladorPausa.SetestaViendoOpciones(true);
        uiMenu.SetActive(false);
    }

    #endregion

    #region Métodos que regulan el sonido

    public void AumentarValorMusica()
    {
        if (musica < 10)
        {
            audioC.PlaySFX(confirmar);
            musica++;
            sourceMusica.volume += 0.1f;
            cantidadMusica.text = musica.ToString();
            ComprobarFlechasMenu();
        }

    }

    public void DecrementarValorMusica()
    {
        if (musica > 0)
        {
            audioC.PlaySFX(confirmar);
            musica--;
            sourceMusica.volume -= 0.1f;
            cantidadMusica.text = musica.ToString();
            ComprobarFlechasMenu();
        }

    }

    public void AumentarValorSFX()
    {
        if (sfx < 10)
        {
            audioC.PlaySFX(confirmar);
            sfx++;
            sourceSFX.volume += 0.1f;
            cantidadSFX.text = sfx.ToString();
            ComprobarFlechasMenu();
        }

    }

    public void DecrementarValorSFX()
    {
        if (sfx > 0)
        {
            audioC.PlaySFX(confirmar);
            sfx--;
            sourceSFX.volume -= 0.1f;
            cantidadSFX.text = sfx.ToString();
            ComprobarFlechasMenu();
        }

    }

    /// <summary>
    /// Este método deberá guardar en los PlayerPrefs los ajustes de sonido. La razón por la que empleo PlayerPrefs aquí y no lo incluyo en el archivo de guardado binario es porque el hecho de que el jugador
    /// modifique estos valores no hará que el juego sea afectado de manera negativa (por ejemplo, cambiando cuánta vida tiene de un combate para otro, en qué nivel se encuentra, etc.). Son sólo ajustes opcionales
    /// que no tienen impacto en la jugabilidad en sí y son meramente para acomodar la experiencia del jugador. también llevará al jugador a la pantalla de título
    /// </summary>
    public void GuardarCambios()
    {
        audioC.PlaySFX(confirmar);
        PlayerPrefs.SetInt("Música", musica);
        PlayerPrefs.SetInt("SFX", sfx);
        controladorPausa.SetestaViendoOpciones(false);
        ReactivarMenuPausa();
    }

    /// <summary>
    /// Este método cancela los cambios hechos en esta pantalla y no los hará efectivos, y en el proceso devolverá al jugador a la pantalla de título
    /// </summary>
    public void CancelarAccion()
    {
        audioC.PlaySFX(confirmar);
        sourceMusica.volume = PlayerPrefs.GetInt("Música") * 0.1f;
        sourceSFX.volume = PlayerPrefs.GetInt("SFX") * 0.1f;
        cantidadMusica.text = (PlayerPrefs.GetInt("Música")).ToString();
        cantidadSFX.text = (PlayerPrefs.GetInt("SFX")).ToString();
        musica = PlayerPrefs.GetInt("Música", 10);
        sfx = PlayerPrefs.GetInt("SFX", 10);
        controladorPausa.SetestaViendoOpciones(false);
        ReactivarMenuPausa();
    }

    #endregion


    #region Métodos auxiliares

    public void ReactivarMenuPausa()
    {
        uiMenu.SetActive(true);
        uiOpciones.SetActive(false);
    }

    void ComprobarFlechasMenu()
    {


        if (musica == 0)
        {
            flechaIzqMusica.GetComponent<Button>().image.color = new Color(1, 1, 1, 0);
            flechaIM.interactable = false;
        }
        else
        {
            flechaIzqMusica.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
            flechaIM.interactable = true;
        }

        if (musica == 10)
        {
            flechaDerMusica.GetComponent<Button>().image.color = new Color(1, 1, 1, 0);
            flechaDM.interactable = false;
        }
        else
        {
            flechaDerMusica.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
            flechaDM.interactable = true;
        }


        if (flechaIzqSFX != null && flechaDerSFX != null)
        {

            if (sfx == 0)
            {
                flechaIzqSFX.GetComponent<Button>().image.color = new Color(1, 1, 1, 0);
                flechaIS.interactable = false;
            }
            else
            {
                flechaIzqSFX.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                flechaIS.interactable = true;
            }

            if (sfx == 10)
            {
                flechaDerSFX.GetComponent<Button>().image.color = new Color(1, 1, 1, 0);
                flechaDS.interactable = false;
            }
            else
            {
                flechaDerSFX.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                flechaDS.interactable = true;
            }

        }
    }


    #endregion
}
