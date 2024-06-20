using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.Wasm;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp
{
    class Test
    {
        public static void Main(string[] args)
        {
            string input = "aaabb01234";
            string packed = Pack(input);
            string unPacked = UnPack(packed);
            Console.WriteLine(packed);
            Console.WriteLine(unPacked);
        }

        public static string UnPack(string text)
        {
            StringBuilder builder = new StringBuilder();

            string input = text;
            for (int i = 0; i < input.Length;)
            {
                if (char.IsDigit(input[i]) && input[i] != '0')
                {
                    int count = int.Parse(input[i].ToString());
                    char currentChar = input[i + 1];
                    builder.Append(new string(currentChar, count));
                    i += 2;
                }
                else if (input[i] == '0')
                {
                    int count = int.Parse(input[i + 1].ToString());
                    builder.Append(input.Substring(i + 2, count));
                    i += 2 + count;
                }
            }
            return builder.ToString();
        }

        public static string Pack(string text)
        {
            StringBuilder builder = new StringBuilder();
            /*string line;

            while ((line = reader.ReadLine()) != null)
            {
                builder.Append(line);
            }

            string content = builder.ToString();
            builder.Clear();*/

            string content = text;

            int count = 1;
            for (int i = 1; i < content.Length; i++)
            {
                if (content[i] == content[i - 1])
                {
                    count++;
                }
                else
                {
                    if (count == 1)
                    {
                        int start = i - 1;
                        int j = i;
                        for (j = i; j < content.Length; j++)
                        {
                            if (content[i] != content[i - 1])
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        builder.Append("0");
                        builder.Append(count);
                        while (start < j)
                        {
                            builder.Append(content[start]);
                            start++;
                        }
                        count = 1;
                        i = j;
                    }
                    else
                    {
                        builder.Append(count);
                        builder.Append(content[i - 1]);
                        count = 1;
                    }
                }
            }
            return builder.ToString();
            /*writer.Write(builder.ToString());*/
        }
    }
}
