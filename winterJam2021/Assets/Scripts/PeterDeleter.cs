using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeterDeleter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("trigger" + collision.tag);
         
        if(collision.tag == "Box") {
            Debug.Log("in");
            Box box = collision.gameObject.GetComponent<Box>();

            if(box.GetShouldBoxBeRemoved()) {
                Debug.Log("box bad");
                collision.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                collision.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(10, 10);
            }
        }
    }
}
