using UnityEngine;

namespace MyStateMachine
{
    public class State
    {
        protected internal StateMachine stateMachine;
        protected internal int enumIndex;

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
        /// ����״̬ʱ
        /// </summary>
        /// <param name="enumIndex">��һ��״̬</param>
        protected internal virtual void OnEnter(int enumIndex)
        {

        }

        /// <summary>
        /// �뿪״̬ʱ
        /// </summary>
        /// <param name="enumIndex">��һ��״̬</param>
        protected internal virtual void OnExit(int enumIndex)
        {

        }

        /// <summary>
        /// ���ڴ�״̬ʱ��ÿ֡�Զ�����
        /// </summary>
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void LateUpdate() { }
    }
}