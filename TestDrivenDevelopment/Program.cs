using System;
using System.Collections.Generic;

namespace TestDrivenDevelopment
{
    internal class Program
    {
        class test_info_t
        {
            public int id { get; set; }
            public float start { get; set; }
            public float end { get; set; }
            public float pos { get; set; }
            public float result { get; set; }
            public float out_range_start { get; set; }
            public float out_range_end { get; set; }
        }

        static float percent_of_range(float start, float end, float pos, float out_range_start = 0, float out_range_end = 1)
        {
            float percent = (pos - start) / (end - start);
            float _out = out_range_start + ((out_range_end - out_range_start) * percent);

            return _out;
        }

        static void Main(string[] args)
        {
            List<test_info_t> tests = new List<test_info_t>{
                new test_info_t{id = 1, start = 500,  end = 1000,  pos = 750, result = 0.5f, out_range_start = 0, out_range_end = 1},
                new test_info_t{id = 2, start = 0,  end = 100,  pos = 50, result = 0.5f, out_range_start = 0, out_range_end = 1},
                new test_info_t{id = 3, start = 0,  end = 1,  pos = 0.35f, result = 0.35f, out_range_start = 0, out_range_end = 1},
                new test_info_t{id = 4, start = 0,  end = 1,  pos = 0.65f, result = 0.65f, out_range_start = 0, out_range_end = 1},
                new test_info_t{id = 5, start = 100,  end = 200,  pos = 125, result = 0.25f, out_range_start = 0, out_range_end = 1},
                new test_info_t{id = 6, start = -500,  end = 0,  pos = -250, result = 0.5f, out_range_start = 0, out_range_end = 1},
                new test_info_t{id = 7, start = -500,  end = -250,  pos = -375, result = 0.5f, out_range_start = 0, out_range_end = 1},
                new test_info_t{id = 8, start = 0,  end = 100,  pos = 50, result = 0, out_range_start = -10, out_range_end = 10},
                new test_info_t{id = 9, start = 0,  end = 100,  pos = 50, result = -10, out_range_start = -20, out_range_end = 0}
            };

            foreach (var test in tests)
            {
                float res = percent_of_range(test.start, test.end, test.pos, test.out_range_start, test.out_range_end);
                if (res != test.result)
                {
                    Console.Write("Error in test ");
                    Console.Write(test.id);
                    Console.Write(" - Expected result: ");
                    Console.Write(test.result);
                    Console.Write(" - Actual result: ");
                    Console.WriteLine(res);
                    return;
                }
            }
            Console.WriteLine("All tests completed.");
        }
    }
}