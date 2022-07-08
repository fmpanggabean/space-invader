using System;


namespace SpaceInvader.Game {
    [Serializable]
    public class Score {
        private GameManager gameManager;

        public int score1;
        public int score2;
        public int highscore;

        public Score(GameManager gameManager) {
            this.gameManager = gameManager;
        }

        public event Action<int> onGainScore;

        public void GainScore(int _score) {
            score1 += _score;
            onGainScore?.Invoke(score1);
        }

        internal void SetHighscore(int _highscore) {
            highscore = _highscore;
        }

        internal void SetHighscore(GameData _data) {
            highscore = _data.highscore;
        }
    }
}