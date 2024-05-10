using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    private float startTime;
    public float timeToLoadNextScene = 10f; // Tiempo en segundos antes de cargar la siguiente escena

    void Start()
    {
        // Guardar el tiempo de inicio cuando se carga la escena
        startTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Time.time - startTime >= timeToLoadNextScene)
        {
            // Cargar la siguiente escena
            SceneManager.LoadScene("Intro");
        }

    }
}
