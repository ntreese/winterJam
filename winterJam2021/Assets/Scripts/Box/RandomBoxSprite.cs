using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxSprite : MonoBehaviour
{
    [SerializeField] List<Sprite> boxSprites;

    public Sprite GetRandomBoxSprite() {
        return boxSprites[Random.Range(0, boxSprites.Count)];
    }
}
