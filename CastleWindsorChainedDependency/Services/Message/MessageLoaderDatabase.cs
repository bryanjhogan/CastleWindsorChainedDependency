using CastleWindsorChainedDependency.Contracts;

namespace CastleWindsorChainedDependency.Services.Message
{
    public class MessageLoaderDatabase : IMessageLoader
    {
        public string LoadMessage()
        {
            return string.Format("Message loaded from a DATABASE:{0}", GetType());
        }
    }
}