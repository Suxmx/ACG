using UnityEngine;
using UnityEngine.Events;

namespace MyStateMachine
{
    public class StateMachine
    {
        public StateMapper mapper;
        public UnityAction<int, int> StateChange;
        private Player player;

        // 当前状态
        private State state;

        private int stateIndex=-10;
        /// <summary>
        /// 当前状态对应的index，外部应转换为枚举使用
        /// </summary>
        public int StateIndex
        {
            get => stateIndex;
            set
            {
                if (stateIndex != value)
                {
                    
                    if (mapper != null)
                    {
                        State newState = mapper.GetState(value);
                        Debug.Log($"Enter---{(EState)value}");
                        state?.OnExit(stateIndex);
                        state = newState;
                        newState?.OnEnter(value);
                    }
                    int temp = stateIndex;
                    stateIndex = value;
                    StateChange?.Invoke(temp, value);
                }
            }
        }

        public StateMachine()
        {
            stateIndex = -1;
        }

        public StateMachine(int stateIndex)
        {
            this.stateIndex = stateIndex;
        }

        /// <param name="_mapper">通过StateMapper规定状态与index间的映射</param>
        public StateMachine(StateMapper _mapper, int stateIndex = -1)
        {
            mapper = _mapper;
            mapper.stateMachine = this;
            this.StateIndex = stateIndex;
            foreach (var state in _mapper.stateDict.Values)
            {
                state.stateMachine = this;
            }
        }

        public void Update(float deltaTime)
        {
            state.Update(deltaTime);
            
        }
        public void FixedUpdate(float deltaTime)
        {
            state.FixedUpdate();            
        }
        public void LateUpdate(float deltaTime)
        {
            state.LateUpdate();
        }
    }
}