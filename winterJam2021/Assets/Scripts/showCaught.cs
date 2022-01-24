using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showCaught : MonoBehaviour {
    public Text caughtText;

    void Update() {
        caughtText.text = "Caught: " + GameManager.instance.GetCaught();
    }
}
