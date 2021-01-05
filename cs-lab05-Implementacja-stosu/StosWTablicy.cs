using System;
using System.Collections;
using System.Collections.Generic;

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

        public int TabLength => tab.Length;

        public T this[int index] => index > Count - 1 ? throw new IndexOutOfRangeException() : tab[index]; 

        public void TrimExcess() => szczyt = (int)(Count * 0.9 - 1); //TODO: back to the function

        private class EnumStos : IEnumerator<T>
        {
            private StosWTablicy<T> _stosWTablicy;
            private int position = -1;

            internal EnumStos(StosWTablicy<T> stosWTablicy) => this._stosWTablicy = stosWTablicy;

            public T Current => _stosWTablicy.tab[position];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                if (position >= _stosWTablicy.Count - 1) return false;
                position++;
                return true;
            }

            public void Reset() => position = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public IEnumerable<T> TopToBottom
        {
            get
            {
                for (int i = Count - 1; i >= 0; i--)
                {
                    yield return this[i];
                }
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<T> ToArrayReadOnly()
        {
            return Array.AsReadOnly(tab);
        }
    }
}