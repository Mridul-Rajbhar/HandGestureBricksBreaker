using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    #region Private Variables

    #endregion

    #region Public Variables
    public Text Score;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Score.text = "Your Score: " + BallMechanics.score;
    }

    public void restart()
    {
        SceneManager.LoadScene("Play");
    }

}
