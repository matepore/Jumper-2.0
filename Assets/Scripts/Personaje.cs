using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class Personaje : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer miRenderer;
    public float speed;
    public Rigidbody2D rigid;
    public float horizontal;
    public float jumpForce;
    public int saltosDisponibles;
    public int saltosMaximos;
    public float valorAcortadorSalto;
    public int vidas;
    public AudioSource audioSRC;
    public AudioClip salto;
    public AudioClip caida;
    public AudioClip moverse;

    private bool cheatSaltosInfinitosOn = false;
    private bool cheatVidasInfinitasOn = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        // Se le setea la vida del personaje a la variable del animator para controlar la animación de muerte
        anim.SetInteger("Life", vidas);
        //Se pone como primer animación a la de caida para que siempre tenga la animación correcta por si está en el aire
        anim.Play("En el aire");

        miRenderer = this.GetComponent<SpriteRenderer>();
        rigid = this.GetComponent<Rigidbody2D>();
        audioSRC = this.GetComponent<AudioSource>();

        saltosDisponibles = saltosMaximos;
    }

    // Update is called once per frame
    void Update()
    {
        vidas = ManejadorVidas.vidas;
        GameObject.Find("CantVidas").GetComponent<TextMeshProUGUI>().text = ManejadorVidas.vidas.ToString();

        if(SceneManager.GetActiveScene().name == "EscenarioFinal")
        {
            GameObject.Find("CantGeneradores").GetComponent<TextMeshProUGUI>().text = ManejadorVidas.generadores.ToString();
        }
        

        Vector3 realVelocity;
        realVelocity.x = speed * horizontal;
        realVelocity.y = rigid.velocity.y;
        realVelocity.z = 0;

        rigid.velocity = realVelocity;

        //Acá verifico para que lado está mirando y así manejo correctamente las animaciones
        if (horizontal > 0)
        {
            miRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            miRenderer.flipX = true;
        }

        //Estoy seteando una variable del blend tree para que maneje animaciones con pulsaciones de axis y solo sea positiva con el Absolute
        anim.SetFloat("Velocidad Movimiento", Mathf.Abs(horizontal));

        anim.SetFloat("Jump State", rigid.velocity.y);


        //Le hago un update a la variable del animator
        anim.SetInteger("Life", vidas);

        if (rigid.velocity.x != 0 && rigid.velocity.y == 0)
        {
            audioSRC.clip = moverse;
            if (!audioSRC.isPlaying)
            {
                audioSRC.Play();
            }
        }
    }

    public void Move(float dirX)
    {
        horizontal = dirX;
    }

    public void Jump()
    {
        if (saltosDisponibles > 0)
        {
            anim.Play("En el aire");
            audioSRC.clip = salto;
            audioSRC.Play();
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector3.up * jumpForce * rigid.gravityScale * rigid.mass, ForceMode2D.Impulse);
            saltosDisponibles--;
        }
    }

    //Esta función acorta el tiempo en el aire del salto para cuando el jugador deja de presionar el botón de saltar. Esto para simular saltos cortos
    public void AcortarSalto()
    {
        //Acá pregunto si el jugador está subiendo, esto para aplicar el corte de salto en el momento justo y no aumentar la velocidad de caida
        if(rigid.velocity.y > 0)
        {
            //Creo una nueva velocity en la cual le paso la misma velocidad de x, luego reduzco el valor de velocidad en y
            rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * valorAcortadorSalto);
        }
    }

    public void CheatSaltosInfinitos()
    {
        if(cheatSaltosInfinitosOn == false)
        {
            cheatSaltosInfinitosOn = true;
            saltosMaximos = 132838;
            saltosDisponibles = saltosMaximos;
        }
        else
        {
            cheatSaltosInfinitosOn = false;
            saltosMaximos = 1;
            saltosDisponibles = saltosMaximos;
        }
    }

    public void CheatReinicio()
    {
        if(ManejadorVidas.dificultad == "Normal")
        {
            ManejadorVidas.vidas = 3;
        }
        else if(ManejadorVidas.dificultad == "Facil")
        {
            ManejadorVidas.vidas = 5;
        }
        else
        {
            ManejadorVidas.vidas = 1;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CheatVidasInfinitas()
    {
        if(cheatVidasInfinitasOn == false)
        {
            cheatVidasInfinitasOn = true;
            ManejadorVidas.vidas = 103214;
        }
        else
        {
            cheatVidasInfinitasOn = false;
            if (ManejadorVidas.dificultad == "Normal")
            {
                ManejadorVidas.vidas = 3;
            }
            else if (ManejadorVidas.dificultad == "Facil")
            {
                ManejadorVidas.vidas = 5;
            }
            else
            {
                ManejadorVidas.vidas = 1;
            }
        }
        
    }

    public void Reinicio()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            saltosDisponibles = saltosMaximos;
            anim.Play("Movimiento Tree");
            if(collision.gameObject.name != "Generador")
            {
                this.transform.parent = collision.transform;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Este trigger sirve para que el personaje pueda saltar justo un poco antes de tocar el suelo, para dar la ilusión de que los controles responden bien
        if (collider.gameObject.tag == "SaltarAntes")
        {
            saltosDisponibles = saltosMaximos;

            if(rigid.velocity.y < 0)
            {
                audioSRC.clip = caida;
                audioSRC.Play();
            }
        }

        //Este trigger llama a la funcion del portal que se encarga de cambiar de escenario y le pasa su misma variable por parametro que indica a que escenario cambiar
        if(collider.gameObject.tag == "Portal")
        {
            Portal portal = collider.gameObject.GetComponent<Portal>();
            portal.CambiarEscena(portal.nombreEscena);
        }

        //Este trigger sirve para un trampolin, genera un gran salto.
        if(collider.gameObject.tag == "Trampolin")
        {
            Trampolin.reproducirSonido = true;
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector3.up * 30, ForceMode2D.Impulse);
        }

        //Este trigger sirve para cuando el personaje toca las spikes y pierde una vida
        if(collider.gameObject.tag == "Spikes")
        {
            Spikes.reproducirSonido = true;
            if(ManejadorVidas.vidas > 0)
            {
                ManejadorVidas.vidas--;
                ManejadorVidas.generadores = 3;
                Reinicio();
            }
            else
            {
                MenuPerder.perdi = true;
            }
        }

        //Este trigger sirve para usar el objeto que activa gameobjects, en este caso lo uso para las spikes del escenario final
        if(collider.gameObject.tag == "TriggerActivador")
        {
            collider.gameObject.GetComponent<TriggerActivador>().ActivarObjeto();
        }

        //Este trigger sirve para detectar cuando el personaje toca un consumible de vida
        if(collider.gameObject.tag == "Consumible")
        {
            collider.GetComponent<Consumible>().SumarVida();
        }

        //Este trigger sirve para que cuando el personaje salte y caiga encima de un generador, llame a la funcion para achatar el generador
        if(collider.gameObject.tag == "Generador")
        {
            collider.GetComponentInParent<Generador>().Achatar();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            anim.Play("En el aire");
            this.transform.parent = null;
        }
    }
}
