using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPerder : MonoBehaviour
{
    public GameObject menuPerderUI;
    public static bool perdi = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (perdi)
        {
            Perder();
        }
    }

    public void Perder()
    {
        menuPerderUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reiniciar()
    {
        menuPerderUI.SetActive(false);
        Time.timeScale = 1f;
        ManejadorVidas.esVidaInicial = true;
        perdi = false;
        SceneManager.LoadScene("PrimerEscenario");
    }

    public void CargarMenu()
    {
        Time.timeScale = 1f;
        ManejadorVidas.esVidaInicial = true;
        perdi = false;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void CerrarJuego()
    {
        Application.Quit();
    }
}
