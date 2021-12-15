using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaDifficult : MonoBehaviour
{
    public static double difficult;

    public double difficultAux;

    public void SetDifficult()
    {
        difficult = difficultAux;
        SceneManager.LoadScene("SampleScene");
    }
}
