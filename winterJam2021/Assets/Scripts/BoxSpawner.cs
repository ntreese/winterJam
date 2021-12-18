using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {
    [Header("Boxes")]
    [SerializeField] List<GameObject> boxes;
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

        Instantiate(boxes[0], transform.position, Quaternion.identity);
    }
}
