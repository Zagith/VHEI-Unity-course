using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    // Variabile Transform per prendere la posizione della camera
    public Transform cameraPosition = null;

    void Update()
    {
        // Assegno la posizione della camera all'oggetto che ha questo script
        transform.position = cameraPosition.position;
    }
}
