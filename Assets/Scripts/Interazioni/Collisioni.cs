using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisioni : MonoBehaviour
{
    // PER POTER FUNZIONARE LO SCRIPT C'è BISOGNO DI INSERIRE UN COLLIDER ALL'OGGETTO
    
    public Animator anim;

    // Gestione collisioni 3D

    // Funzione che verrà richiamata quando l'oggetto con questo script colliderà con un altro oggetto
    void OnCollisionEnter(Collision col)
    {
        // Check se il tag dell'oggetto con cui collide è uguale ad "Obstacle"
        if (col.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collido " + col.gameObject.name);

            // Cambio il parametro Die dell'animazione a true
            anim.SetBool("Die", true);
        }
    }

    // Funzione che verrà richiamata quando l'oggetto con questo script colliderà continuamente con un altro oggetto
    void OnCollisionStay(Collision col)
    {
        // Check se il tag dell'oggetto con cui collide è uguale ad "Obstacle"
        if (col.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collido " + col.gameObject.name);

            // Cambio il parametro Die dell'animazione a true
            anim.SetBool("Die", true);
        }
    }

    // Funzione che verrà richiamata quando l'oggetto con questo script uscirà dalla collisione con un altro oggetto
    void OnCollisionExit(Collision col)
    {
        // Check se il tag dell'oggetto con cui collide è uguale ad "Obstacle"
        if (col.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collido " + col.gameObject.name);

            // Cambio il parametro Die dell'animazione a true
            anim.SetBool("Die", true);
        }
    }

    // Gestione collisioni 2D

    // Funzione che verrà richiamata quando l'oggetto con questo script colliderà con un altro oggetto
    void OnCollisionEnter2D(Collision2D col)
    {
        // Check se il tag dell'oggetto con cui collide è uguale ad "Obstacle"
        if (col.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collido " + col.gameObject.name);

            // Cambio il parametro Die dell'animazione a true
            anim.SetBool("Die", true);
        }
    }

    // Funzione che verrà richiamata quando l'oggetto con questo script colliderà continuamente con un altro oggetto
    void OnCollisionStay2D(Collision2D col)
    {
        // Check se il tag dell'oggetto con cui collide è uguale ad "Obstacle"
        if (col.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collido " + col.gameObject.name);

            // Cambio il parametro Die dell'animazione a true
            anim.SetBool("Die", true);
        }
    }

    // Funzione che verrà richiamata quando l'oggetto con questo script uscirà dalla collisione con un altro oggetto
    void OnCollisionExit2D(Collision2D col)
    {
        // Check se il tag dell'oggetto con cui collide è uguale ad "Obstacle"
        if (col.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collido " + col.gameObject.name);

            // Cambio il parametro Die dell'animazione a true
            anim.SetBool("Die", true);
        }
    }
}
