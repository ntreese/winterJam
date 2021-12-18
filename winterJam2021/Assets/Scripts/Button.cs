using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonType {
    Remove,
    Pass,
    Scan
}

public class Button : MonoBehaviour {

    [SerializeField] ButtonType type;

    public void DidClickButton() {
        switch (type) {
            case ButtonType.Remove:
                GameManager.instance.DidPressRemove();                
                break;
            case ButtonType.Scan:
                GameManager.instance.DidPressScan();
                break;
            case ButtonType.Pass:
                GameManager.instance.DidPressPass();
                break;
        }
    }
}
