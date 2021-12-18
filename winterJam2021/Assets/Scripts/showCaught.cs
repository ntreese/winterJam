using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showCaught : MonoBehaviour
{
    private int caught = 0;
    public Text caughtText;

    void Update() {
        caughtText.text = "Caught: " + GameManager.instance.GetCaught();
    }
}
