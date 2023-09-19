using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Player;

    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
    }
    public void Update()
    {
        transform.position = new Vector3 (Player.position.x, Player.position.y, -10);
    }
}
