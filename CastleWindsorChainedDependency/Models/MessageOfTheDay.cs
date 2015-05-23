namespace CastleWindsorChainedDependency.Models
{
    public class MessageOfTheDay
    {
        public MessageOfTheDay(string message)
        {
            string[] parts = message.Split(':');
            MOTD = parts[0];
            LoaderUsed = parts[1];
            SerivceUsed = parts[2];
        }
        public string MOTD { get; set; }
        public string SerivceUsed { get; set; }
        public string LoaderUsed { get; set; }
    }
}