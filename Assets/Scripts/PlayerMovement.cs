using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float horizontalSpeed = 10f;
    public float xLimit = 4.5f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            // Get horizontal input from mouse movement
            float horizontalInput = Input.GetAxis("Mouse X");

            transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);
        }

        float clampedX = Mathf.Clamp(transform.position.x, -xLimit, xLimit);

        // Update the player's position with the clamped X value
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }


    // Handle collision with obstacles
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Malzeme"))
        {
            // Handle collision with obstacle (e.g., end game, reduce health, etc.)
            Debug.Log("Malzeme Toplandı!");

            Destroy(other.gameObject); // Destroy the collected item
        }
    }
}
