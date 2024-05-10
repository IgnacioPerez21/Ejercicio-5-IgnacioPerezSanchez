using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public TMPro.TMP_Text puntos;
    public TMPro.TMP_Text highscore;
    public TMPro.TMP_Text tiempo;
    public TMPro.TMP_Text vidasText; // Texto para mostrar las vidas restantes
  
     void Start()
    {
        GameManager.Instance.HUD = this;     
        

    }

    void Update()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highscore.text = highScore.ToString();
    }


        public void MostrarPuntos(int enemys)
        {
            puntos.text = enemys.ToString();
        }

        // Metodo para actualizar el texto de las vidas restantes del jugador
        public void ActualizarVidas(int vidas)
        {
            vidasText.text = vidas.ToString();
        }

        public void MostrarTiempo(int t)
        {
            tiempo.text = t.ToString();
        }

    

}
