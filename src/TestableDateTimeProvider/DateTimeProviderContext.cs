using System;
using System.Collections.Generic;
using System.Threading;

namespace TestableDateTimeProvider
{
    public class DateTimeProviderContext : IDisposable
    {
        private static ThreadLocal<Stack<DateTimeProviderContext>> ThreadScopeStack = new ThreadLocal<Stack<DateTimeProviderContext>>(() => new Stack<DateTimeProviderContext>());
        public DateTime ContextDateTimeUtcNow;
        private Stack<DateTimeProviderContext> _contextStack = new Stack<DateTimeProviderContext>();

        public DateTimeProviderContext(DateTime contextDateTimeUtcNow)
        {
            ContextDateTimeUtcNow = contextDateTimeUtcNow;
            ThreadScopeStack.Value.Push(this);
        }
        public static DateTimeProviderContext Current
        {
            get
            {
                if (ThreadScopeStack.Value.Count == 0)
                {
                    return null;
                }
                return ThreadScopeStack.Value.Peek();
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (ShouldUnwindScope())
                UnwindScope();
            ThreadScopeStack.Value.Pop();
        }

        #endregion

        private void UnwindScope()
        {
            // ...
        }

        private bool ShouldUnwindScope()
        {
            bool result = true;
            //...
            return result;
        }
    }
}
