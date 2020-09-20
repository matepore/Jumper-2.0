using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumible : MonoBehaviour
{
    public AudioSource audioSRC;
    public AudioClip agarrarVida;
    private bool sePuedeDestruir = false;
    private bool seAgarro = false;
    private SpriteRenderer miSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        audioSRC = this.GetComponent<AudioSource>();
        miSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sePuedeDestruir)
        {
            if (!audioSRC.isPlaying)
            {
                Destruirse();
            }
        }
    }

    public void SumarVida()
    {
        if (!seAgarro)
        {
            audioSRC.clip = agarrarVida;
            audioSRC.Play();
            ManejadorVidas.vidas++;
            miSpriteRenderer.enabled = false;
            sePuedeDestruir = true;
            seAgarro = true;
        }
    }

    void Destruirse()
    {
        Destroy(this.gameObject);
    }
}
