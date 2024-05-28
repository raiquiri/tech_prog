using System;
using System.Collections;

namespace ConsoleApp
{
    abstract class BaseList<T> : IEnumerable<T> where T : IComparable<T>
    {
        protected int lenght;
        public int Count { get { return lenght; } }

        // объявление делегата
        public delegate void listener();
        // объявление события
        public event listener active;
        // вызов события
        protected void check()
        {
            // ? оператор для проверки на null, ситуация возможна, если нет подписчиков события
            active?.Invoke();
        }
        
        public abstract void add(T item);
        public abstract void insert(T item, int position);
        public abstract void delete(int position);
        public abstract void clear();
        public abstract void print();
        public abstract T this[int i] { set; get; }

        public void assign(BaseList<T> sourse)
        {
            clear();
            for (int i = 0; i < sourse.Count; i++)
            {
                add(sourse[i]);
            }
        }
        public void assignTo(BaseList<T> dest)
        {
            dest.assign(this);
        }

        protected abstract BaseList<T> emptyClone();
        public BaseList<T> clone()
        {
            BaseList<T> copy = emptyClone();
            copy.assign(this);
            return copy;
        }

        public virtual void sort()
        {
            int left = 0;
            int right = lenght - 1;

            while (left < right)
            {
                bool swap = false;
                for (int i = left; i < right; i++)
                {
                    if (this[i].CompareTo(this[i + 1]) > 0)
                    {
                        (this[i], this[i + 1]) = (this[i + 1], this[i]);
                        swap = true;
                    }
                }

                if (!swap)
                {
                    break;
                }

                right--;


                for (int i = right; i > left; i--)
                {
                    if (this[i - 1].CompareTo(this[i]) > 0)
                    {
                        (this[i - 1], this[i]) = (this[i], this[i - 1]);
                    }
                }
                left++;
            }
        }
        public virtual void deleteRepeat()
        {
            if (lenght == 0)
            {
                return;
            }

            for (int i = 0; i < lenght; i++)
            {
                bool check = true;
                for (int j = i + 1; j < lenght; j++)
                {
                    if (this[i].CompareTo(this[j]) == 0)
                    {
                        delete(j);
                        check = false;
                        j--;
                    }
                }
                if (!check)
                {
                    delete(i);
                    i--;
                }
            }
        }

        public bool equals(BaseList<T> list)
        {
            if (lenght != list.Count)
            {
                return false;
            }

            for (int i = 0; i < lenght; i++)
            {
                if (this[i].CompareTo(list[i]) != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public abstract string toString();
        public void saveToFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(this.toString());
            }
        }
        public void loadToFile(string path)
        {
            this.clear();
            using (StreamReader reader = new StreamReader(path))
            {
                try
                {
                    string str = reader.ReadToEnd();

                    string[] list = str.Split("\n");
                    for (int i = 0; i < list.Length; i++)
                    {
                        string num = list[i].Trim();
                        if (!string.IsNullOrEmpty(num))
                        {
                            T conventNum = (T)Convert.ChangeType(num, typeof(T));
                            this.add(conventNum);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exceptions.BadFileException("Некорректный формат данных в файле");
                }
            }
        }
        public static BaseList<T> operator +(BaseList<T> list_1, BaseList<T> list_2)
        {
            BaseList<T> merged = list_1.clone();
            for (int i = 0; i < list_2.Count; i++)
            {
                merged.add(list_2[i]);
            }
            return merged;
        }
        public static bool operator ==(BaseList<T> list_1, BaseList<T> list_2)
        {
            if (list_1.equals(list_2)) return true;
            else return false;
        }
        public static bool operator !=(BaseList<T> list_1, BaseList<T> list_2)
        {
            if (list_1.equals(list_2)) return false;
            else return true;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new EnumList(this);
        }
        protected class EnumList : IEnumerator<T>
        {
            private BaseList<T> list;
            private int index;

            public EnumList(BaseList<T> list)
            {
                this.list = list;
                this.index = -1;
            }
            
            object IEnumerator.Current { get { return Current; } }
            public bool MoveNext()
            {
                if (index < list.lenght - 1)
                {
                    index++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset() { index = -1; }

            public void Dispose() { }

            public T Current
            {
                get { return list[index]; }
            }
        }
    }
}
