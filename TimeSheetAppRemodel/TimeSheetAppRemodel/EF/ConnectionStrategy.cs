using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;

namespace TimeSheetAppRemodel.EF
{
    public class ConnectionStrategy : ExecutionStrategy
    {
        public ConnectionStrategy(ExecutionStrategyDependencies context) :
            base(context, ExecutionStrategy.DefaultMaxRetryCount, ExecutionStrategy.DefaultMaxDelay)
        {

        }

        public ConnectionStrategy(ExecutionStrategyDependencies context, int maxRetryCount,
            TimeSpan maxRetryDelay) : base(context, maxRetryCount, maxRetryDelay)
        {

        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            return true;
        }
    }
}
