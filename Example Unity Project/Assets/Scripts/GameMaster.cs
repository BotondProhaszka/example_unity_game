using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour
{
    public void goToMainScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
