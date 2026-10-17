using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("InputSystem")]
    [SerializeField] private InputActionAsset inputActions;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;

    private InputAction leftAction;
    private InputAction rightAction;
    public Rigidbody2D rb2D;

    private void Awake()
    {
        // Find the actions by name: Action Map "Player" -> actions "Left" and "Right"
        InputActionMap playerMap = inputActions.FindActionMap("Player", true);
        leftAction = playerMap.FindAction("Left", true);
        rightAction = playerMap.FindAction("Right", true);

       
    }

    private void OnEnable()
    {
        leftAction.Enable();
        rightAction.Enable();
    }

    private void OnDisable()
    {
        leftAction.Disable();
        rightAction.Disable();
    }

    private void Update()
    {
        // ReadValue gives 0..1 (analog on the gamepad stick, 0 or 1 on the keyboard)
        float direction = rightAction.ReadValue<float>() - leftAction.ReadValue<float>();

        if (rb2D != null)
        {
            rb2D.linearVelocity = new Vector2(direction * moveSpeed, rb2D.linearVelocity.y);
        }
        else
        {
            transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);
        }
    }
}