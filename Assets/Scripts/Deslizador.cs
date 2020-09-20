using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Deslizador : MonoBehaviour
{
    private float velocidad = 0f;
    public Rigidbody2D rigid;
    public bool esIzquierda = false;
    public AudioSource audioSRC;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        audioSRC = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Hago que se mueva mediante transform porque sino no puedo hacer que el personaje se mueva con la plataforma
        if (!esIzquierda)
        {
            this.transform.position += Vector3.right * velocidad * Time.deltaTime;
        }
        else
        {
            this.transform.position += Vector3.right * (-velocidad) * Time.deltaTime;
        }

        //Hago que el velocity del rigid body sea cero para que el personaje no mande a volar a la plataforma al tocarla en los costados
        rigid.velocity = Vector3.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Personaje")
        {
            velocidad = 5f;
            audioSRC.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        velocidad = 0f;
        audioSRC.Stop();
    }
}
