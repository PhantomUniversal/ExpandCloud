using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class PhantomGUIScopeStack<T>
    {
        public Stack<T> InnerStack = new Stack<T>();
        
        private PhantomGUIFrameCounter guiState = new PhantomGUIFrameCounter();

        public int Count
        {
            get
            {
                if (this.guiState.Update().IsNewFrame)
                    this.InnerStack.Clear();
                return this.InnerStack.Count;
            }
        }

        public void Push(T t)
        {
            if (this.guiState.Update().IsNewFrame)
                this.InnerStack.Clear();
            this.InnerStack.Push(t);
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                Debug.LogError((object) "Pop call mismatch; no corresponding push call! Each call to Pop must always correspond to one - and only one - call to Push.");
                return default (T);
            }
            if (!this.guiState.Update().IsNewFrame)
                return this.InnerStack.Pop();
            Debug.LogError((object) "Pop call mismatch; no corresponding push call! Each call to Pop must always correspond to one - and only one - call to Push.");
            this.InnerStack.Clear();
            return default (T);
        }

        public T Peek()
        {
            if (this.guiState.Update().IsNewFrame)
                this.InnerStack.Clear();
            return this.InnerStack.Peek();
        }
    }
}