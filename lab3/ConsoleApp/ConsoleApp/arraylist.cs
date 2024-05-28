using System;

using System.Text;

namespace ConsoleApp
{
    class ArrayList <T> : BaseList <T> where T : IComparable<T>
    {
        private T[] buffer;
        public ArrayList()
        {
            lenght = 0;
            buffer = new T[4];
        }

        public override void add(T item)
        {
            if (buffer.Length == lenght)
            {
                resize();
            }
            buffer[lenght] = item;
            lenght++;
            check();
        }
        public override void insert(T item, int position)
        {
            if (position > lenght || position < 0)
            {
                return;
            }
            if (position == lenght)
            {
                add(item);
                return;
            }

            if (buffer.Length == lenght)
            {
                resize();
            }

            for (int i = lenght; i > position; i--)
            {
                buffer[i] = buffer[i - 1];
            }
            buffer[position] = item;
            lenght++;
            check();
        }
        public override void delete(int position)
        {
            if (position >= lenght || position < 0)
            {
                return;
            }

            for (int i = position; i < lenght - 1; i++)
            {
                buffer[i] = buffer[i + 1];
            }
            lenght--;
            check();
        }
        public override void clear()
        {
            lenght = 0;
        }
        private void resize()
        {
            T[] newBuffer = new T[buffer.Length * 2];
            for (int i = 0; i < buffer.Length; i++)
            {
                newBuffer[i] = buffer[i];
            }
            buffer = newBuffer;
        }
        public override void print()
        {
            for (int i = 0; i < lenght; i++)
            {
                Console.Write(buffer[i] + " ");
            }
            Console.WriteLine();
        }

        protected override BaseList <T> emptyClone()
        {
            return new ArrayList<T>();
        }

        public override string toString()
        {
            StringBuilder write = new StringBuilder();
            for (int i = 0; i < lenght; i++)
            {
                write.Append(buffer[i] + "\n");
            }

            return write.ToString();
        }


        public override T this[int index]
        {
            get
            {
                if (index < lenght && index >= 0)
                {
                    return buffer[index];
                }
                throw new Exceptions.BadIndexException("Данной позиции не существует");
            }
            set
            {
                if (index < lenght && index >= 0)
                {
                    buffer[index] = value;
                    return;
                }
                throw new Exceptions.BadIndexException("Данной позиции не существует");
            }
        }

    }
}
