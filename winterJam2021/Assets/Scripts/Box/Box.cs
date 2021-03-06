using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool isInViewport = false;

    [SerializeField] Sprite xraySprite;

    private SpriteRenderer spriteRenderer;
    private Sprite initialSprite;

    // Config - Holds sprites + if it is Bad or Good
    private BoxConfigSO config;

    // WARNING: Always set to true!
    private bool shouldBeRemoved = false;
    private bool gotScanned = false;

    // MARK: - Unity Lifecycle
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

    // MARK: ConfigRelated
    public void SetConfig(BoxConfigSO config) {
        this.config = config;
        DidSetConfig();
    }

    public void XRayBox() {
        spriteRenderer.sprite = config.GetXRaySprite();
    }

    public void ResetBoxSprite() {
        spriteRenderer.sprite = config.GetNormalSprite();
    }

    public bool GetIsBoxBad() {
        return config.GetIsBad();
    }

    public bool GetGotScanned() {
        return gotScanned;
    }

    public void SetGotScanned() {
        gotScanned = true;
    }

    public bool GetShouldBoxBeRemoved() {
        return shouldBeRemoved;
    }

    public void SetShouldBoxBeRemoved(bool shouldBeRemoved) {
        this.shouldBeRemoved = shouldBeRemoved;
    }

    // MARK: Private
    private void DidSetConfig() {
        ResetBoxSprite();
    }

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
