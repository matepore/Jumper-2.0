using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public AudioSource audioSRC;

    void Start()
    {
        audioSRC = this.GetComponent<AudioSource>();
    }

    public void Jugar(string dif)
    {
        ManejadorVidas.dificultad = dif;
        ManejadorVidas.esVidaInicial = true;
        SceneManager.LoadScene("PrimerEscenario");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void CerrarJuego()
    {
        Application.Quit();
    }
}
