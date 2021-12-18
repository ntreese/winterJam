using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
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
    void Start()
    {
        effector.speed = conveyorBeltSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        HandleCollision(true, collision.tag);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        HandleCollision(false, collision.tag);
    }

    private void HandleCollision(bool isFull, string tag) {
        if (tag == "Box") {
            isConveyorBeltFull = isFull;
            effector.speed = isFull ? 0 : conveyorBeltSpeed;

            if(isFull) {
                // we need to stop all coroutines to prevent spawning
                spawner.StopAllCoroutines();
            }
        }
    }

    private void ModifyConveyorSpeed(float speed) {
        effector.speed = speed;
    }
}
