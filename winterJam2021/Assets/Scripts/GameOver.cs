using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void TryAgain() {
        LevelManager.instance.DestroyLevelManager();
        GameManager.instance.DestroyGameManager();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void GetMainMenu() {
        Debug.Log("Test");
        SceneManager.LoadScene(0);
    }
}
