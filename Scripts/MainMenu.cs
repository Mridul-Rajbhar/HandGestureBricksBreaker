using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        
        SceneManager.LoadScene("Play");
    }
    public void ApplicationQuit()
    {
        Application.Quit();
    }
}
