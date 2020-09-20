using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ManejadorMixer : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioMixerSnapshot snapNoPausado;
    public AudioMixerSnapshot snapPausado;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SonidoPausado()
    {
        snapPausado.TransitionTo(1);
    }

    public void SonidoNoPausado()
    {
        snapNoPausado.TransitionTo(0.2f);
    }
}
