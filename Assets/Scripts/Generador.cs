using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public Transform miTransform;
    private bool estaAchatado = false;
    public AudioSource audioSRC;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.GetComponent<Transform>();
        audioSRC = this.GetComponent<AudioSource>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Achatar()
    {
        if (!estaAchatado)
        {
            miTransform.localScale += new Vector3(0f, -0.6f, 0f);
            audioSRC.Play();
            miTransform.position += new Vector3(0f, -1f, 0f);
            anim.enabled = false;
            ManejadorVidas.generadores--;
            estaAchatado = true;
        }
    }
}
