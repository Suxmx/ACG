using Services;
using UnityEngine;

namespace MyStateMachine
{
    public class State
    {
        protected internal StateMachine stateMachine;
        protected internal int enumIndex;
        protected GameManager manager;

        public State()
        {
            enumIndex = 0;
        }

        public State(int index)
        {
            enumIndex = index;
            Debug.Log($"{(EState)enumIndex}:{enumIndex}");
        }

        /// <summary>
        /// 进入状态时
        /// </summary>
        /// <param name="enumIndex">上一个状态</param>
        protected internal virtual void OnEnter(int enumIndex)
        {
            if (manager == null)
                manager = ServiceLocator.Get<GameManager>();
        }

        /// <summary>
        /// 离开状态时
        /// </summary>
        /// <param name="enumIndex">下一个状态</param>
        protected internal virtual void OnExit(int enumIndex)
        {

        }

        /// <summary>
        /// 处于此状态时，每帧自动调用
        /// </summary>
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void LateUpdate() { }
    }
}