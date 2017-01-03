namespace Pgpg.Application.Submall.Lib
{
    public class MessageSend : SendBase
    {
        public const string ADDRESSBOOK = "addressbook";
        public const string TO = "to";
        public const string LINKS = "links";
        public const string Content = "content";

        public MessageSend(IAppConfig appConfig) : base(appConfig)
        {
        }

        protected override ISender GetSender()
        {
            return new Message(_appConfig);
        }

        public void AddTo(string address)
        {
            this.AddWithComma(TO, address);
        }

        public void AddContent(string content)
        {
            this.AddWithComma(Content, content);
        }

        public void AddAddressBook(string addressbook)
        {
            this.AddWithComma(ADDRESSBOOK, addressbook);
        }


        public bool Send(out string returnMessage)
        {
            return this.GetSender().Send(_dataPair, out returnMessage);
        }
    }
}