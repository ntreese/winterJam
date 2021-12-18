using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxSprite : MonoBehaviour
{
    //[SerializeField] List<Sprite> boxSprites;

    [SerializeField] Sprite basicBox;
    [SerializeField] Sprite goodBox;
    [SerializeField] Sprite sketchyBox;

    public Sprite GetRandomBoxSprite(string name) {
        switch (name) {
            case "bertBox":
                if(shouldUseBox(2)) {
                    return basicBox;
                } else if(shouldUseBox(1)) {
                    return sketchyBox;
                } else {
                    return goodBox;
                }

            case "bombBox":
                if(shouldUseBox(2)) {
                    return basicBox;
                } else if(shouldUseBox(1)) {
                    return goodBox;
                } else {
                    return sketchyBox;
                }
        }

        return basicBox;
    }

    private bool shouldUseBox(int prob) {
        return Random.Range(1, 10) <= prob;
    }
}
