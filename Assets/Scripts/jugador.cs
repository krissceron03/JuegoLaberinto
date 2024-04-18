using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    
    public float velocidad = 0;
    Rigidbody miRigidbody;
    Vector3 posicionInicial;
    int vidas = 3;
    int monedas = 0;
    public static int win = 0;
    bool salidaJugador;
    public AudioSource audioMonedas;
    public AudioSource audioEnemigos;
    public AudioSource audioGanaste;
    public AudioSource audioPerdiste;
    //UI
    public TextMeshProUGUI textoMonedas;
    public TextMeshProUGUI textoGanaste;
    public TextMeshProUGUI textoVidas;
    public TextMeshProUGUI textoPerdiste;
    public TextMeshProUGUI textoTiempo;
    // Start is called before the first frame update
    void Start()
    {
        miRigidbody = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        textoGanaste.enabled = false;
        textoPerdiste.enabled = false;
        textoTiempo.enabled = true;
        salidaJugador = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!salidaJugador)
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            //Añadimos fuerza en el eje x y z
            miRigidbody.AddForce(new Vector3(horizontal, 0, vertical) * velocidad);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("salida"))
        {
            salidaJugador = true;
            textoGanaste.enabled=true;
            win = 1;
            miRigidbody.velocity = Vector3.zero;
            miRigidbody.angularVelocity = Vector3.zero;
            audioGanaste.Play();
            textoTiempo.enabled=false;

            //Debug.Log("LO LOGRASTE, GANASTE, recogiste "+ monedas+" monedas") ;
        }
        else if (other.CompareTag("enemigo"))
        {
            audioEnemigos.Play();
            miRigidbody.MovePosition(posicionInicial);
            miRigidbody.velocity= Vector3.zero;
            miRigidbody.angularVelocity= Vector3.zero;
            monedas = 0;
            textoMonedas.text = "Monedas: 0";
            vidas = vidas - 1;
            textoVidas.text = "Vidas = " + vidas;
            if (vidas == 0)
            {
                salidaJugador = true;
                //textoPerdiste.enabled = true;
                //audioPerdiste.Play();
                SceneManager.LoadScene(0);
                miRigidbody.velocity = Vector3.zero;
                miRigidbody.angularVelocity = Vector3.zero;
                
            }
        }
        else if (other.CompareTag("moneda"))
        {
            other.gameObject.SetActive(false);
            monedas = monedas +1;
            textoMonedas.text = "Monedas: " + monedas;
            audioMonedas.Play();
        }
    }
}
