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
    [SerializeField] AudioClip source;

    public void DidClickButton() {
        AudioSource.PlayClipAtPoint(source, Camera.main.transform.position, 0.3f);

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
