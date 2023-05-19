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
        CheckConditions();
        player.rigid.velocity = InputData.moveValue.velocity * player.config.velocity;

    }

    protected override void SetConditions()
    {
        conditions = new List<ICondition>()
        {
            new VelocityChecker(EState.Idle,ValueOperator.AbsLess,ValueAxis.X,0.05f,player.rigid)
        };
    }

    protected internal override void OnExit(int enumIndex)
    {
        base.OnExit(enumIndex);
    }

    
}
