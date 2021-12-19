using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    [SerializeField] float scanDuration = 5f;
    [SerializeField] GameObject background;

    public static GameManager instance;

    public int missedBoxes = 0;
    public int caughtBoxes = 0;
    public int scansRemaining = 10;
    public int boxesGoneThrough = 0;

    ConveyorBelt conveyorBelt;
    Scanner scanner;
    BoxSpawner spawner;

    // Holds the gameObject that is currently inside of the scanner
    private GameObject currentBox;

    private void Awake() {
        HandleGameManager();
        scanner = FindObjectOfType<Scanner>();
        conveyorBelt = FindObjectOfType<ConveyorBelt>();
        spawner = FindObjectOfType<BoxSpawner>();
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
        background.GetComponent<SpriteRenderer>().sprite = LevelManager.instance.GetCurrentLevel().GetBackground();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void GameOver() {
        if(missedBoxes >= LevelManager.instance.GetCurrentLevel().GetAllowedMissingBoxes()) {
            StopAllCoroutines();
            SceneManager.LoadScene(2);
        }
    }

    // MARK: Public

    public void DidPressPass() {
        boxesGoneThrough++;
        if(currentBox.GetComponent<Box>().GetIsBoxBad()) {
            missedBoxes++;
            GameOver();
        }
        conveyorBelt.StartConveyorBelt();
        Debug.Log("Handling pass");

        LevelDone();
    }

    public void DidPressScan() {
        if (scansRemaining > 0 && currentBox.GetComponent<Box>().GetGotScanned() == false) {
            Debug.Log("Handling scan");
            scansRemaining--;

            currentBox.GetComponent<Box>().SetGotScanned();
            currentBox.GetComponent<Box>().XRayBox();
            scanner.DoXRay();
            StartCoroutine(StopXRay());
        }

        LevelDone();
    }

    public void DidPressRemove() {
        boxesGoneThrough++;

        if (currentBox.GetComponent<Box>().GetIsBoxBad()) {
            caughtBoxes++;
        } else if(!currentBox.GetComponent<Box>().GetIsBoxBad()) {
            missedBoxes++;
            GameOver();
        }
        currentBox.GetComponent<Box>().SetShouldBoxBeRemoved(true);
        conveyorBelt.StartConveyorBelt();

        LevelDone();
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

    public void LevelDone() {
        if(LevelManager.instance.GetCurrentLevel().GetDidFinishSpawning() &&
            boxesGoneThrough >= LevelManager.instance.GetCurrentLevel().GetNumberOfTotalBoxes()) {

            StartCoroutine(LoadNextLevel());
        }
    }

    private IEnumerator LoadNextLevel() {
        Debug.Log("LoadNextLevel, waiting");
        yield return new WaitForSecondsRealtime(2f);

        Debug.Log("LoadNextLevel, restarting");
        LevelManager.instance.didFinishLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // MARK: Private

    private IEnumerator StopXRay() {
        yield return new WaitForSecondsRealtime(scanDuration);

        currentBox.GetComponent<Box>().ResetBoxSprite();
        scanner.StopXRay();
    }
}
