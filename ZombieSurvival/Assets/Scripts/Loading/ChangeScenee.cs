using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenee : MonoBehaviour
{
    [SerializeField] string cena;
    
    public void ChangeSc()
    {
        LoadingScreen.instance.ChangeScene(cena);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
