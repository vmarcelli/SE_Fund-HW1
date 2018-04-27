using System;


namespace Assignment1 {
    
    class Main {

        bool gameState = false;
        EncryptWord game;
        string encryptedWord, originalWord;

        public Main() {
            newGame();
            while(gameState) {
                Console.Write(">");
                string input = Console.ReadLine();
                if(!game.checkShiftState()) {
                    game.resetShift();
                }
                gameState = commandLine(input);
            }
        }

        public bool commandLine(string cmd) {
            if(cmd == "help") {
                helpMsg();
                return true;
            }
            else if(cmd == "stats") {
                printStatistics();
                return true;
            }
            else if(cmd == "decode") {
                decodeWord();
                return true;
            }
            else if(cmd == "reset") {
                newGame();
                return true;
            }
            else if (cmd == "guess") {
                Console.Write("Enter your guess: ");
                string numInput = Console.ReadLine();
                int cmdInt;
                bool numChk = int.TryParse(numInput, out cmdInt);
                if(numChk) {
                    guessShiftNum(cmdInt);
                }
                else {
                    Console.WriteLine(numInput +
                        " is not an acceptable input for a valid number guess");
                }
                return true;

            }
            else if(cmd =="rules") {
                gameRules();
                return true;
            }
            else if(cmd == "encrypt") {
                Console.Write("\nEnter word to encrypt (4 characters or longer): ");
                string wordToEncrypt = Console.ReadLine();
                if(wordToEncrypt.Length >= 4) {
                    encryptUserWord(wordToEncrypt);
                    return true;
                }
                else {
                    Console.WriteLine("You have either entered something that is not a word");
                    Console.WriteLine("or a wird that is less than 4 characters in length");
                    Console.WriteLine("Please try again.");
                    return true;
                }
            }
            else if(cmd == "test") {
                testEncryptWord();
                return true;
            }
            else if(cmd == "quit") {
                Console.WriteLine("Quitting game...");
                return false;
            }
            else {
                Console.WriteLine("You have entered an unrecognized command");
                Console.WriteLine("Please try again");
                return true;
            }
        }

        private void helpMsg() {
            Console.WriteLine("rules - Lists out the basic rules of the game.");
            Console.WriteLine("reset - Resets the whole game, including the statistics that were gathered so far.");
            Console.WriteLine("encrypt - Returns an encryted version of a < word > that is not less than 4 characters.");
            Console.WriteLine("guess - Guess the current shift value.");
            Console.WriteLine("stats - Prints out the accumlated statistics for the current game.");
            Console.WriteLine("decode - returns the original form of the lastly entered word.");
            Console.WriteLine("test - Automated testing command for faster testing.");
            Console.WriteLine("quit - Quits the game.");
        } 

        private void decodeWord() {
            string oldWord = game.decode();
            if (oldWord == "") {
                Console.WriteLine("No word has been entered yet");
            }
            else {
                Console.WriteLine("Decoded Word: " + oldWord);
            }
        }

        private void printStats() {
            string stats = game.printStats();
            Console.WriteLine(stats);
        }

        public void newGame() {
            game = new EncryptWord();
            game.resetShift();
            game.resetStats();
            gameState = true;
        }

        private void guessShiftNum(int guess) {
            if(!game.checkShiftState()) {
                game.resetShift();
            }
            bool correct = game.guessShift(guess);
            if(correct) {
                Console.WriteLine("You guessed correctly!");
                Console.WriteLine("The Caesar Shift value has been " +
                    "automatically reset for you");
                Console.WriteLine("and your statistics have " +
                    "been updated!");
                Console.WriteLine("You can check them with the " +
                    "'stats' command.");
            }
            else {
                Console.WriteLine("Sorry, you guessed incorrectly");
            }
            
        }

        private void encryptUserWord(string word) {
            string encrytped = game.encryptInput(word);
            Console.WriteLine("Encrypted " + word + " is " + encrytped);
        }

        private void gameRules() {
            Console.Write("\nThe objective of the game is to guess " +
                          "the value of " +
                          "the Caesar Shift." +
                          "\nOnce you encrypt a word, you will receive an " +
                          "encrypted version of it." +
                          "\nAfter each guess you will receive " +
                          "a message letting " +
                          "you know if you were correct or not." +
                          "\nDon't forget: You can choose a new shift " +
                          "by using the 'reset shift' command," +
                          "\nand the 'stats' command to check up on " +
                          "your progress.");
        }

        private void printStatistics() {
            Console.WriteLine(game.printStats());
        }

        public void testEncryptWord() {
            Console.WriteLine("Welcome to EncryptWord Test! This process is automated, no input is required.");
            Console.WriteLine("Now starting a new game, Test Game 1...");
            EncryptWord testGame1 = new EncryptWord();
            Console.WriteLine("New game created...");
            Console.WriteLine("The current stats should be at 0...");
            string testStats = testGame1.printStats();
            Console.WriteLine(testStats);

            string word1 = "Rhino", word2 = "LaRRy";
            string word3 = "ECLIPSE", word4 = "Egyptian";
            Console.WriteLine("Now testing the encrypt function...");
            Console.WriteLine("Inputting valid inputs...");
            Console.WriteLine("Inputting the word " + word1 + "...");
            Console.WriteLine("Encrypted " + word1 + " is " + testGame1.encryptInput(word1));
            Console.WriteLine("Decoded: " + testGame1.decode());
            Console.WriteLine("Inputting the word " +  word2 + "...");
            Console.WriteLine("Encrypted " + word2 + " is " + testGame1.encryptInput(word2));
            Console.WriteLine("Decoded: " + testGame1.decode());
            Console.WriteLine("Inputting the word " + word3 + "...");
            Console.WriteLine("Encrypted " + word3 + " is " + testGame1.encryptInput(word3));
            Console.WriteLine("Decoded: " + testGame1.decode());
            Console.WriteLine("Inputting the word " + word4 + "...");
            Console.WriteLine("Encrypted " + word4 + " is " + testGame1.encryptInput(word4));
            Console.WriteLine("Decoded: " + testGame1.decode());

            testStats = testGame1.printStats();
            Console.WriteLine("Current stats so far: " + testStats);

            Console.WriteLine("Attempting to guess the shift, will loop until correct...");
            for (int i = 0; i < 10; i++) {
                if (testGame1.guessShift(i)) {
                    Console.WriteLine(i + " is correct!");
                }
                else {
                    Console.WriteLine(i + " was not correct");
                }
            }

            testStats = testGame1.printStats();
            Console.WriteLine("Current stats so far: " + testStats);
            Console.WriteLine("You can still play the user-input version of the game.");
            Console.WriteLine("Use 'help' for a list of commands.");
        }
    }
}
