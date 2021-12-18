using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showMissed : MonoBehaviour
{
    private int missed = 0;
    public Text missedText;

    void Update() {
        missedText.text = "Missed: " + GameManager.instance.GetMissed();
    }

}
