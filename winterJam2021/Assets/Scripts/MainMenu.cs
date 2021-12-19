using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private AudioSource source;

    private void Awake() {
        source = GetComponent<AudioSource>();    
    }
    private void Start() {
        source.Play();
    }

    public void PlayGame() {
        source.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GetMenu() {
        Debug.Log("Test");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
