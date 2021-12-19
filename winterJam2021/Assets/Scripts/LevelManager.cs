using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] Level[] availableLevels;

    private Level currentLevel;
    private int levelIndex = 0;
    private int spawnedBoxes = 0;

    private void Awake() {
        HandleSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        instance.currentLevel = availableLevels[levelIndex];
    }

    private void HandleSingleton() {
        if(instance != null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Level GetCurrentLevel() {
        return currentLevel;
    }

    public void didFinishLevel() {
        levelIndex++;

        if(availableLevels[levelIndex] != null) {
            currentLevel = availableLevels[levelIndex];
        }
    }

    public void IncrementSpawnedBoxes() {
        spawnedBoxes++;
    }

    public int GetSpawnedBoxes() {
        return spawnedBoxes;
    }
}
