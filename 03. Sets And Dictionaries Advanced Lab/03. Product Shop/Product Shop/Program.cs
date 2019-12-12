using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();

            var myDic = new Dictionary<string, Dictionary<string, double>>();

            while (input[0] != "Revision")
            {
                string shopName = input[0];
                string productName = input[1];
                double productPrice = double.Parse(input[2]);
                

                if (!myDic.ContainsKey(shopName))
                {
                    var pD = new Dictionary<string, double>();
                    pD.Add(productName, productPrice);
                    myDic.Add(shopName, pD);
                }
                else
                {
                    if (!myDic[shopName].ContainsKey(productName))
                    {
                        myDic[shopName].Add(productName, productPrice);
                    }
                    else
                    {
                        myDic[shopName][productName] = productPrice;
                    }
                }

                input = Console.ReadLine().Split(", ").ToArray();
            }//while ends here

            foreach (var shop in myDic.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
