using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nameScena;
    
    public void ChangeS()
    {
        SceneManager.LoadScene(nameScena);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
