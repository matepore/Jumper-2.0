using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Portal : MonoBehaviour
{
    public string nombreEscena;
    public AudioSource audioSRC;

    void Start()
    {
        audioSRC = this.GetComponent<AudioSource>();
    }

    public void CambiarEscena(string nombreEscena)
    {
        audioSRC.Play();
        SceneManager.LoadScene(nombreEscena);
    }
}
