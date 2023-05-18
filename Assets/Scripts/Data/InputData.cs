using System;
using Unity.VisualScripting;
using UnityEngine;

public static class InputData
{
    public static InputEvent inputEvent;
    public static Vector2 moveValue;

    public static void AddEvent(InputEvent inputEvent)
    {
        InputData.inputEvent |= inputEvent;
    }

    public static void Clear()
    {
        InputData.inputEvent = InputEvent.None;
        InputData.moveValue = Vector2.zero;
    }

    public static bool HasEvent(InputEvent inputEvent, bool fullMatch = false)
    {
        return fullMatch ? (InputData.inputEvent & inputEvent) == inputEvent : (InputData.inputEvent & inputEvent) != 0;
    }
}

[Flags]
public enum InputEvent
{
    None,
    Attack = 1,
    Jump = 1 << 1,
    Dash = 1 << 2,
    Move = 1 << 3
}