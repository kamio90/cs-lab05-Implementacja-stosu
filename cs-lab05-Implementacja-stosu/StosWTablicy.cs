using System;

namespace cs_lab05_Implementacja_stosu
{
    public class StosWTablicy<T> : IStos<T>
    {
        private T[] tab;
        private int szczyt = -1;

        public StosWTablicy(int size = 100)
        {
            tab = new T[size];
            szczyt = -1;
        }

        public T Peek => IsEmpty ? throw new StosEmptyException() : tab[szczyt];

        public int Count => szczyt + 1;

        public bool IsEmpty => szczyt == -1;

        public void Clear() => szczyt = -1;

        public T Pop() => IsEmpty ? throw new StosEmptyException() : tab[szczyt--];

        public void Push(T value)
        {

            if (Count + 1 >= tab.Length )
            {
                var temp = new T[2 * Count];
                Array.Copy(tab,temp, tab.Length);
                tab = temp;
            }

            tab[++szczyt] = value;
        }

        public T[] ToArray()
        {
            //return tab;  //bardzo źle - reguły hermetyzacji

            //poprawnie:
            T[] temp = new T[szczyt + 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = tab[i];
            return temp;
        }

        public T this[int index] => throw new NotImplementedException();

        public void Trim() => szczyt = (int)(Count * 0.9 - 1);
    }
}