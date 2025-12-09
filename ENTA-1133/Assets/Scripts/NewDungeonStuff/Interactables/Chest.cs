using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Sprite openSprite;
    [SerializeField] GameObject Item;
    [SerializeField] float itemVelocity = 5;
    [SerializeField] float upVelocity = 2;
    [SerializeField] float spawnUpOffset = 2;
    bool opened = false;
    internal override void InteractActions()
    {
        if(opened == false)
        {
            Debug.Log("You opened the chest");
            sprite.sprite = openSprite;
            opened = true;
            GameObject droppedItem = Instantiate(Item, transform.position + new Vector3(0, 2, 0), transform.rotation); ;
            droppedItem.GetComponent<Rigidbody>().linearVelocity = new Vector3(Random.Range(-itemVelocity, itemVelocity), upVelocity, Random.Range(-itemVelocity, itemVelocity));
        }
    }
}
