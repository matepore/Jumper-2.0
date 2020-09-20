using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejadorVidas : MonoBehaviour
{
    public static int vidas;
    private string escenaActual;
    public static bool esVidaInicial = true;
    public static string dificultad = "Normal";
    public static int generadores = 3;

    // Start is called before the first frame update
    void Start()
    {
        escenaActual = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (esVidaInicial)
        {
            if(dificultad == "Normal")
            {
                vidas = 3;
                esVidaInicial = false;
            }
            else if(dificultad == "Facil")
            {
                vidas = 5;
                esVidaInicial = false;
            }
            else if(dificultad == "Dificil")
            {
                vidas = 1;
                esVidaInicial = false;
            }
        }
    }
}
