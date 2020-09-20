using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Trampolin : MonoBehaviour
{
    public AudioSource audioSRC;
    public static bool reproducirSonido = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSRC = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reproducirSonido)
        {
            audioSRC.Play();
            reproducirSonido = false;
        }
    }
}
