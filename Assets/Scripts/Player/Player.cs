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
    private Animator animator;
    public Rigidbody2D rigid;
    public PlayerConfigs config;
    public bool isGround;

    private Dictionary<string, VelocityInfo> velocityDict;
    private Dictionary<EState, string> aniDict;
    private StateMachine stateMachine;
    private float originScale;

    public Player(GameObject playerObj)
    {
        this.playerObj = playerObj;
        Init();
    }

    public void Init()
    {
        if (playerObj == null)
            Debug.LogError("未设置Player的GameObject");

        velocityDict = new Dictionary<string, VelocityInfo>();
        
        trans = playerObj.transform;
        collider = playerObj.GetComponent<Collider2D>();
        rigid = playerObj.GetComponent<Rigidbody2D>();
        animator = trans.Find("Body").GetComponent<Animator>();
        config = trans.Find("Body").GetComponent<PlayerConfigs>();
        feetCollider = trans.Find("Feet").GetComponent<Collider2D>();

        originScale = trans.localScale.x;

        InitStateMachine();
    }

    private void InitStateMachine()
    {
        aniDict = new Dictionary<EState, string>()
        {
            { EState.Idle, "Idle" },
            { EState.Move, "Run" }
        };
        State idle = new Idle((int)EState.Idle, this);
        State move = new Move((int)EState.Move, this);
        //State jump = new Jump((int)EState.Jump, this);

        StateMapper mapper = new StateMapper();
        mapper.AddStates(idle, move);
        stateMachine = new StateMachine(mapper, (int)EState.Idle);

        
    }

    public void Update(float deltaTime)
    {
        // Vector2 v = new Vector2(InputData.moveValue.velocity.x * config.velocity, 0);
        // VelocityInfo info = new VelocityInfo("Input", v);
        // AddVelocity("Input",info);
        isGround = CheckGround();
        stateMachine.Update(deltaTime);
        UpdateVelocity();
        Flip();
    }
    private void Flip()
    {
        if (InputData.moveValue.velocity.x > 0 && trans.localScale.x > 0)
            trans.localScale = new Vector3(-originScale, originScale, 1);
        else if(InputData.moveValue.velocity.x < 0 && trans.localScale.x < 0)
            trans.localScale = new Vector3(originScale, originScale, 1);
    }
    private bool CheckGround()
    {
        return feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    private void UpdateVelocity()
    {
        Vector2 resV = Vector2.zero;

        foreach (var info in velocityDict)
        {
            // Debug.Log($"AddV:{info.Value.name} Vector:{info.Value.velocity}");
            resV += info.Value.velocity;
        }

        velocityDict.Clear();
        if (rigid.gravityScale == 0)
            rigid.velocity = resV;
        else
            rigid.velocity = new Vector2(resV.x, rigid.velocity.y);
        // Debug.Log($"RigidV{rigid.velocity}");
    }

    public void AddVelocity(VelocityInfo info)
    {
        if (velocityDict.TryGetValue(info.name, out var value))
        {
            value.velocity += info.velocity;
        }
        else
        {
            velocityDict.Add(info.name, info);
        }
    }

    public void AddVelocity(string name, VelocityInfo info)
    {
        info.name = name;
        if (velocityDict.TryGetValue(info.name, out var value))
        {
            value.velocity += info.velocity;
        }
        else
        {
            velocityDict.Add(info.name, info);
        }
    }

    public void PlayAni(EState state)
    {
        string aniName;
        if(!aniDict.TryGetValue(state,out aniName))
            Debug.LogWarning($"不存在{state}的动画，将跳过播放");
        animator.Play(aniName);
    }
}