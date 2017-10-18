using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public class Service
    {
        public Service()
        {
            State = States.Unauthenticated;
        }
        public enum States
        {
            Unauthenticated, Authenticated
        };
        public States State
        {
            get;
            private set;
        }

        public static List<string> userNames = new List<string>()
        {
            "a", "b", "c"
        };
        public bool Authenticate(string password, string userName)
        {
            foreach (var u in userNames)
            {
                if (u == userName)
                {
                    if (State == States.Authenticated)
                    {
                        return false;
                    }
                    if (password == "xyzzy")
                    {
                        State = States.Authenticated;
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }


        public string Square(string x)
        {
            if (State == States.Unauthenticated)
            {
                return "не знаю";
            }
            return Math.Pow(Convert.ToInt32(x), 2).ToString();
        }

        public void Logout()
        {
            if (State == States.Unauthenticated)
            {
                // throw ....
            }
            State = States.Unauthenticated;
        }
    }




    class Program
    {
        public static List<string> requests = new List<string>()
            { "authenticate" , "square" , "logout"
            };

        static List<string> GetRequest()
        {
            return requests;
        }
        static string GetQuery()
        {
            return "{password:\"xyzzy\",userName:\"a\", number:\"3\"}";
        }

        static void MainLoop()
        {
            Service service = new Service();
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            listener.Prefixes.Add("http://localhost:8080/files/");
            listener.Prefixes.Add("http://localhost:8080/authenticate/");
            listener.Prefixes.Add("http://localhost:8080/square/");
            listener.Prefixes.Add("http://localhost:8080/logout/");
            listener.Start();
            Console.WriteLine("Listening...");
            // Note: The GetContext method blocks while waiting for a request. 
            int i = 0;
            while (i++ < 10)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                string responseString = "";
                if (request.RawUrl == "/files")
                {
                    responseString = File.ReadAllText(@"C:\Users\Дарья\Desktop\git\Dasha\System Programming\jsonSender.html");
                }
                else if (request.RawUrl == "/files/jsonSender.js")
                {
                    responseString = File.ReadAllText(@"C:\Users\Дарья\Desktop\git\Dasha\System Programming\jsonSender.js");
                }
                else
                {

                    string resource = request.RawUrl.Trim(new char[] { '/' });
                    string query;
                    using (var reader = new StreamReader(request.InputStream,
                                                         request.ContentEncoding))
                    {
                        query = reader.ReadToEnd();
                    }






                    List<string> reqs = new List<string>();
                    reqs = GetRequest();

                    JObject json = JObject.Parse(query);

                    JObject result = new JObject();
                    JObject res = new JObject();

                    foreach (var r in reqs)
                    {
                        switch (r)
                        {
                            case "authenticate":
                                var success = service.Authenticate(
                                    json["password"].ToString(), json["userName"].ToString()
                                );
                                result["success"] = success;
                                break;

                            case "square":
                                var res1 = service.Square(
                                   json["number"].ToString()
                               );
                                res["number"] = res1;
                                break;

                            case "logout":
                                service.Logout();
                                break;

                            default:
                                result["error"] = "Unknown request";
                                break;
                        }




                        Console.WriteLine(result.ToString());


                        responseString = result.ToString() + " " + res.ToString();
                    }

                   
                }
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                // Construct a response.



                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
                // You must close the output stream.
                output.Close();
            }
            listener.Stop();




        }

        static void Main(string[] args)
        {

            MainLoop();






        }
    }
}
