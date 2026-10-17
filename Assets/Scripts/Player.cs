using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int playerId;
    // pressed button will be tracked in emitter
    // in OnTriggerEnter, and assigned as toneid.
    // then call GameState.Instance.Enqueue(toneid, userid) to save toneid to user Queue
    public int pressedButton = -1;
    Vector2 moveAmount;

    public void OnMove(InputAction.CallbackContext context)
    {
        // read the value for the "move" action each event call
        moveAmount = context.ReadValue<Vector2>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
