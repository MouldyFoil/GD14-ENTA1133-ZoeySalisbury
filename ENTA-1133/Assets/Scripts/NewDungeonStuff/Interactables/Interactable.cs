using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] GameObject interactVisual;
    [SerializeField] float interactionDistance;
    internal bool ObjectInRange(Vector3 inObjectPos, out float distance)
    {
        bool inRange = false;
        distance = Vector3.Distance(transform.position, inObjectPos);
        if (distance <= interactionDistance)
        {
            interactVisual.SetActive(true);
            inRange = true;
        }
        else
        {
            interactVisual.SetActive(false);
        }
            return inRange;
    }
    internal abstract void InteractActions();
}
