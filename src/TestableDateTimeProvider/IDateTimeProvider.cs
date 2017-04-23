using System;

namespace TestableDateTimeProvider
{
    public interface IDateTimeProvider
    {
        DateTime GetUtcNow();
    }
}
