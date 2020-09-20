using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiadorEscena : MonoBehaviour
{
    public bool cambiar = false;
    public string escena;
    public AudioSource audioSRC;
    public AudioClip salto;
    public AudioClip portal;
    public bool rSalto = false;
    public bool rPortal = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSRC = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rSalto)
        {
            audioSRC.clip = salto;
            if (!audioSRC.isPlaying)
            {
                audioSRC.Play();
            }
            //rSalto = false;
        }

        if (rPortal)
        {
            audioSRC.clip = portal;
            if (!audioSRC.isPlaying)
            {
                audioSRC.Play();
            }
            //rPortal = false;
        }

        if (cambiar)
        {
            CambiarEscena();
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene(escena);
    }
}
