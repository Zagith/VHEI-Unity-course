using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RND_Manager : MonoBehaviour
{
    // Variabile di tipo AudioClip per le tracce audio, Array [] per inserire più clip insieme
    public AudioClip[] clips;

    // Variabile per prendere il componente AudioSource per gestire l'audio in scena
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        // Calcolo per prendere un valore randomico da 0 alla lunghezza dell'array (se ad esempio ci sono due tracce audio sarà 1)
        // Approfondisci su: https://docs.unity3d.com/ScriptReference/Random.Range.html
        int rnd = Random.Range(0,clips.Length);

        // Assegno la clip randomica all'audio source
        audioSource.clip = clips[rnd];

    }
}
