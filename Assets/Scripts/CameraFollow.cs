using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    private Vector3 offset; // Offset between the camera and the player
    void Start()
    {
        offset = transform.position - player.position; // Calculate the initial offset
    }



    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + offset.z);
    }
}
