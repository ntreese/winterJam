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

    private void Awake() {
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

    public IEnumerator SpawnBox(float delay) {
        yield return new WaitForSeconds(delay);

        // Instantiate new box at spawner position
        GameObject newBox = Instantiate(boxPrefab, transform.position, Quaternion.identity) as GameObject;

        // Get BoxComponent and set config
        newBox.GetComponent<Box>().SetConfig(boxes[GetRandomIndexForBox()]);
    }

    private int GetRandomIndexForBox() {
        Debug.Log("count: " + boxes.Count);

        int random = Random.Range(0, boxes.Count);

        Debug.Log("randomNr: " + random);

        return random;
    }
}
