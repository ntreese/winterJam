using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BoxConfigSO")]
public class BoxConfigSO : ScriptableObject {
    [SerializeField] Sprite xRaySprite;
    [SerializeField] bool isBad;

    [Header("Probability")]
    [Tooltip("Please enter an integer between 1 and 10. If you want a probability of 40% then please enter 4.")]
    [SerializeField] int probability = 1;

    private bool didSetSprite = false;

    private Sprite initialSprite;

    public void SetNormalSprite(Sprite newSprite) {
        if(!didSetSprite) {
            initialSprite = newSprite;
        }
    }

    public Sprite GetNormalSprite() {
        return initialSprite;
    }

    public Sprite GetXRaySprite() {
        return xRaySprite;
    }

    public bool GetIsBad() {
        return isBad;
    }

    public int GetProbability() {
        return probability;
    }

    public bool GetDidSetSprite() {
        return didSetSprite;
    }

    public void SetDidSetSprite() {
        didSetSprite = true;
    }
}
