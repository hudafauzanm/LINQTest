using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Soal02 {
    public class Order {
        [JsonProperty ("order_id")]
        public string order_id;
        [JsonProperty ("created_at")]
        public DateTime created_at;
        [JsonProperty ("customer")]
        public Customer Customer;
        public List<Items> items = new List<Items> ();
    }

    public class Customer {
        [JsonProperty ("id")]
        public int id;
        [JsonProperty ("name")]
        public string name;
    }

    public class Items {
        [JsonProperty ("id")]
        public int id;
        [JsonProperty ("name")]
        public string name;
        [JsonProperty ("qty")]
        public int qty;
        [JsonProperty ("price")]
        public int price;

    }
    class Program {
        static void Main (string[] args) {
            string json = @"[
                        {
                            ""order_id"": ""SO-921"",
                            ""created_at"": ""2018-02-17T03:24:12"",
                            ""customer"": { ""id"": 33, ""name"": ""Ari"" },
                            ""items"": [
                            { ""id"": 24, ""name"": ""Sapu Lidi"", ""qty"": 2, ""price"": 13200 }, 
                            { ""id"": 73, ""name"": ""Sprei 160x200 polos"", ""qty"": 1, ""price"": 149000 }
                            ]
                        },
                        {
                            ""order_id"": ""SO-922"",
                            ""created_at"": ""2018-02-20T13:10:32"",
                            ""customer"": { ""id"": 40, ""name"": ""Ririn"" },
                            ""items"": [
                            { ""id"": 83, ""name"": ""Rice Cooker"", ""qty"": 1, ""price"": 258000 },
                            { ""id"": 24, ""name"": ""Sapu Lidi"", ""qty"": 1, ""price"": 13200 }, 
                            { ""id"": 30, ""name"": ""Teflon"", ""qty"": 1, ""price"": 190000 }
                            ]
                        },
                        {
                            ""order_id"": ""SO-923"",
                            ""created_at"": ""2018-02-28T15:20:43"",
                            ""customer"": { ""id"": 33, ""name"": ""Ari"" },
                            ""items"": [
                            { ""id"": 303, ""name"": ""Pematik Api"", ""qty"": 1, ""price"": 12000 }, 
                            { ""id"": 49, ""name"": ""Panci"", ""qty"": 2, ""price"": 70000 }
                            ]
                        },
                        {
                            ""order_id"": ""SO-924"",
                            ""created_at"": ""2018-03-02T14:30:54"",
                            ""customer"": { ""id"": 40, ""name"": ""Ririn"" },
                            ""items"": [
                            { ""id"": 986, ""name"": ""TV LCD 40 inch"", ""qty"": 1, ""price"": 6000000 }
                            ]
                        },
                        {
                            ""order_id"": ""SO-925"",
                            ""created_at"": ""2018-03-03T14:52:22"",
                            ""customer"": { ""id"": 33, ""name"": ""Ari"" },
                            ""items"": [
                            { ""id"": 1033, ""name"": ""Nintendo Switch"", ""qty"": 1, ""price"": 4990000 }, 
                            { ""id"": 2003, ""name"": ""Macbook Air 11 inch 128 GB"", ""qty"": 1, ""price"": 12000000 },
                            { ""id"": 23, ""name"": ""Pocari Sweat 600ML"", ""qty"": 5, ""price"": 7000 }
                            ]
                        },
                        {
                            ""order_id"": ""SO-926"",
                            ""created_at"": ""2018-03-05T16:23:20"",
                            ""customer"": { ""id"": 58, ""name"": ""Annis"" },
                            ""items"": [
                            { ""id"": 24, ""name"": ""Sapu Lidi"", ""qty"": 3, ""price"": 13200 }
                            ]
                        }
                        ]";

            var list = JsonConvert.DeserializeObject<List<Order>> (json);

            Console.WriteLine ("==========================Find all purchases made in February.====================================");
            // foreach (var order in list) {
            //     if ((order.created_at).Month == 2) {
            //         Console.WriteLine ("Pesanan order : " + order.order_id + " | " + "Dipesan pada tanggal : " + order.created_at + " | " + "Dipesan oleh : " + order.Customer.name);
            //     }

            // }

            var feb = from l in list where((l.created_at).Month == 2) select new {l.order_id,l.created_at,l.Customer};

            foreach(var f in feb)
            {
                Console.WriteLine("Pesanan order : " + f.order_id + " | " + "Dipesan pada tanggal : " + f.created_at + " | " + "Dipesan oleh : " + f.Customer.name);
            }

            Console.WriteLine ("=============Find all purchases made by Ari, and add grand total by sum all total price of items. The output should only a number.================");
            // decimal sum = 0;
            // decimal total = 0;
            // foreach (var order in list) {

            //     if (order.Customer.name == "Ari") {
            //         foreach (var item in order.items) {

            //             sum += item.price * item.qty;

            //             total = order.items.Sum (item => item.price * item.qty);

            //         }
            //         //   Console.WriteLine("/");
            //         Console.WriteLine ("Total Price per Order : " + total);
            //     }
            // }
            // Console.WriteLine ("Total All Purchase : " + sum);

            
            //int sums = 0;
            var ari = from l in list where(l.Customer.name == "Ari") from x in l.items select x.price*x.qty;
            int sums = ari.Sum();
            Console.WriteLine("Jumlah Total Pembayaran Ari : " +"Rp."+sums+".00");   
            
                
            Console.WriteLine ("==========Find people who have purchases with grand total lower than 300000. The output is an array of people name. Duplicate name is not allowed.========");
            // decimal totalx = 0;
            // decimal sumx = 0;
            // List<string> nama = new List<string> ();

            // foreach (var order in list) {
            //     foreach (var item in order.items) {
            //         sumx = item.price * item.qty;
            //         totalx = order.items.Sum (item => item.price * item.qty);
            //         if (totalx < 300000 && !nama.Contains (order.Customer.name)) {
            //             //Console.WriteLine(order.Customer.name);
            //             nama.Add (order.Customer.name);
            //         }
            //     }
            // }
            // foreach (var x in nama) {
            //     Console.WriteLine (x);
            // }
            //int total = 0 ;
            var low = from l in list from x in l.items where (l.items.Sum(x => x.price*x.qty) < 300000) select l.Customer.name ;
            foreach(var l in low.Distinct())
            {
              Console.WriteLine(l);   
            }
        }
    }
}


