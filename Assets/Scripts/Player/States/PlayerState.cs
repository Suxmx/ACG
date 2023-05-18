using MyStateMachine;

public class PlayerState:State
{
    public Player player;
    public PlayerState(int enumIndex,Player player) : base(enumIndex)
    {
        this.player = player;
    }
}