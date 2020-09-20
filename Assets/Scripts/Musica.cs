using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Musica : MonoBehaviour
{
    public AudioSource audioSRC;
    public AudioClip cancionMP;
    public AudioClip cancionPE;
    public AudioClip cancionSE;
    public AudioClip cancionTE;
    public AudioClip cancionEF;
    public AudioClip cancionFT;

    public int numEscena;

    // Start is called before the first frame update
    void Start()
    {
        audioSRC = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        numEscena = SceneManager.GetActiveScene().buildIndex;
        if(numEscena == 1)
        {
            audioSRC.clip = cancionMP;
            if (SceneManager.GetActiveScene().name == "MenuPrincipal")
            {
                if (!audioSRC.isPlaying)
                {
                    audioSRC.Play();
                }
            }
        }
        else if(numEscena == 2)
        {
            audioSRC.clip = cancionPE;
            if(SceneManager.GetActiveScene().name == "PrimerEscenario")
            {
                if (!audioSRC.isPlaying)
                {
                    audioSRC.Play();
                }
            }
        }
        else if(numEscena == 3)
        {
            audioSRC.clip = cancionSE;
            if (SceneManager.GetActiveScene().name == "SegundoEscenario")
            {
                if (!audioSRC.isPlaying)
                {
                    audioSRC.Play();
                }
            }
        }
        else if(numEscena == 4)
        {
            audioSRC.clip = cancionTE;
            if (SceneManager.GetActiveScene().name == "TercerEscenario")
            {
                if (!audioSRC.isPlaying)
                {
                    audioSRC.Play();
                }
            }
        }
        else if(numEscena == 5)
        {
            audioSRC.clip = cancionEF;
            if (SceneManager.GetActiveScene().name == "EscenarioFinal")
            {
                if (!audioSRC.isPlaying)
                {
                    audioSRC.Play();
                }
            }
        }
        else if (numEscena == 6)
        {
            audioSRC.clip = cancionPE;
            if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                if (!audioSRC.isPlaying)
                {
                    audioSRC.Play();
                }
            }
        }
        else if (numEscena == 7)
        {
            audioSRC.Stop();
            audioSRC.clip = null;
        }
        else if (numEscena == 8)
        {
            audioSRC.Stop();
            audioSRC.clip = null;
        }
        else if (numEscena == 9)
        {
            audioSRC.Stop();
            audioSRC.clip = null;
        }
        else if(numEscena == 10)
        {
            audioSRC.clip = cancionFT;
            if (SceneManager.GetActiveScene().name == "FinalTexto")
            {
                if (!audioSRC.isPlaying)
                {
                    audioSRC.Play();
                }
            }
        }
    }
}
