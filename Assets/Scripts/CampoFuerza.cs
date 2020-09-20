using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CampoFuerza : MonoBehaviour
{
    public SpriteRenderer miSpriteRenderer;
    public Animator anim;
    public string escena;

    // Start is called before the first frame update
    void Start()
    {
        miSpriteRenderer = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ManejadorVidas.generadores <= 0)
        {
            miSpriteRenderer.enabled = false;
            anim.enabled = false;
            CambiarEscena();
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene(escena);
    }
}
