using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class veneno : MonoBehaviour
{
    public GameObject Ex;
    public Text texto;
    public GameObject V;
    public float Venom;
    private int Extra = 0;

    void Update()
    {
            Salud();
            Salud(30f);
            Venom += 0.039f;
        
    }

    public void Salud(float cantidadx)
    {
        if (Ex == null && Extra < 1)
        {
            Venom -= cantidadx;
            Extra = Extra +1;
        }
    }
    public void Salud()
    {

        Venom = Venom-Time.deltaTime;
        if (V != null)
        {
            texto.text = "Veneno en tu cuerpo : " + Venom.ToString("f0");

        }
        
    }
    public static veneno operator +(veneno v, float cantidad)
    {
        v.Venom -= cantidad;

        v.Venom = Mathf.Max(v.Venom, 0f);

        return v;
    }
  
}
