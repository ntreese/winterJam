using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] Light scannerLight;
    [SerializeField] Color scannerColor;
    [SerializeField] AudioClip sound;

    private void Awake() {
        scannerLight = GetComponentInChildren<Light>();
    }

    public void DoXRay() {
        scannerLight.color = scannerColor;
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, 1f);
    }

    public void StopXRay() {
        scannerLight.color = Color.white;
    }
}
