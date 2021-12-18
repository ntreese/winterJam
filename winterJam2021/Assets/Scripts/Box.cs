using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool isInViewport = false;

    [SerializeField] Sprite xraySprite;

    private SpriteRenderer spriteRenderer;
    private Sprite initialSprite;

    // WARNING: Always set to true!
    private bool isBad = true;
    private bool shouldBeRemoved = false;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialSprite = spriteRenderer.sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void XRayBox() {
        spriteRenderer.sprite = xraySprite;
    }

    public void StopXRayBox() {
        spriteRenderer.sprite = initialSprite;
    }

    public bool GetIsBoxBad() {
        return isBad;
    }

    public bool GetShouldBoxBeRemoved() {
        return shouldBeRemoved;
    }

    public void SetShouldBoxBeRemoved(bool shouldBeRemoved) {
        this.shouldBeRemoved = shouldBeRemoved;
    }

    // MARK: Private

    private bool IsVisibleToCamera(Vector2 point) {
        return Camera.main.WorldToViewportPoint(point).x < 0;
    }


    private void OnBecameInvisible() {
        if(isInViewport) {
            Destroy(gameObject);
        }
    }

    private void OnBecameVisible() {
        isInViewport = true;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "ConveyorBelt" && collision is CapsuleCollider2D) {
            Debug.Log("change sprite if needed");
        }
    }
}
