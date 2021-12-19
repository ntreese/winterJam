using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{
    [SerializeField] int numberOfScans;
    [SerializeField] int numberOfTotalBoxes;
    [SerializeField] int allowedMissedBoxes;
    [SerializeField] int objective;
    [SerializeField] Sprite background;


    private bool didFinishSpawning = false;

    public int GetNumberOfScans() {
        return numberOfScans;
    }

    public int GetNumberOfTotalBoxes() {
        return numberOfTotalBoxes;
    }

    public int GetAllowedMissingBoxes() {
        return allowedMissedBoxes;
    }

    public Sprite GetBackground() {
        return background;
    }

    public int ShowObjective() {
        return objective;
    }

    public void SetDidFinishSpawning() {
        didFinishSpawning = true;
    }

    public bool GetDidFinishSpawning() {
        return didFinishSpawning;
    }
}
