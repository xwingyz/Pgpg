namespace Pgpg.Application.Submall.Lib
{
    public interface IAppConfig
    {
        string AppId { get; set; }

        string AppKey { get; set; }

        SignType SignType { get; set; }
    }
}