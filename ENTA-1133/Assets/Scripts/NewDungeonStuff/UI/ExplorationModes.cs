using UnityEngine;

public class ExplorationModes : MonoBehaviour
{
    [SerializeField] GameObject interactiveStuff;
    public void SetInteractiveStuffActive(bool active)
    {
        interactiveStuff.SetActive(active);
    }
}
