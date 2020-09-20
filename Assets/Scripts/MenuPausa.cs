using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool JuegoPausado = false;

    public GameObject menuPausaUI;
    private ManejadorMixer mixer;

    void Start()
    {
        mixer = GameObject.Find("ManejadorJuego").GetComponent<ManejadorMixer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoPausado)
            {
                Renaudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Renaudar()
    {
        menuPausaUI.SetActive(false);
        mixer.SonidoNoPausado();
        Time.timeScale = 1f;
        JuegoPausado = false;
    }

    void Pausar()
    {
        menuPausaUI.SetActive(true);
        mixer.SonidoPausado();
        Time.timeScale = 0f;
        JuegoPausado = true;
    }

    public void CargarMenu()
    {
        mixer.SonidoNoPausado();
        Time.timeScale = 1f;
        ManejadorVidas.esVidaInicial = true;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void CerrarJuego()
    {
        Application.Quit();
    }
}
