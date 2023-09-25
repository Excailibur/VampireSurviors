using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    [SerializeField] private RectTransform CrossHairImage;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void Update()
    {
        //Set CrossHair anchor to mouse global position
        CrossHairImage.anchoredPosition = Input.mousePosition;
    }
}
