using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] Light scannerLight;
    [SerializeField] Color scannerColor;
    [SerializeField] AudioSource source;

    private void Awake() {
        scannerLight = GetComponentInChildren<Light>();
        source = GetComponent<AudioSource>();
    }

    public void DoXRay() {
        scannerLight.color = scannerColor;
        source.Play();
    }

    public void StopXRay() {
        source.Stop();
        scannerLight.color = Color.white;
    }
}
