using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//Para unir escenas

public class tiempo : MonoBehaviour
{
    
    public TextMeshProUGUI texto;
    public float varTiempo = 0;


  
    public TextMeshProUGUI textoTiempo;
    //public AudioSource audioPerdiste;
    // Start is called before the first frame update
    void Start()
    {
        
        textoTiempo.enabled = true;
      
    }

    // Update is called once per frame
    void Update()
    {
        varTiempo-=Time.deltaTime;
        texto.text = "" + varTiempo.ToString("f2");
        if (varTiempo <0 && Jugador.win == 0)
        {
            SceneManager.LoadScene(0);
            //audioPerdiste.Play();
        }
        
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("salida"))
        {
         
            textoTiempo.enabled = false;
            Time.timeScale = 0f;
            //Debug.Log("LO LOGRASTE, GANASTE, recogiste "+ monedas+" monedas") ;
        }
    }
}
