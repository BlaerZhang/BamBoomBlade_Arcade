using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InputPairer : MonoBehaviour
{
    void Start()
    {
        var player1 = PlayerInput.all[0];
        var player2 = PlayerInput.all[1];
        
        // Discard existing assignments.
        player1.user.UnpairDevices();
        player2.user.UnpairDevices();
     
        // Assign devices and control schemes.
        InputUser.PerformPairingWithDevice(Keyboard.current, user: player1.user);
        InputUser.PerformPairingWithDevice(Keyboard.current, user: player2.user);
     
        player1.user.ActivateControlScheme("Keyboard");
        player2.user.ActivateControlScheme("Keyboard");
    }
}
