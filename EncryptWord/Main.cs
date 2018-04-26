using System;


namespace EncryptWord {
    class Main {

        public Main() {
            newGame();
        }

        public void newGame() {
            string word = getWord();
            encrypt(word);
        }

        public string getWord() {
            Random rand = new Random();
            int randNum = rand.Next() % 10 + 1;
            string[] wordArr = new string[]{"Apples", "Cream", "Rubies",
                                 "Trees", "Sunny"};
            return wordArr[randNum];
        }

        public void encrypt(string word) { }

        public bool guess(int num) { return true; }

        public void printStatistics() { }

        public bool endGame() { return true;  }



    }
}
