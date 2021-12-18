using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] Light scannerLight;
    [SerializeField] Color scannerColor;

    private void Awake() {
        scannerLight = GetComponentInChildren<Light>();
    }

    public void DoXRay() {
        scannerLight.color = scannerColor;
    }

    public void StopXRay() {
        scannerLight.color = Color.white;
    }
}
