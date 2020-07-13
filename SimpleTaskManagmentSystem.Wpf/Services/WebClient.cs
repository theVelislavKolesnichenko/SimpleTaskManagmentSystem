namespace SimpleTaskManagmentSystem.Wpf.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    public sealed class WebClient
    {
        private static WebClient instance = null;
        private static readonly object padlock = new object();
        public HttpClient client { get; private set; }

        private WebClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:53355");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static WebClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new WebClient();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
