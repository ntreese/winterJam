using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickyNote : MonoBehaviour
{
    public Text noteText;

    void Update() {
        noteText.text = "Don't miss more than " + LevelManager.instance.GetObjective() + " boxes!";
    }

}
