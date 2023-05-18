using System.Collections;
using System.Collections.Generic;
using MyStateMachine;
using UnityEngine;

public class Idle : PlayerState
{
    public Idle(int enumIndex,Player player) : base(enumIndex,player)
    {
        
    }
    protected internal override void OnEnter(int enumIndex)
    {
        base.OnEnter(enumIndex);
    }

    public override void Update()
    {
        if (InputData.moveValue.Compare(0.1f, ValueOperator.AbsGreater, ValueAxis.X))
        {
            Debug.Log($"ChangeStateTo:{EState.Move} with velocity:{InputData.moveValue.velocity}");
            stateMachine.StateIndex = (int)EState.Move;
        }
    }
    protected internal override void OnExit(int enumIndex)
    {
        base.OnExit(enumIndex);
    }
}
