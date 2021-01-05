namespace cs_lab05_Implementacja_stosu
{
    public class StosWLiscie<T> : IStos<T>
    {
        
        private class Wezel
        {
            public T data;
            public Wezel next;

            public Wezel(T e, Wezel next)
            {
                this.data = e;
                this.next = next;
            }
        }

        private Wezel peak;

        public StosWLiscie()
        {
            peak = null;
        }
        
        public void Push(T value)
        {
            peak = new Wezel(value,peak);
        }

        public T Peek => IsEmpty ? throw new StosEmptyException() : peak.data;
        
        public T Pop()
        {
            if (IsEmpty) throw new StosEmptyException();
            peak = peak.next;
            return peak.data;
        }

        public int Count { get; }
        public bool IsEmpty => peak == null;
        public void Clear() => peak = null;

        public T[] ToArray()
        {
            var tab = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                tab[i] = peak.data;
                peak = peak.next;
            }

            return tab;
        }

        public T this[int index] => throw new System.NotImplementedException();

        public void TrimExcess()
        {
            throw new System.NotImplementedException();
        }
    }
}