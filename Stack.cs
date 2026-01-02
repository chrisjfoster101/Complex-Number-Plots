using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms_Implicits
{
    class Stack
    {
        public Exception EmptyStack = new Exception("Stack is Empty");

        private object[] stack;
        private int top = -1;

        public Stack() => stack = new object[10];

        public object Peek()
        {
            if (IsEmpty())
            {
                throw EmptyStack;
            }
            return stack[top];
        }
        public object Pop()
        {
            if (IsEmpty())
            {
                throw EmptyStack;
            }
            top--;
            return stack[top + 1];
        }
        public void Push(object value)
        {
            if (IsFull())
            {
                object[] newStack = new object[stack.Length + 5];
                for (int i = 0; i <= top; i++)
                {
                    newStack[i] = stack[i];
                }
                stack = newStack;
            }
            top++;
            stack[top] = value;
        }
        public bool IsEmpty() => top == -1;
        public bool IsFull() => top == stack.Length - 1;
    }
}