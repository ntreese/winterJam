using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour {
    [SerializeField] float conveyorBeltSpeed = 2f;

    private bool isConveyorBeltFull = false;
    private SurfaceEffector2D effector;

    // Not sure if we need it here.
    private BoxSpawner spawner;

    private void Awake() {
        effector = GetComponent<SurfaceEffector2D>();
        spawner = FindObjectOfType<BoxSpawner>();
    }

    // Start is called before the first frame update
    void Start() {
        effector.speed = conveyorBeltSpeed;
    }

    // Update is called once per frame
    void Update() {

    }

    // MARK: - Public
    public bool GetIsConveyorBeltFull() {
        return isConveyorBeltFull;
    }

    public void StartConveyorBelt() {
        ModifyConveyorSpeed(conveyorBeltSpeed);
    }

    public void StopConveyorBelt() {
        ModifyConveyorSpeed(0);
    }

    // MARK: - Private

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Box") {
            // Set ConveyorBelt to full, to prevent spawning new boxes
            isConveyorBeltFull = true;

            // Stop conveyor belt
            ModifyConveyorSpeed(0);

            // Stop all Coroutines that are running on the spawner
            spawner.StopAllCoroutines();

            // "Notify" GameManager what box is currently in
            GameManager.instance.SetCurrentBox(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Box") {
            ModifyConveyorSpeed(conveyorBeltSpeed);
            isConveyorBeltFull = false;

            StartCoroutine(spawner.SpawnBox(1f));
        }
    }

    private void ModifyConveyorSpeed(float speed) {
        effector.speed = speed;
    }
}
