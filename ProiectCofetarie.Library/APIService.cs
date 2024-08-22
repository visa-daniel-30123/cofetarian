using ProiectCofetarie.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProiectCofetarie.Library
{

    public class APIService
    {
        public T? Get<T>(string value)
        {
            string table;
            switch (typeof(T).Name)
            {
                case "IstoricComenzi":
                    table = "IstoricComenzis";
                    break;
                case "Produs":
                    table = "Produs";
                    break;
                default:
                    table = typeof(T).Name + "s";
                    break;
            }
            string uri = $"https://localhost:7252/api/{table}/{value}";
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
            string responseString = "";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseString = reader.ReadToEnd();
                }

                return JsonSerializer.Deserialize<T>(responseString);
            }
            catch (WebException) 
            {
                return default(T);
            }
        }
        public T? Get<T>()
        {
            string table;
            switch (typeof(T).Name)
            {
                case "IstoricComenzi":
                    table = "IstoricComenzis";
                    break;
                case "Produs":
                    table = "Produs";
                    break;
                default:
                    table = typeof(T).Name + "s";
                    break;
            }
            string uri = $"https://localhost:7252/api/{table}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            string responseString = "";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseString = reader.ReadToEnd();
                }

                return JsonSerializer.Deserialize<T>(responseString);
            }
            catch (WebException)
            {
                return default(T);
            }
        }
        public void Post<T>(T entity)
        {
            string table;
            switch (typeof(T).Name)
            {
                case "IstoricComenzi":
                    table = "IstoricComenzis";
                    break;
                case "Produs":
                    table = "Produs";
                    break;
                default:
                    table = typeof(T).Name+"s"; 
                    break;
            }

            string uri = $"https://localhost:7252/api/{table}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/json";
            string json = JsonSerializer.Serialize(entity);
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string responseString = reader.ReadToEnd();
                }
            }
            catch (WebException)
            {
                return;
            }
        }

        public void Update<T>(T entityToUpdate)
        {
            string table;
            switch (typeof(T).Name)
            {
                case "IstoricComenzi":
                    table = "IstoricComenzis";
                    break;
                case "Produs":
                    table = "Produs";
                    break;
                default:
                    table = typeof(T).Name + "s";
                    break;
            }

            string uri = $"https://localhost:7252/api/{table}/{(entityToUpdate as IDatabaseTable)?.Id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "PUT";
            request.ContentType = "application/json";
            string json = JsonSerializer.Serialize(entityToUpdate);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string responseString = reader.ReadToEnd();
                }
            }
            catch (WebException)
            {
                return;
            }
        }

    }
}
