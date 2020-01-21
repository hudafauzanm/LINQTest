using System;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;


namespace JSONtest {
    public class User {
        [JsonProperty ("id")]
        public int Id { get; set; }

        [JsonProperty ("username")]
        public string Username { get; set; }

        [JsonIgnore]
        [JsonProperty ("password")]
        public string Password { get; set; }
        public Profile Profile { get; set; }
        public List<Articles> articles { get; set; } = new List<Articles> ();

    }

    public class Profile {
        [JsonProperty ("id")]
        public int Id { get; set; }

        [JsonProperty ("full_name")]
        public string Fullname { get; set; }

        [JsonProperty ("birthday")]
        public DateTime Birthday { get; set; }

        [JsonProperty ("phones")]
        public string[] Phones { get; set; } = { };

    }

    public class Articles {
        [JsonProperty ("id")]
        public int id { get; set; }

        [JsonProperty ("title")]
        public string title { get; set; }

        [JsonProperty ("published_at")]
        public DateTime published_at { get; set; }
    }
    class Program {
        static void Main (string[] args) {

            string json = @"[{
                                ""id"": 323,
                                ""username"": ""rinood30"",
                                ""profile"": {
                                ""full_name"": ""Shabrina Fauzan"",
                                ""birthday"": ""1988-10-30"",
                                ""phones"": [
                                    ""08133473821"",
                                    ""082539163912"",
                                ],
                                },
                                ""articles"": [
                                {
                                    ""id"": 3,
                                    ""title"": ""Tips Berbagi Makanan"",
                                    ""published_at"": ""2019-01-03T16:00:00""
                                },
                                {
                                    ""id"": 7,
                                    ""title"": ""Cara Membakar Ikan"",
                                    ""published_at"": ""2019-01-07T14:00:00""
                                }
                                ]
                            },
                            {
                                ""id"": 201,
                                ""username"": ""norisa"",
                                ""profile"": {
                                ""full_name"": ""Noor Annisa"",
                                ""birthday"": ""1986-08-14"",
                                ""phones"": [],
                                },
                                ""articles"": [
                                {
                                    ""id"": 82,
                                    ""title"": ""Cara Membuat Kue Kering"",
                                    ""published_at"": ""2019-10-08T11:00:00""
                                },
                                {
                                    ""id"": 91,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-11-11T13:00:00""
                                },
                                {
                                    ""id"": 31,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-11-11T13:00:00""
                                }
                                ]
                            },
                            {
                                ""id"": 42,
                                ""username"": ""karina"",
                                ""profile"": {
                                ""full_name"": ""Karina Triandini"",
                                ""birthday"": ""1986-04-14"",
                                ""phones"": [
                                    ""06133929341""
                                ],
                                },
                                ""articles"": []
                            },
                            {
                                ""id"": 201,
                                ""username"": ""icha"",
                                ""profile"": {
                                ""full_name"": ""Annisa Rachmawaty"",
                                ""birthday"": ""1987-12-30"",
                                ""phones"": [],
                                },
                                ""articles"": [
                                {
                                    ""id"": 39,
                                    ""title"": ""Tips Berbelanja Bulan Tua"",
                                    ""published_at"": ""2019-04-06T07:00:00""
                                },
                                {
                                    ""id"": 43,
                                    ""title"": ""Cara Memilih Permainan di Steam"",
                                    ""published_at"": ""2019-06-11T05:00:00""
                                },
                                {
                                    ""id"": 58,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-09-12T04:00:00""
                                }
                                ]
                            }]";

            var list = JsonConvert.DeserializeObject<List<User>> (json);

            Console.WriteLine ("================Find users who doesn't have any phone numbers.====================");
            // foreach (var item in list) {
            //     if ((item.Profile.Phones).Length == 0) {
            //         Console.WriteLine (item.Username);
            //     }
            // }


            //LINQ QUERY 
            var name = from l in list where (l.Profile.Phones).Length == 0 select l.Username;

