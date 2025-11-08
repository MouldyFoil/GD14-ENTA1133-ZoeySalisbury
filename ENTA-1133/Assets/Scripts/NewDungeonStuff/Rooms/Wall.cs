using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] Sprite openSprite;
    [SerializeField] Sprite closeSprite;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] internal GameObject doorObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    internal void ChangeDoorState(bool closed)
    {
        doorObject.SetActive(closed);
        if (closed)
        {
            spriteRenderer.sprite = closeSprite;
        }
        else
        {
            spriteRenderer.sprite = openSprite;
        }
    }
}
