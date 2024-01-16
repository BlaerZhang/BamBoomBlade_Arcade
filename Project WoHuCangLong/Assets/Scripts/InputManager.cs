using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InputManager : MonoBehaviour
{

    public bool isSharingKeyboard = false;
    void Start()
    {
        if (isSharingKeyboard)
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
        else
        {
            
        }
    }

    private void OnEnable()
    {
        if (!isSharingKeyboard)
        {
            InputSystem.onDeviceChange += OnNewDeviceConnected;
        }
    }

    private void OnDisable()
    {
        if (!isSharingKeyboard)
        {
            InputSystem.onDeviceChange -= OnNewDeviceConnected;
        }
    }

    public void OnNewDeviceConnected(InputDevice device, InputDeviceChange change)
    {
        if (!isSharingKeyboard)
        {
            foreach (var player in PlayerInput.all)
            {
                if (player.devices.Count == 0)
                {
                    InputUser.PerformPairingWithDevice(FindFirstUnpairedGamepad(), player.user);
                    player.user.ActivateControlScheme("Gamepad");
                }
            }
        }
    }

    Gamepad FindFirstUnpairedGamepad()
    {
        Gamepad firstUnpairedGamepad = null;
        foreach (var gamepad in Gamepad.all)
        {
            if (PlayerInput.FindFirstPairedToDevice(gamepad) == null)
            {
                firstUnpairedGamepad = gamepad;
                return firstUnpairedGamepad;
            }
        }

        return firstUnpairedGamepad;
    }
}
