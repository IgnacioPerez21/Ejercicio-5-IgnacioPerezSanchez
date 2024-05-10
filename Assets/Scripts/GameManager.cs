using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public int enemys = 0;
    public int tiempo = 60;
    private float startTime;

    
    public HUDManager HUD;
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }
   

    public void AddEnemy()
    {
        enemys++;
        HUD.MostrarPuntos(enemys);
        // Verificar si el puntaje actual es mayor que el puntaje más alto guardado
        if (enemys > PlayerPrefs.GetInt("HighScore", 0))
            {
                // Actualizar el puntaje más alto
                PlayerPrefs.SetInt("HighScore", enemys);
            }
        if(enemys >= 29)
        {
            SceneManager.LoadScene("Win");
        }
    }

    void Start()
    {
        startTime = Time.time; // Guarda el tiempo en el que comenzó el contador

    }

    void Update()
    {

        // Resta 1 a la variable cada segundo
        if (Time.time - startTime >= 1f)
        {
            tiempo--;
            startTime = Time.time; // Reinicia el tiempo de inicio
            HUD.MostrarTiempo(tiempo);
        }

       
        if (tiempo <= 0)
        {
            
            Debug.Log("La variable ha llegado a 0.");
            SceneManager.LoadScene("End");

        }

    }


}
