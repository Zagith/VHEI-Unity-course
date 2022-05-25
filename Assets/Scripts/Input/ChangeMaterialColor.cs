using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    public string messaggio;

    public Material materiale;

    string messaggioPrivat;

    // Start is called before the first frame update
    void Start()
    {
        // Prendo il componente MeshRenderer che sta sull'oggetto di questo script per accedere al materiale attuale
        materiale = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // Se il bottone premuto è spazio entra
        if (Input.GetKey(KeyCode.Space))
        {
            // Cambia il colore del materiale con il colore giallo
            materiale.color = Color.yellow;
        }
    }    
}
