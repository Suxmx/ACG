
using System.Collections;
using System.Collections.Generic;
using MyStateMachine;
using UnityEngine;

public class Player
{
    public GameObject playerObj;
    public Transform trans;
    private Collider2D collider;
    private Collider2D feetCollider;
    public Rigidbody2D rigid;
    public bool isGround;

    private Dictionary<string, VelocityInfo> velocityDict;
    private StateMachine stateMachine;

    public Player(GameObject playerObj)
    {
        this.playerObj = playerObj;
        Init();
    }
    public void Init()
    {
        if(playerObj==null)
            Debug.LogError("未设置Player的GameObject");

        InitStateMachine();
        trans = playerObj.transform;
        collider = playerObj.GetComponent<Collider2D>();
        rigid = playerObj.GetComponent<Rigidbody2D>();
        feetCollider = trans.Find("Feet").GetComponent<Collider2D>();
    }

    private void InitStateMachine()
    {
        State idle = new Idle((int)EState.Idle,this);
        State move = new Move((int)EState.Move,this);
        State jump = new Jump((int)EState.Jump,this);
        
        StateMapper mapper = new StateMapper();
        mapper.AddStates(idle,move,jump);
        stateMachine = new StateMachine(mapper,(int)EState.Idle);
    }
    public void Update(float deltaTime)
    {
        isGround = CheckGround();
        stateMachine.Update(deltaTime);
    }

    private bool CheckGround()
    {
        return feetCollider.IsTouchingLayers(LayerMask.NameToLayer("Ground"));
    }
}
