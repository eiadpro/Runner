using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public void Startgame()
    {
        SceneManager.LoadScene(1) ;
    }
    public void endgame()
    {
        Application.Quit();
    }
    public void retrn()
    {
        SceneManager.LoadScene(0);
    }


}
