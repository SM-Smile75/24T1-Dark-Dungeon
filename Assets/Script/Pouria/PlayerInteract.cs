using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Torch1 interactableTorch = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactableTorch != null)
            interactableTorch.ToggleState();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torch"))
            interactableTorch = other.GetComponent<Torch1>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Torch") && interactableTorch != null)
            interactableTorch = null;
    }
}