using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public TMPro.TMP_Text highscore;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highscore.text = highScore.ToString();
    }
   
    void Update()
    {
        
        // Verificar si se ha presionado una tecla
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Cargar la siguiente escena
            SceneManager.LoadScene("Level01");
        }
    }
}