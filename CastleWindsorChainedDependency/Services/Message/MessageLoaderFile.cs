using CastleWindsorChainedDependency.Contracts;

namespace CastleWindsorChainedDependency.Services.Message
{
    public class MessageLoaderFile : IMessageLoader
    {
        public string LoadMessage()
        {
            return string.Format("Message loaded from a FILE:{0}", GetType());
        }
    }
}