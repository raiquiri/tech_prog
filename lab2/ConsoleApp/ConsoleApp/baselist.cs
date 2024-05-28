using System;

namespace ConsoleApp
{
    abstract class BaseList
    {
        protected int lenght;
        public int Count { get { return lenght; } }
        public abstract void add(int item);
        public abstract void insert(int item, int position);
        public abstract void delete(int position);
        public abstract void clear();
        public abstract void print();
        public abstract int this[int i] { set; get; }

        public void assign(BaseList sourse)
        {
            clear();
            for (int i = 0; i < sourse.Count; i++)
            {
                add(sourse[i]);
            }
        }
        public void assignTo(BaseList dest)
        {
            dest.assign(this);
        }
        public BaseList clone()
        {
            BaseList copy = emptyClone();
            copy.assign(this);
            return copy;
        }
        protected abstract BaseList emptyClone();
        
        public virtual void sort()
        {
            int left = 0;
            int right = lenght - 1;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (this[i] > this[i + 1])
                    {
                        int temp = this[i];
                        this[i] = this[i + 1];
                        this[i + 1] = temp;
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    if (this[i - 1] > this[i])
                    {
                        int temp = this[i - 1];
                        this[i - 1] = this[i];
                        this[i] = temp;
                    }
                }
                left++;
            }
        }
        public bool equals(BaseList list)
        {
            if (lenght != list.Count)
            {
                return false;
            }

            for (int i = 0; i < lenght; i++)
            {
                if (this[i] != list[i])
                {
                    return false;
                }
            }
            return true;
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
                    if (this[i] == this[j])
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
    }
}
