using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public class User
    {
        string password;
        string userName;
        public User(string p, string u)
        {
            password = p;
            userName = u;
        }
    }
    public class Service
    {
        public static List<string> userNames = new List<string>()
        {
            "a", "b", "c"
        };
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

        public bool Authenticate(string password , string userName) {
            foreach(var u in userNames)
            {
                if(u == userName)
                {
                      if (State == States.Authenticated) {
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
            return  Math.Pow(Convert.ToInt32(x),2).ToString();
        }

        public void Logout () {
            if (State == States.Unauthenticated)
            {
                // throw ....
                Console.WriteLine("failed to log out");
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

        static void MainLoop() {
            Service service = new Service();
            List<string> reqs = new List<string>();
            reqs = GetRequest();
            while (true) {
                string query = GetQuery();
                JObject json = JObject.Parse(query);

                JObject result = new JObject();
                JObject res = new JObject();

                foreach(var r in reqs)
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

                }
                Console.WriteLine(result.ToString());
                Console.WriteLine(res.ToString());
                break;
            }
        }

        static void Main(string[] args)
        {
            MainLoop();
            Console.ReadLine();
        }
    }
}
