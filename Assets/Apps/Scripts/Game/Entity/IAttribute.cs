namespace Space.Game {
    public interface IAttribute<T> {
        public T value { get; set; }
        public void Reduce(int _value);
    }
}