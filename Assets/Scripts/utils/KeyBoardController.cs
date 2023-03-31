using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    // Map of keyboard keys to actions
    private Dictionary<KeyCode, string> keyActionMap = new Dictionary<KeyCode, string>
    {
        { KeyCode.W, "moveForward" },
        { KeyCode.S, "moveBackward" },
        { KeyCode.A, "moveLeft" },
        { KeyCode.D, "moveRight" },
        { KeyCode.Space, "jump" },
        { KeyCode.Alpha1, "dirt" },
        { KeyCode.Alpha2, "grass" },
        { KeyCode.Alpha3, "glass" },
        { KeyCode.Alpha4, "wood" },
        { KeyCode.Alpha5, "log" }
    };

    // Dictionary to store the current state of the keyboard actions
    private Dictionary<string, bool> actions = new Dictionary<string, bool>
    {
        { "moveForward", false },
        { "moveBackward", false },
        { "moveLeft", false },
        { "moveRight", false },
        { "jump", false },
        { "dirt", false },
        { "grass", false },
        { "glass", false },
        { "wood", false },
        { "log", false }
    };

    void Update()
    {
        // Check if any keys in the keyActionMap are currently being pressed
        // foreach (KeyCode key in keyActionMap.Keys)
        // {
        //     Debug.Log(key);
        //     if (Input.GetKeyDown(key))
        //     {
        //         actions[keyActionMap[key]] = true;
        //     }
        //     else if (Input.GetKeyUp(key))
        //     {
        //         actions[keyActionMap[key]] = false;
        //     }
        // }
    }

    // Method to get the current state of a keyboard action
    public bool GetActionState(string action)
    {
        return actions[action];
    }

    public Dictionary<string, bool> GetActionStateAll()
    {
        return actions;
    }
}

