using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace csv_output
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var reader = new CSVReader<IntIntLine>(@"example.csv"))
            {
                //var s = reader.Where(i => i.data1 > 0).Select(i => i.data2).Sum();

                var s = reader.Select(i => 
                    i.data1.ToString() +","+ 
                    i.data2.ToString());


                foreach (var data in s)
                {
                    Console.WriteLine(data);
                }

                Console.WriteLine(s);
            }


            return;


        }
        class IntIntLine : LineData
        {
            public int data1, data2;

            public override void SetDataFrom(string[] s)
            {
                data1 = int.Parse(s[0]);
                data2 = int.Parse(s[1]);
            }
        }

    }
}
