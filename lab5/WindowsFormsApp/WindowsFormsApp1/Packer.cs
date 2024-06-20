using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WindowsFormsApp1
{
    
    internal class Packer
    {
        public delegate void Progress(int progress);
        public event Progress ProgressChanged;
        protected virtual void OnProgressChanged(int progress)
        {
            ProgressChanged?.Invoke(progress);
        }
        public void Pack(FileStream inputStream, FileStream outputStream, CancellationToken cancellationToken)
        {
            using (inputStream)
            using (outputStream)
            {
                using (StreamReader reader = new StreamReader(inputStream))
                using (BinaryWriter writer = new BinaryWriter(outputStream))
                {
                    StringBuilder builder = new StringBuilder();
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        builder.Append(line);
                    }

                    string content = builder.ToString();
                    builder.Clear();

                    int count = 1;
                    for (int i = 1; i < content.Length; i++)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                        }
                        Thread.Sleep(500);
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
                        int progress = (int)((double)i / content.Length * 100);
                        OnProgressChanged(progress);

                    }
                    writer.Write(builder.ToString());
                }
            }
        }

        public void UnPack(FileStream inputStream, FileStream outputStream, CancellationToken cancellationToken)
        {
            using (inputStream)
            using (outputStream)
            {
                using (BinaryReader reader = new BinaryReader(inputStream))
                using (StreamWriter writer = new StreamWriter(outputStream))
                {
                    string content = reader.ReadString();
                    StringBuilder builder = new StringBuilder();

                    for (int i = 0; i < content.Length;)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                        }

                        if (char.IsDigit(content[i]) && content[i] != '0')
                        {
                            int count = int.Parse(content[i].ToString());
                            char currentChar = content[i + 1];
                            builder.Append(new string(currentChar, count));
                            i += 2;
                        }
                        else if (content[i] == '0')
                        {
                            int count = int.Parse(content[i + 1].ToString());
                            builder.Append(content.Substring(i + 2, count));
                            i += 2 + count;
                        }
                        int progress = (int)((double)i / content.Length * 100);
                        OnProgressChanged(progress);
                    }
                    writer.Write(builder.ToString());
                }
            }
        }
    }
}