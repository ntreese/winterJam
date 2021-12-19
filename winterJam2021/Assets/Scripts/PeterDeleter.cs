using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeterDeleter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {         
        if(collision.tag == "Box") {
            Box box = collision.gameObject.GetComponent<Box>();

            if(box.GetShouldBoxBeRemoved()) {
                collision.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(10, 10);
            }
        }
    }
}
