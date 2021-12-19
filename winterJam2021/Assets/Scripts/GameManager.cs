using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    [SerializeField] float scanDuration = 5f;
    [SerializeField] Sprite[] backgrounds;
    [SerializeField] GameObject background;

    [Header("Audio")]
    [SerializeField] AudioClip missedBoxClip;
    [SerializeField] AudioClip successClip;

    public static GameManager instance;

    public int missedBoxes = 0;
    public int caughtBoxes = 0;
    public int scansRemaining = 10;
    public int boxesGoneThrough = 0;

    ConveyorBelt conveyorBelt;
    Scanner scanner;
    BoxSpawner spawner;
    AudioSource source;

    // Holds the gameObject that is currently inside of the scanner
    private GameObject currentBox;

    private void Awake() {
        HandleGameManager();
        scanner = FindObjectOfType<Scanner>();
        conveyorBelt = FindObjectOfType<ConveyorBelt>();
        spawner = FindObjectOfType<BoxSpawner>();
        source = GetComponent<AudioSource>();

        UpdateBackground(0);
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
            source.PlayOneShot(missedBoxClip);
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
            source.PlayOneShot(successClip);
            caughtBoxes++;

        } else if(!currentBox.GetComponent<Box>().GetIsBoxBad()) {
            source.PlayOneShot(missedBoxClip);
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

    public void UpdateBackground(int index) {
        Debug.Log("index: " + index);
        if(backgrounds[index] != null) {
            background.GetComponent<SpriteRenderer>().sprite = backgrounds[index];
        } else {
            Debug.Log("COuldn't find background");
        }
    }

    public void PrepareLevel() {
        boxesGoneThrough = 0;
        scanner = FindObjectOfType<Scanner>();
        conveyorBelt = FindObjectOfType<ConveyorBelt>();
        spawner = FindObjectOfType<BoxSpawner>();
        scansRemaining = LevelManager.instance.GetCurrentLevel().GetNumberOfScans();
    }

    private IEnumerator LoadNextLevel() {
        Debug.Log("LoadNextLevel, waiting");
        yield return new WaitForSecondsRealtime(3.5f);

        Debug.Log("LoadNextLevel, restarting");
        LevelManager.instance.didFinishLevel();

        spawner.NewLevel();
    }

    public void DestroyGameManager() {
        instance = null;
    }

    // MARK: Private

    private IEnumerator StopXRay() {
        yield return new WaitForSecondsRealtime(scanDuration);

        currentBox.GetComponent<Box>().ResetBoxSprite();
        scanner.StopXRay();
    }
}
