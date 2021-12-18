using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BoxConfigSO")]
public class BoxConfigSO : ScriptableObject
{
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite xRaySprite;
    [SerializeField] bool isBad;


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
