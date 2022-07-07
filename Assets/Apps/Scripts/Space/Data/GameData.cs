using System;

namespace Space {
    [Serializable]
    public class GameData {
        public int highscore;

        public int GetScore() {
            return highscore;
        }

        public void SetHighScore(int score) {
            if (score > highscore) {
                highscore = score;
            }
        }
    }
}