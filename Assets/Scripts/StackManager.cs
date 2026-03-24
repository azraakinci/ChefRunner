using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Stack Settings")]

    public Transform tabak;
    public float yEkseniBoslugu = 0.3f;

    private List<Transform> toplananMalzemeler = new List<Transform>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Malzeme"))
        {
            other.GetComponent<Collider>().enabled = false; // Disable collider to prevent multiple triggers

            other.transform.SetParent(tabak); // Set the collected item as a child of the stack

            Vector3 yeniPozisyon = new Vector3(0, toplananMalzemeler.Count * yEkseniBoslugu, 0);
            other.transform.localPosition = yeniPozisyon; // Position the collected item on top of the stack

            other.transform.localRotation = Quaternion.identity; // Reset rotation to keep items upright
            toplananMalzemeler.Add(other.transform); // Add the collected item to the list
        }
    }
}
