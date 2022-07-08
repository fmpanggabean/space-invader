namespace SpaceInvader.Game {
    public class Health : IAttribute<int> {
        public int value { get; set; }

        public Health(int _value) {
            value = _value;
        }

        public void Reduce(int _value) {
            value = value < _value ? 0 : value - _value;
        }
    }
}