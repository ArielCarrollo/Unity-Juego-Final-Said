using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    private AudioSource ahhhh;
    public float SpeedX;
    private Rigidbody2D _comRigiBody;
    private float horizontal;
    public Transform Detector;
    public float raycast;
    public bool Isground;
    public LayerMask Detectar;
    public bool Saltar;
    public float distancia;
    private SpriteRenderer Sprite;
    public int llave = 0;
    public GameObject muro;
    public Animator Mo;
    public GameObject text;
    public GameObject Hongo;
    public int Ingrediente=0;
    
    void Awake()
    {
        Mo = GetComponent<Animator>();
        _comRigiBody = GetComponent<Rigidbody2D>();
        ahhhh = GetComponent<AudioSource>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Isground = Physics2D.Raycast(Detector.position, new Vector2(0, -1), raycast, Detectar);
        if (horizontal < 0)
        {
            Sprite.flipX = false;
        }
        if (0 < horizontal)
        {
            Sprite.flipX = true;
        }
        Debug.DrawRay(Detector.position, new Vector2(0, -1) * raycast, Color.yellow);
        if (Input.GetAxis("Jump") != 0 && Isground == true)
        {
            Saltar = true;
        }
        else
        {
            Saltar = false;
        }

        correr(horizontal);
        salud();
            }
    private void correr(float direccion)
    {
        if (direccion != 0)
        {
            Mo.SetBool("Mover", true);
        }
        else
        {
            Mo.SetBool("Mover", false);
        }
    }
    void FixedUpdate()
    {
        _comRigiBody.velocity = new Vector2(horizontal * SpeedX, _comRigiBody.velocity.y);
       if(Saltar == true)
        {
            _comRigiBody.AddForce(new Vector2(0, distancia), ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision2)
    {
        if (collision2.gameObject.tag == "Caida")
        {
            muere();
        }

        if (collision2.gameObject.tag == "Enemigo")
        {
            Mo.SetBool("Muerte", true);
            ahhhh.Play();
            muere(1f);
        }
        if (collision2.gameObject.tag == "Nivel2")
        {
            SceneManager.LoadScene("Nivel 1.5");
        }
        if (collision2.gameObject.tag == "Hongo")
        {
            Ingrediente = 1;
            Destroy(Hongo.gameObject);
        }
        if (collision2.gameObject.tag == "Escapar"&& Ingrediente==1)
        {
            SceneManager.LoadScene("Final");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Caida")
        {
            muere();
        }
        if (collision.gameObject.tag == "Enemigo")
        {
            Mo.SetBool("Muerte", true);
            ahhhh.Play();
            muere(1f);
        }
        if (collision.gameObject.tag == "Llave")
        {
            llave = llave + 1;
            Destroy(muro.gameObject);
        }
       
    }
    private void muere()
    {
        Destroy(this.gameObject);
    }
    private void muere(float delay)
    {
        Destroy(this.gameObject, delay);
    }
  
    public void salud()
    {
        if(1000 <= text.GetComponent<veneno>().Venom)
        {
            Destroy(this.gameObject);
        }
    }
}