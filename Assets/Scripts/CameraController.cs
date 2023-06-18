using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float offsetX = 7f;

    private void Update()
    {
        if(player == null) return;

        transform.position = new Vector3(player.position.x+offsetX, player.position.y+1f, transform.position.z);
    }
}
