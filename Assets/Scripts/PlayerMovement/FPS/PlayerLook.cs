using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Tag per inserire un titolo in grassetto nel componente su unity
    // Approfondisci su: https://docs.unity3d.com/ScriptReference/HeaderAttribute.html
    [Header("References")]

    // [SerializeField] Rendo una variabile privata leggibile nel componente su unity 
    //  Approfondisci su: https://docs.unity3d.com/ScriptReference/SerializeField.html

    // Variabile di tipo float per assegnare la sensibilità sull'asse x
    [SerializeField] private float sensX = 100f;

    // Variabile di tipo float per assegnare la sensibilità sull'asse x
    [SerializeField] private float sensY = 100f;


    // Variabile Transform per prendere la posizione della camera
    [SerializeField] Transform cam = null;
    [SerializeField] Transform orientation = null;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private void Start()
    {
        // Blocco il cursore del mouse nella scena di gioco
        Cursor.lockState = CursorLockMode.Locked;

        //Rendo il cursore del muouse invisible
        Cursor.visible = false;
    }

    private void Update()
    {
        // Assegno il valore degli input dati dal giocatore (-1, 0, 1)
        //  Approfondisci su: https://docs.unity3d.com/ScriptReference/Input.GetAxisRaw.html
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        // Calcolo la rotazione del personaggio moltiplicando l'input del giocatore * la sensibilità del mouse * moltiplicatore
        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Assegno la nuova rotazione calcolata alla camera ed al personaggio
        // Approfondisci su: https://docs.unity3d.com/ScriptReference/Quaternion.html
        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
