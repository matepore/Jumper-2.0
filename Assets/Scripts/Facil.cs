using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facil : MonoBehaviour
{
    private SpriteRenderer miSpriteRenderer;
    private BoxCollider2D miBoxCollider2D;
    private BoxCollider2D childBoxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        miBoxCollider2D = this.GetComponent<BoxCollider2D>();
        miSpriteRenderer = this.GetComponent<SpriteRenderer>();
        childBoxCollider2D = this.GetComponentInChildren<BoxCollider2D>();
        

        if (ManejadorVidas.dificultad == "Facil")
        {
            miBoxCollider2D.enabled = true;
            miSpriteRenderer.enabled = true;
            childBoxCollider2D.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
