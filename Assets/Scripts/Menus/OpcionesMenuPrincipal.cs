using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpcionesMenuPrincipal : MonoBehaviour
{
    #region Variables

    [Header("Elementos del men�")]
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

        musica = PlayerPrefs.GetInt("M�sica", 10);
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
        //hay que desactivar los botones seg�n si se puede bajar su valor o no

        ComprobarFlechasMenu();

    }

    #endregion


    #region M�todos que regulan el sonido

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
    /// Este m�todo abrir� una nueva escena donde el jugador podr� escoger qu� escena jugar, siempre que las haya superado con anterioridad. El jugador siempre cargar� los datos que haya en el archivo, a menos que el elija el
    /// nivel de entrenamiento. Eso s�, al hacer clic en esta opci�n se perder�n los cambios hechos en el volumen de m�sica y SFX que no se hayan guardado
    /// </summary>
    public void SeleccionarNivel()
    {
        audioC.PlaySFX(seleccionar);
        PlayerPrefs.SetInt("M�sica", musica);
        PlayerPrefs.SetInt("SFX", sfx);
        Initiate.Fade("SeleccionNivel", Color.black, 2f);
    }

    /// <summary>
    /// Este m�todo deber� guardar en los PlayerPrefs los ajustes de sonido. La raz�n por la que empleo PlayerPrefs aqu� y no lo incluyo en el archivo de guardado binario es porque el hecho de que el jugador
    /// modifique estos valores no har� que el juego sea afectado de manera negativa (por ejemplo, cambiando cu�nta vida tiene de un combate para otro, en qu� nivel se encuentra, etc.). Son s�lo ajustes opcionales
    /// que no tienen impacto en la jugabilidad en s� y son meramente para acomodar la experiencia del jugador. tambi�n llevar� al jugador a la pantalla de t�tulo
    /// </summary>
    public void GuardarCambios()
    {
        audioC.PlaySFX(seleccionar);
        PlayerPrefs.SetInt("M�sica", musica);
        PlayerPrefs.SetInt("SFX", sfx);
        Initiate.Fade("Titulo", Color.black, 2f);
    }

    /// <summary>
    /// Este m�todo cancela los cambios hechos en esta pantalla y no los har� efectivos, y en el proceso devolver� al jugador a la pantalla de t�tulo
    /// </summary>
    public void CancelarAccion()
    {
        audioC.PlaySFX(seleccionar);
        sourceMusica.volume = PlayerPrefs.GetInt("M�sica") * 0.1f;
        sourceSFX.volume = PlayerPrefs.GetInt("SFX") * 0.1f;
        Initiate.Fade("Titulo", Color.black, 2f);
    }

    #endregion


    #region M�todos auxiliares

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
