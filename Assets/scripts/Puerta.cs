using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public GameObject Keys;
    public GameObject Abrir;
    public int abierto;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            if (Keys == null)
            {
                Destroy(this.gameObject);
                Instantiate(Abrir, transform.position, transform.rotation);
            }
        }
    }



}
