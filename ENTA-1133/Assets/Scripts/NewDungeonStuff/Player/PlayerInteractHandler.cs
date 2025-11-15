using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractHandler : MonoBehaviour
{
    Interactable closestInteractable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindNearestInRangeInteractable();
    }
    void OnInteract()
    {
        if(closestInteractable != null)
        {
            closestInteractable.InteractActions();
        }
    }
    private void FindNearestInRangeInteractable()
    {
        Interactable closestFound = null;
        Dictionary<float, Interactable> interactables = new Dictionary<float, Interactable>();
        float closestDistance = Mathf.Infinity;
        foreach (Interactable interactable in FindObjectsByType<Interactable>(FindObjectsSortMode.None))
        {
            if (interactable.ObjectInRange(transform.position, out float distance))
            {
                interactables.Add(distance, interactable);
                if(distance < closestDistance)
                {
                    closestDistance = distance;
                }
            }
        }
        if (interactables.ContainsKey(closestDistance))
        {
            closestFound = interactables[closestDistance];
        }
        closestInteractable = closestFound;
    }
}
