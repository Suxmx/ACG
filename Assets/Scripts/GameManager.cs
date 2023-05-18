using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Service
{
    [Header("角色")]
    [SerializeField]private GameObject playerObj;
    
    private Player player;
    private GameInput gameInput;

    protected override void Start()
    {
        base.Start();
        player = new Player(playerObj);
        gameInput = new GameInput();
        gameInput.Enable();

    }

    private void Update()
    {
        UpdateInput();
        player.Update(Time.deltaTime);
       
    }

    private void UpdateInput()
    {
        InputData.Clear();
        var playerInput = gameInput.Player;
        var moveValue = playerInput.Move.ReadValue<Vector2>();
        if (playerInput.Move.phase == InputActionPhase.Started)
        {
            InputData.AddEvent(InputEvent.Move);
            InputData.moveValue = moveValue;
            // Debug.Log("Move");
        }

        if (playerInput.Jump.phase == InputActionPhase.Performed)
        {
            InputData.AddEvent(InputEvent.Jump);
            // Debug.Log("Jump");
        }

        if (playerInput.Attack.phase == InputActionPhase.Performed)
        {
            InputData.AddEvent(InputEvent.Attack);
            // Debug.Log("Attack");
        }
    }
}