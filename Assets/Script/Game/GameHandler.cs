using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Transform[] initialTargetPosition;
    [SerializeField] private PointerDisplay pointerDisplay;
    
    private void Start()
    {
        foreach (Transform targetPosition in initialTargetPosition)
        {
            pointerDisplay.createPointer(targetPosition.position);
        }
    }
}
