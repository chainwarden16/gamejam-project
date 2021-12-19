using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Progreso del oponente")]
    [SerializeField]
    float contadorOponente = 70f; //420
    [SerializeField]
    int salaOponente;
    const float minimoTiempo = 420f; //420
    const float maximoTiempo = 480f; //480

    [Header("Progreso del jugador")]
    [SerializeField]
    bool estaReiniciandoSala = false;
    float contadorGameOver = 2f; //a los 4 segundos, el juego terminará

    [Header("Puzle actual para comodín")]
    int puzleActual;

    [Header("Puzles ya resueltos")]
    [Tooltip("Van del 1 al 9,empezando por el 0. Una vez todos estén resueltos se irá a la pantalla de victoria")]
    [SerializeField]
    List<bool> puzlesResueltos = new List<bool>() { false, false, false, false, false, false, false, false, false };

    [Header("Audio")]
    AudioController audioC;
    bool haEmpezadoASonarAlarma;

    #region Métodos de Unity

    public static GameManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        salaOponente = PlayerPrefs.GetInt("SalaActualOponente", 1);
        ReiniciarEstadoContador();

        audioC = FindObjectOfType<AudioController>();

    }

    private void Update()
    {
        //El jugador compite contra un npc al que no ve. Si el progreso del npc es tal que va a hacer que supere la sala antes que el jugador, habrá una pequeña alarma visual y sonora que te lo indique.
        /*
         * Si el npc superara la escena, entonces se reiniciaría la sala, lo que llevaría a que la escena se cargue de nuevo. Antes de que se reinicie, se guaradrá el progreso del oponente.
         * 
         * Importante: debido a esto, las soluciones del puzles se deberán recalcular en el start de cada puzle, no en este método
         */

        if(contadorOponente < 60f && !haEmpezadoASonarAlarma)
        {
            if(audioC != null)
            {
                audioC.PlaySong(audioC.musicaAlarma);
                haEmpezadoASonarAlarma = true;
            }
        }


        if (contadorOponente <= 0f && salaOponente < 3)
        {


            if (!estaReiniciandoSala)
            {
                salaOponente++;

            }

            estaReiniciandoSala = true;

            GuardarProgresoOponente();

            ReiniciarEstadoContador();

            switch (PlayerPrefs.GetInt("EscenaActual"))
            {
                case 7:

                    puzlesResueltos[3] = false;
                    puzlesResueltos[4] = false;
                    puzlesResueltos[5] = false;

                    Initiate.Fade("Sala2", Color.black, 1f);
                    break;
                case 11:

                    puzlesResueltos[6] = false;
                    puzlesResueltos[7] = false;
                    puzlesResueltos[8] = false;

                    Initiate.Fade("Sala3", Color.black, 1f);

                    break;
                default:

                    puzlesResueltos[0] = false;
                    puzlesResueltos[1] = false;
                    puzlesResueltos[2] = false;

                    Initiate.Fade("Sala1 old", Color.black, 1f);

                    break;
            }


        }
        else if (salaOponente == 3 && contadorOponente < 0f)
        {

            estaReiniciandoSala = true;
            //Aparece un mensaje que dice que estarás atrapado aquí para siempre, y luego Game Over
            if (contadorGameOver <= 0f)
            {
                for (int i = 0; i < puzlesResueltos.Count; i++)
                {
                    puzlesResueltos[i] = false;
                }

                if(audioC != null)
                {
                    audioC.PlaySong(audioC.musicaDerrota);
                }

                Initiate.Fade("GameOver", Color.black, 1f);
            }
            else
            {
                contadorGameOver -= Time.deltaTime;
            }

        }

        else
        {
            contadorOponente -= Time.deltaTime;
        }

    }

    #endregion

    public void GuardarSalaCompletada(int numero, string nombreEscena)
    {
        PlayerPrefs.SetInt("EscenaActual", numero);
        ReiniciarEstadoContador();
        SceneManager.LoadScene(nombreEscena);
    }

    //Detiene el contador de tiempo y lo resetea dependiendo de la cantidad
    public void ReiniciarEstadoContador()
    {
        contadorOponente = Random.Range(minimoTiempo, maximoTiempo);
        estaReiniciandoSala = false;

        //Según en qué sala estés, se reproduce un sonido de fondo u otro
        ReproducirMusicaSala();
    }

    public void GuardarProgresoOponente()
    {
        PlayerPrefs.SetInt("SalaActualOponente", salaOponente);
    }

    public void ReproducirMusicaSala()
    {
        audioC = FindObjectOfType<AudioController>();

        switch (PlayerPrefs.GetInt("EscenaActual"))
        {
            case 7:

                audioC.PlaySong(audioC.musicaSala2);

                break;

            case 11:
                
                audioC.PlaySong(audioC.musicaSala3);

                break;

            default:

                audioC.PlaySong(audioC.musicaSala1);

                break;
        }
    }

    public int GetPuzleActual()
    {
        return puzleActual;
    }

    public void SetPuzleActual(int numero)
    {
        puzleActual = numero;
    }

    public List<bool> GetPuzlesResueltos()
    {
        return puzlesResueltos;
    }

    public void SetPuzleResuelto(int indice, bool resultado)
    {
        if (indice <= puzlesResueltos.Count - 1)
        {

            puzlesResueltos[indice] = resultado;

        }
    }

}
