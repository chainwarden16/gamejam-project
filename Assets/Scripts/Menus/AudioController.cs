using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource sourceMusica, sourceSFX;
    public AudioClip musicaTitulo;
    public AudioClip musicaDerrota;
    public AudioClip musicaSala1;
    public AudioClip musicaSala2;
    public AudioClip musicaSala3;
    public AudioClip musicaVictoria;
    public AudioClip musicaAlarma;

    [SerializeField]
    int volumenMusica;
    [SerializeField]
    int volumenSFX;


    public static AudioController _instance;

    #region AudioController singleton

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

    #endregion

    private void Start()
    {

        sourceMusica.clip = musicaTitulo;
        volumenMusica = PlayerPrefs.GetInt("M�sica", 10);
        volumenSFX = PlayerPrefs.GetInt("SFX", 10);
        sourceMusica.volume = volumenMusica * 0.1f;
        sourceSFX.volume = volumenSFX * 0.1f;
        sourceMusica.Play();
    }

    #region Reproduccion de sonidos

    public void PlaySong(AudioClip aud)
    {
        sourceMusica.clip = aud;
        sourceMusica.Play();
    }

    public void PlaySFX(AudioClip aud)
    {
        if (!sourceSFX.isPlaying)
        {

            sourceSFX.PlayOneShot(aud);

        }
    }

    #endregion

}
