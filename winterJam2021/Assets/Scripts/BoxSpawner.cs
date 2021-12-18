using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {
    [Header("Boxes")]
    [SerializeField] List<GameObject> boxes;
    [SerializeField] float initialDelayBeforeFilling = 2f;
    [SerializeField] float spawnDelay = 2f;
    [SerializeField] bool shouldSpawnBoxes = true;

    [Header("ConveyorBelt")]
    [SerializeField] GameObject conveyorBelt;

    private ConveyorBelt conveyorBeltScript;

    private float timePassed = 0;


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

    // Too fckin tired to properly write an advanced Coroutine
    // Current problem: The amount of time between moving and spawning is too small
    // Therefore we already stop without spawning.

    //private IEnumerator FillUpConveyorBelt() {
    //    while (shouldSpawnBoxes) {
    //        while (timePassed < spawnDelay) {
    //            timePassed += Time.deltaTime;
    //            yield return null;
    //        }

    //        if (!conveyorBeltScript.GetIsConveyorBeltFull()) {
    //            SpawnBox();
    //            timePassed = 0;
    //        }

    //        yield return new WaitForSecondsRealtime(initialDelayBeforeFilling);
    //    }
    //}

    private IEnumerator FillUpConveyorBelt() {
        while (!conveyorBeltScript.GetIsConveyorBeltFull()) {
            yield return new WaitForSecondsRealtime(initialDelayBeforeFilling);
            SpawnBox();
        }
    }

    public void SpawnBox() {
        Instantiate(boxes[0], transform.position, Quaternion.identity);
    }
}
