using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPlayer : MonoBehaviour
{
    public int lives = 3; // Número inicial de vidas del jugador
    public float speed = 1f;

    private Animator _animator;
    public float maxLeft;
    public float maxRight;

    public GameObject shootPrefab;
    public SpriteRenderer laserSpriteRenderer;

    private bool _canFire = true;
    public HUDManager HUD; // Referencia al HUDManager para actualizar las vidas restantes

    public GameObject enemyPrefab;
    // Start is called before the first frame update

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }
    
  
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position = new Vector3( transform.position.x - (speed * Time.deltaTime), transform.position.y);
            transform.position = new Vector3(Mathf.Max(maxLeft, transform.position.x - (speed * Time.deltaTime)), transform.position.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            transform.position = new Vector3(Mathf.Min(maxRight, transform.position.x + (speed * Time.deltaTime)), transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_canFire)
            {
                _canFire = false;
                GameObject go = Instantiate(shootPrefab);
                //go.transform.position = this.transform.position;
                go.transform.position = laserSpriteRenderer.gameObject.transform.position;
                go.GetComponent<ControlShoot>().controlPlayer = this;
                laserSpriteRenderer.enabled = false;
            }
        }
    }

    public void CanFire()
    {
        _canFire = true;
        laserSpriteRenderer.enabled = true;
    }

    // Funcion para reducir las vidas del jugador cuando colisiona con un enemigo
    public void ReduceLives()
    {
        lives--; // Decrementa las vidas del jugador
        HUD.ActualizarVidas(lives); // Actualiza el HUD para mostrar las vidas restantes

        if (lives <= 0)
        {
            // Si el jugador se queda sin vidas, cargar la escena final
            SceneManager.LoadScene("End");
        }
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Si colisiona con un enemigo, reducir las vidas del jugador
            Debug.Log("Colisión con enemigo detectada");
           _animator.Play("AnimationExplotion");
            ReduceLives();
            
            

        }
        
    }
}
