using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    //Referencia del jugador
    public GameObject jugador;
    //vector que me indica el desplazamiento del jugador y la cámara
    Vector3 distancia;
    // Start is called before the first frame update
    void Start()
    {
        distancia =  transform.position- jugador.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = jugador.transform.position+distancia;
    }
}