            //LINQ METHOD
            var nams = list.Where(i => (i.Profile.Phones).Length == 0 )
                       .Select(i => i.Profile.Fullname)
                       .OrderBy(i => i);

            foreach(var x in nams)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine ("====================Find users who have articles=======================");
            // foreach (var item in list) {
            //     if ((item.articles).Count > 0) {
            //         Console.WriteLine (item.Username);
            //     }
            // }


            // LINQ QUERY
            var art = from l in list where l.articles.Count > 0 select l.Username;

            //LINQ METHOD
            var arts = list.Where(i => (i.articles).Count > 0 )
                       .Select(i => i.Profile.Fullname);

            // var arti = list.All(i => (i.articles).Count > 0);
            // var artic = list.Any(i => (i.articles).Count == 0);

            foreach(var y in arts)
            {
                Console.WriteLine(y);
            }


            Console.WriteLine ("================Find users who have Annis on their name====================");
            // foreach (var item in list) {
            //     if ((item.Profile.Fullname).Contains ("Annis") == true) {
            //         Console.WriteLine (item.Username);
            //     }
            // }

            var annis = from l in list where (l.Profile.Fullname).Contains("Annis") select l.Username;

            var anns = list.Where(i => (i.Profile.Fullname).Contains("Annis"))
                       .Select(i => i.Profile.Fullname);

            //var cek = list.OfType<int>();
            foreach(var z in anns)
            {
                Console.WriteLine(z);
            }

            Console.WriteLine ("================Find users who are born on 1986====================");
            // foreach (var item in list) {
            //     if ((item.Profile.Birthday).Year == 1986) {
            //         Console.WriteLine (item.Username);
            //     }
            // }

            var born = from l in list where (l.Profile.Birthday).Year == 1986 select l.Profile.Fullname;

            var borns = list.Where(i => (i.Profile.Birthday).Year == 1986)
                        .Select(i => i.Profile.Fullname);

            foreach(var a in borns)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine ("================Find users who have articles on year 2020.====================");
            // foreach (var item in list) {
            //     foreach (var x in item.articles) {
            //         if ((x.published_at).Year == 2020) {
            //             Console.WriteLine (item.Username);
            //         }
            //     }
            // }

            try{
                 var year = from l in list from x in l.articles where  ((x.published_at).Year == 2020) select l.Profile.Fullname;
                 
                 foreach(var y in year)
                 {
                     Console.WriteLine(y);
                 }
            }
            catch(Exception e)
            {
                Console.WriteLine("Tidak Ada articles pada tahun 2020");
                Console.WriteLine(e);
                throw;
            }
           

            Console.WriteLine ("================Find articles that contain tips on the title.====================");
            // foreach (var item in list) {
            //     foreach (var x in item.articles) {
            //         if ((x.title).Contains ("Tips")) {
            //             Console.WriteLine (item.Username + " " + x.title);
            //         }
            //     }
            // }

            var tips = from l in list from x in l.articles where ((x.title).Contains("Tips")) select new {x.title,l.Profile.Fullname};

            foreach(var t in tips)
            {
                Console.WriteLine("Penulis : "+t.Fullname + "\n" +"Judul : "+ t.title);
            }

            Console.WriteLine ("================Find articles published before August 2019====================");
            // foreach (var item in list) {
            //     foreach (var x in item.articles) {
            //         string iDate = "08/2019";
            //         DateTime oDate = Convert.ToDateTime (iDate);
            //         //Console.WriteLine(iDate);
            //         if ((x.published_at) < oDate) {
            //             Console.WriteLine (item.Username + " " + x.title);
            //         }
            //     }
            // }

            string iDate = "08/2019";
            DateTime oDate = Convert.ToDateTime (iDate);
            var before = from l in list from x in l.articles where ((x.published_at) < oDate) select new {x.title,l.Profile.Fullname};

            foreach(var b in before)
            {
                Console.WriteLine("Penulis : "+b.Fullname + "\n" +"Judul : "+ b.title);
            }
        }
    }
}