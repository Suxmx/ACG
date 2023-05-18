using MyStateMachine;
using UnityEngine;

public class Jump: PlayerState
{
    public Jump(int enumIndex,Player player) : base(enumIndex,player)
    {
        
    }
    protected internal override void OnEnter(int enumIndex)
    {
        base.OnEnter(enumIndex);
    }

    public override void Update()
    {
    }
    protected internal override void OnExit(int enumIndex)
    {
        base.OnExit(enumIndex);
    }
}