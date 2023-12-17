using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantaAsmatico : MonoBehaviour
{
    public GameObject Objetivo;
    public float Velocidad;

    private void Update()
    {
        seguir();
        seguir(1f);
    }
    private void seguir()
    {
        if (Objetivo != null)
        {
            transform.position = Vector2.MoveTowards(this.transform.position,
            Objetivo.transform.position, Velocidad * Time.deltaTime);
        }
    }
    private void seguir(float delay)
    {
        if (Objetivo == null)
        {
            Destroy(this.gameObject, delay);
        }
    }
}