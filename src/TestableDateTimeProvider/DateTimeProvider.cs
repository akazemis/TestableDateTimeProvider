using System;

namespace TestableDateTimeProvider
{
    public class DateTimeProvider : IDateTimeProvider
    {
        #region Singleton

        private static Lazy<DateTimeProvider> _lazyInstance = new Lazy<DateTimeProvider>(() => new DateTimeProvider());
        private DateTimeProvider()
        {
        }

        public static DateTimeProvider Instance
        {
            get
            {
                return _lazyInstance.Value;
            }
        }

        #endregion

        private Func<DateTime> _defaultCurrentFunction = () => DateTime.UtcNow;

        public DateTime GetUtcNow()
        {
            if (DateTimeProviderContext.Current == null)
            {
                return _defaultCurrentFunction.Invoke();
            }
            else
            {
                return DateTimeProviderContext.Current.ContextDateTimeUtcNow;
            }
        }
    }
}
