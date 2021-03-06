using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {
    [Header("Boxes")]
    [SerializeField] GameObject boxPrefab;
    [SerializeField] List<BoxConfigSO> boxes;
    [SerializeField] float spawnDelay = 2f;

    [Header("ConveyorBelt")]
    [SerializeField] GameObject conveyorBelt;

    private ConveyorBelt conveyorBeltScript;
    private RandomBoxSprite spriteHolder;

    private void Awake() {
        spriteHolder = FindObjectOfType<RandomBoxSprite>();
        conveyorBeltScript = conveyorBelt.GetComponent<ConveyorBelt>();
    }

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(FillUpConveyorBelt());
    }

    // Update is called once per frame
    void Update() {

    }

    private IEnumerator FillUpConveyorBelt() {
        while (!conveyorBeltScript.GetIsConveyorBeltFull()) {
            yield return new WaitForSecondsRealtime(spawnDelay);

            StartCoroutine(SpawnBox(0f));
        }
    }

    // TODO: @Hannes -
    // Prefab what's needed
    // Reload scene with new level.

    public void NewLevel() {
        StartCoroutine(FillUpConveyorBelt());
    }

    public IEnumerator SpawnBox(float delay) {
        if(!CheckIfSpawnAllowed()) {
            LevelManager.instance.GetCurrentLevel().SetDidFinishSpawning();
            yield break;
        }
        
        yield return new WaitForSeconds(delay);

        // Instantiate new box at spawner position
        GameObject newBox = Instantiate(boxPrefab, transform.position, Quaternion.identity) as GameObject;

        // Get BoxComponent and set config
        BoxConfigSO newConfig = GetRandomBoxConfig();
        newConfig.SetNormalSprite(spriteHolder.GetRandomBoxSprite(newConfig.GetXRaySprite().name));
        newConfig.SetDidSetSprite();

        newBox.GetComponent<Box>().SetConfig(newConfig);
        LevelManager.instance.IncrementSpawnedBoxes();
    }

    private bool CheckIfSpawnAllowed() {
        return LevelManager.instance.GetSpawnedBoxes() < LevelManager.instance.GetCurrentLevel().GetNumberOfTotalBoxes();
    }

    private BoxConfigSO GetRandomBoxConfig() {
        for(int i = 0; i < boxes.Count; i++) {
            BoxConfigSO config = boxes[i];

            int randomInt = Random.Range(1, 10);
            if (randomInt <= config.GetProbability()) {
                return config;
            }
        }
        
        // If it happens that no probability is there, we loop again over it.
        return GetRandomBoxConfig();
    }
}
