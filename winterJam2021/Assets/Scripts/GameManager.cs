using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    ConveyorBelt conveyorBelt;


    private void Awake() {
        HandleGameManager();
        conveyorBelt = FindObjectOfType<ConveyorBelt>();
    }

    public void HandleGameManager() {
        if (instance != null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void DidPressPass() {
        conveyorBelt.StartConveyorBelt();
        Debug.Log("Handling pass");
    }

    public void DidPressScan() {
        Debug.Log("Handling scan");
    }

    public void DidPressRemove() {
        Debug.Log("Handling remove");
    }
}
