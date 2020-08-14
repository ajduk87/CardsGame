using RestSharp;

namespace ClientControllerLibrary
{
    public interface IApiCaller
    {
        IRestResponse Post<T>(string url, T parameter);

        IRestResponse Put<T>(string url, T parameter);

        IRestResponse Delete<T>(string url, T parameter);

        string Get(string url, params object[] parameters);
    }
}