using CastleWindsorChainedDependency.Contracts;

namespace CastleWindsorChainedDependency.Services.Message
{
    public class MessageOfTheDayServiceDatabase : IMessageOfTheDayService
    {
        private readonly IMessageLoader _messageLoader; 
        public MessageOfTheDayServiceDatabase(IMessageLoader messageLoader)
        {
            _messageLoader = messageLoader;
        }

        public string GetMessageOfTheDay()
        {
            return string.Format("DB Service. {0}:{1}", _messageLoader.LoadMessage(), GetType());
        }
    }
}