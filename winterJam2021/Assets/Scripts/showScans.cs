using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showScans : MonoBehaviour {
    private int scans = 10;
    public Text scanText;

    void Update() {
        scanText.text = "Scans: " + GameManager.instance.GetScans();
    }

}
