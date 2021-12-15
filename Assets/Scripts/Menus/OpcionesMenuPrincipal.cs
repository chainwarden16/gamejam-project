using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpcionesMenuPrincipal : MonoBehaviour
{
    #region Variables

    [Header("Elementos del menú")]
    public GameObject flechaDerMusica, flechaDerSFX, flechaIzqMusica, flechaIzqSFX;
    Button flechaDM, flechaIM, flechaDS, flechaIS;
    public Text cantidadMusica, cantidadSFX;


    GameManager manager;


    [Header("Audio")]
    AudioController audioC;
    public AudioClip seleccionar;
    [SerializeField]
    public static int musica;
    [SerializeField]
    public static int sfx;
    AudioSource sourceMusica, sourceSFX;

    #endregion

    #region Funciones nativas de Unity

    private void Start()
    {

        musica = PlayerPrefs.GetInt("Música", 10);
        sfx = PlayerPrefs.GetInt("SFX", 10);
        audioC = FindObjectOfType<AudioController>();
        manager = FindObjectOfType<GameManager>();
        sourceMusica = audioC.sourceMusica;
        sourceSFX = audioC.sourceSFX;

        flechaDM = flechaDerMusica.GetComponent<Button>();
        flechaIM = flechaIzqMusica.GetComponent<Button>();
        flechaDS = flechaDerSFX.GetComponent<Button>();
        flechaIS = flechaIzqSFX.GetComponent<Button>();
        cantidadMusica.text = musica.ToString();
        cantidadSFX.text = sfx.ToString();
        //hay que desactivar los botones según si se puede bajar su valor o no

        ComprobarFlechasMenu();

    }

    #endregion


    #region Métodos que regulan el sonido

    public void AumentarValorMusica()
    {
        if (musica < 10)
        {
            audioC.PlaySFX(seleccionar);
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
            audioC.PlaySFX(seleccionar);
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
            audioC.PlaySFX(seleccionar);
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
            audioC.PlaySFX(seleccionar);
            sfx--;
            sourceSFX.volume -= 0.1f;
            cantidadSFX.text = sfx.ToString();
            ComprobarFlechasMenu();
        }

    }
    /// <summary>
    /// Este método abrirá una nueva escena donde el jugador podrá escoger qué escena jugar, siempre que las haya superado con anterioridad. El jugador siempre cargará los datos que haya en el archivo, a menos que el elija el
    /// nivel de entrenamiento. Eso sí, al hacer clic en esta opción se perderán los cambios hechos en el volumen de música y SFX que no se hayan guardado
    /// </summary>
    public void SeleccionarNivel()
    {
        audioC.PlaySFX(seleccionar);
        PlayerPrefs.SetInt("Música", musica);
        PlayerPrefs.SetInt("SFX", sfx);
        Initiate.Fade("SeleccionNivel", Color.black, 2f);
    }

    /// <summary>
    /// Este método deberá guardar en los PlayerPrefs los ajustes de sonido. La razón por la que empleo PlayerPrefs aquí y no lo incluyo en el archivo de guardado binario es porque el hecho de que el jugador
    /// modifique estos valores no hará que el juego sea afectado de manera negativa (por ejemplo, cambiando cuánta vida tiene de un combate para otro, en qué nivel se encuentra, etc.). Son sólo ajustes opcionales
    /// que no tienen impacto en la jugabilidad en sí y son meramente para acomodar la experiencia del jugador. también llevará al jugador a la pantalla de título
    /// </summary>
    public void GuardarCambios()
    {
        audioC.PlaySFX(seleccionar);
        PlayerPrefs.SetInt("Música", musica);
        PlayerPrefs.SetInt("SFX", sfx);
        Initiate.Fade("Titulo", Color.black, 2f);
    }

    /// <summary>
    /// Este método cancela los cambios hechos en esta pantalla y no los hará efectivos, y en el proceso devolverá al jugador a la pantalla de título
    /// </summary>
    public void CancelarAccion()
    {
        audioC.PlaySFX(seleccionar);
        sourceMusica.volume = PlayerPrefs.GetInt("Música") * 0.1f;
        sourceSFX.volume = PlayerPrefs.GetInt("SFX") * 0.1f;
        Initiate.Fade("Titulo", Color.black, 2f);
    }

    #endregion


    #region Métodos auxiliares

    void ComprobarFlechasMenu()
    {


        if (musica == 0)
        {
            flechaIzqMusica.GetComponent<Button>().image.color = new Color(1, 1, 1, 0.5f);
            flechaIM.interactable = false;
        }
        else
        {
            flechaIzqMusica.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
            flechaIM.interactable = true;
        }

        if (musica == 10)
        {
            flechaDerMusica.GetComponent<Button>().image.color = new Color(1, 1, 1, 0.5f);
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
                flechaIzqSFX.GetComponent<Button>().image.color = new Color(1, 1, 1, 0.5f);
                flechaIS.interactable = false;
            }
            else
            {
                flechaIzqSFX.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
                flechaIS.interactable = true;
            }

            if (sfx == 10)
            {
                flechaDerSFX.GetComponent<Button>().image.color = new Color(1, 1, 1, 0.5f);
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
