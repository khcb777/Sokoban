using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    [SerializeField] private RectTransform panelToMove;
    [SerializeField] private Ease ease;

    public void ShowLevelPanel()
    {
        MovePanel(new Vector2(0f, 0f), 1f);
    }
    public void HideLevelPanel()
    {
        MovePanel(new Vector2(0f, -6500f), 1f);
    } 
    
    public void MovePanel(Vector2 targetPosition, float duration)
    {
        panelToMove.DOAnchorPos(targetPosition, duration)
            .SetEase(ease); // Можно изменить тип анимации
    }
}

