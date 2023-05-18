using System.Collections;
using System.Collections.Generic;
using MyStateMachine;
using UnityEngine;

public class Move : PlayerState
{
    public Move(int enumIndex,Player player) : base(enumIndex,player)
    {
        
    }
    protected internal override void OnEnter(int enumIndex)
    {
        base.OnEnter(enumIndex);
    }

    public override void Update()
    {
        if (InputData.moveValue.Compare(0.05f, ValueOperator.AbsLess, ValueAxis.X))
        {
            Debug.Log($"ChangeStateTo:{EState.Idle} with velocity:{InputData.moveValue.velocity}");
            stateMachine.StateIndex = (int)EState.Idle;
        }
        
        player.rigid.velocity = InputData.moveValue.velocity;

    }
    protected internal override void OnExit(int enumIndex)
    {
        base.OnExit(enumIndex);
    }

    
}
