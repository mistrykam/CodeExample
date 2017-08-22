namespace CodeLibrary
{
    public class MyNullable<T> where T : struct
    {
        private object _value;

        public MyNullable()
        {
        }

        public MyNullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public T GetValueorDefault()
        {
            if (_value != null)
                return (T)_value;

            return default(T);
        }
    }
}
