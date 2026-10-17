using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Emitter : MonoBehaviour
{
    AudioSource currentTune;
    
    void Start()
    {
        
        //gameObject.SendMessage("Enqueue", 5.0);
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        // TODO: Player Input Manager component
        //  limit 2 players
        //  assign persistent player identity on join (left or right) 
        //  PlayerInput.playerIndex identifies the joined player,
        //  store player index in player controller class, get in collider, retrieve index

        //PlayerController player =
        //    other.GetComponentInParent<PlayerController>();

        //if (player == null)
        //    return;

        //if (player.pressedButton != -1)
        //{
        //    assignedInt = player.pressedButton;

        //    Debug.Log(
        //        $"Player {player.playerId} assigned value {assignedInt}"
        //    );
        //}

        //if (other.CompareTag("Player"))
        //{
        //    playerOnPlatform = true;
        //    Debug.Log("Press E to activate platform");
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    playerOnPlatform = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {
    }
}
