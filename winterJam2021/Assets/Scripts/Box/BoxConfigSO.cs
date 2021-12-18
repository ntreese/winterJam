using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BoxConfigSO")]
public class BoxConfigSO : ScriptableObject
{
    [SerializeField] Sprite xRaySprite;
    [SerializeField] bool isBad;

    private RandomBoxSprite spriteHolder;
    private Sprite normalSprite;

    public void SetNormalSprite(Sprite newSprite) {
        normalSprite = newSprite;
    }

    public Sprite GetNormalSprite() {
        return normalSprite;
    }

    public Sprite GetXRaySprite() {
        return xRaySprite;
    }

    public bool GetIsBad() {
        return isBad;
    }
}
