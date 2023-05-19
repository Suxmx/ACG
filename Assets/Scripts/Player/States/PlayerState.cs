using System.Collections.Generic;
using MyStateMachine;

public abstract class PlayerState:State
{
    public Player player;
    protected List<ICondition> conditions;
    public PlayerState(int enumIndex,Player player) : base(enumIndex)
    {
        this.player = player;
        SetConditions();
    }

    protected void CheckConditions()
    {
        foreach (var condition in conditions)
        {
            if (condition.Excute())
            {
                stateMachine.StateIndex = (int)condition.nextState;
            }
        }
    }
    protected abstract void SetConditions();
    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        CheckConditions();
    }
}