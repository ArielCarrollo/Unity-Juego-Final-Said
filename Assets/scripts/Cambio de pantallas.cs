using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiodepantallas : MonoBehaviour
{
    public string Cargar;
    public string Cargar2;
    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
    public void CargarEscena2(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
    public void Chau()
    {
        Application.Quit();
    }

}
