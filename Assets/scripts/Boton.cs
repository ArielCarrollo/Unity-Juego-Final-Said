using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boton : Cambiodepantallas
{
    public void AlNivel1()
    {
        CargarEscena(Cargar);
    }
    public void Almenú()
    {
        CargarEscena2(Cargar2);
    }
}
