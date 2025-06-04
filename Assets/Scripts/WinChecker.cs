using UnityEngine;

public class WinChecker : MonoBehaviour
{
    public Box[] boxes;
    public Target[] targets;
    
    private void Update()
    {
        if (AllBoxesOnTargets())
        {
            Debug.Log("Level Complete!");
            // Здесь можно загрузить следующий уровень
        }
    }
    
    private bool AllBoxesOnTargets()
    {
        foreach (Target target in targets)
        {
            if (!target.HasBox()) return false;
        }
        return true;
    }
}