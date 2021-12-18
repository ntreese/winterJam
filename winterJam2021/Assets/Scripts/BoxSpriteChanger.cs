using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpriteChanger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Box") {
            Box box = collision.gameObject.GetComponent<Box>();
            box.ResetBoxSprite();
        }
    }
}
