using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] float scanDuration = 5f;

    public static GameManager instance;

    public int missedBoxes = 0;
    public int caughtBoxes = 0;
    public int scansRemaining = 10;

    ConveyorBelt conveyorBelt;
    Scanner scanner;

    // Holds the gameObject that is currently inside of the scanner
    private GameObject currentBox;

    private void Awake() {
        HandleGameManager();
        scanner = FindObjectOfType<Scanner>();
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


    // MARK: Public

    public void DidPressPass() {
        if(currentBox.GetComponent<Box>().GetIsBoxBad()) {
            missedBoxes++;
        }
        conveyorBelt.StartConveyorBelt();
        Debug.Log("Handling pass");
    }

    public void DidPressScan() {
        if (scansRemaining > 0) {
            Debug.Log("Handling scan");
            scansRemaining--;

            currentBox.GetComponent<Box>().XRayBox();
            scanner.DoXRay();
            StartCoroutine(StopXRay());
        }
    }

    public void DidPressRemove() {
        if(currentBox.GetComponent<Box>().GetIsBoxBad()) {
            caughtBoxes++;
        }
        currentBox.GetComponent<Box>().SetShouldBoxBeRemoved(true);
        conveyorBelt.StartConveyorBelt();
    }

    public GameObject GetCurrentBox() {
        return currentBox;
    }

    public int GetMissed() {
        return missedBoxes;
    }

    public int GetCaught() {
        return caughtBoxes;
    }

    public int GetScans() {
        return scansRemaining;
    }

    public void SetCurrentBox(GameObject newBox) {
        currentBox = newBox;
    }

    // MARK: Private

    private IEnumerator StopXRay() {
        yield return new WaitForSecondsRealtime(scanDuration);

        currentBox.GetComponent<Box>().ResetBoxSprite();
        scanner.StopXRay();
    }
}
