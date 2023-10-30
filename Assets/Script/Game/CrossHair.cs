using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    [SerializeField] private Texture2D crossHair;

    private void Start()
    {
        Vector2 hotspot = Vector2.zero;
        Cursor.SetCursor(crossHair, hotspot, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
