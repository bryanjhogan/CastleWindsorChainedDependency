using CastleWindsorChainedDependency.Contracts;

namespace CastleWindsorChainedDependency.Services.Message
{
    public class MessageOfTheDayServiceFile : IMessageOfTheDayService
    {
        private readonly IMessageLoader _messageLoader;
        public MessageOfTheDayServiceFile(IMessageLoader messageLoader)
        {
            _messageLoader = messageLoader;
        }

        public string GetMessageOfTheDay()
        {
            return string.Format("File Service. {0}:{1}", _messageLoader.LoadMessage(), GetType());
        }
    }
}