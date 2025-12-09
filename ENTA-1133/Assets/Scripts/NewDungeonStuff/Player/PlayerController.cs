using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionAsset actionAsset;
    [SerializeField] float speed = 2;
    [SerializeField] float cameraSpeed = 2;
    Rigidbody rb;
    InputAction moveAction;
    Vector2 moveInput;
    internal bool camLocked { private set; get; } = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = actionAsset.FindActionMap("Player").FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            MoveInput();
        }
    }
    void OnLook(InputValue value)
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float cameraInput = value.Get<Vector2>().x;
            transform.localEulerAngles += new Vector3(0, cameraInput * cameraSpeed) * Time.deltaTime;
        }
    }
    void OnToggleCamLock()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (FindFirstObjectByType<ExplorationModes>())
        {
            FindFirstObjectByType<ExplorationModes>().SetInteractiveStuffActive(Cursor.lockState == CursorLockMode.None);
        }
    }
    private void MoveInput()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = (transform.forward * speed * moveInput.y) + (transform.right * speed * moveInput.x);
    }
}
