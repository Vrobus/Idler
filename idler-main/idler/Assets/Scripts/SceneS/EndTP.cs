using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTP : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("EndGame");
    }
}