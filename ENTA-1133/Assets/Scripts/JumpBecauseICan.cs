using UnityEngine;
using UnityEngine.InputSystem;

public class JumpBecauseICan : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 10;
    private PlayerInput input;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = new PlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        //DAMN YOU NEW INPUT SYSTEM, I DONT UNDERSTAND YOU!
        /*if (input.)
        {

            rb.linearVelocity = new Vector3(0, jumpSpeed, 0);
        }*/
    }
}
