
using System.Collections;
using System.Collections.Generic;
using MyStateMachine;
using UnityEngine;

public class Player
{
    private GameObject playerObj;
    private Transform trans;
    private Collider2D collider;
    private Collider2D feetCollider;
    private Rigidbody2D rigid;
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
        State idle = new Idle((int)EState.Idle);
        State move = new Move((int)EState.Move);
        State jump = new Jump((int)EState.Jump);
        
        StateMapper mapper = new StateMapper();
        mapper.AddStates(idle,move,jump);
        stateMachine = new StateMachine(mapper);
    }
    public void Update(float deltaTime)
    {
        isGround = CheckGround();
        
    }

    private bool CheckGround()
    {
        return feetCollider.IsTouchingLayers(LayerMask.NameToLayer("Ground"));
    }
}
