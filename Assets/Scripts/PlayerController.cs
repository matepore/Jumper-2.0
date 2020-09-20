using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Personaje dueño;

    // Start is called before the first frame update
    void Start()
    {
        dueño = this.GetComponent<Personaje>();
    }

    // Update is called once per frame
    void Update()
    {
        dueño.Move(Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dueño.Jump();
        }
        //Con esto controlo los saltos mas cortos, para dar impresión de control en los saltos
        if (Input.GetKeyUp(KeyCode.Space))
        {
            dueño.AcortarSalto();
        }

        //Sección trucos/cheats
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            dueño.CheatSaltosInfinitos();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            dueño.CheatReinicio();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            dueño.CheatVidasInfinitas();
        }

        Camera.main.transform.position = this.transform.position + Vector3.back * 10;
    }
}
