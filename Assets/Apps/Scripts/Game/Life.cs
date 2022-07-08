using System;

namespace SpaceInvader.Game {
    public class Life {
        public int value;

        public Life(int v) {
            value = v;
        }

        public bool HasLife() {
            return value > 0;
        }

        internal void Reduce(int v) {
            value -= v;
        }
    }
}