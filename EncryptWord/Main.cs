/* 
 * AUTHOR: Valerio Marcelli
 * FILENAME: Main.cs
 * DATE: 4/27/2018
 * REVISION HISTORY: Last revised 4/29/2018
 * REFERENCES: None
 */
using System;

namespace Assignment1 {
    
    /*
     * The Main class produces the game logic for the EncryptWord game.
     * It's needed to be able to get the game working. It loops the game
     * through a command line that lets the user choose how to play the
     * game. The user gets to decide how to play the game, or when they
     * would like to quit. It uses programming by contract by design, but
     * is able to avoid harmful inputs through the user commands. A command
     * lets the user progress to the next action but without the right command
     * the user won't be able to play the game correctly, preventing eronious 
     * behaviour. 
     */
    class Main {

        bool gameState = false;
        EncryptWord game;

        // description: The main cconstructor for P1, automatically starts the game once
        //              the class is created. 
        // input: none
        // processing: The user is prompted for input that is then passed through to 
        //             the commandLine() function. As long as the commandLine()
        //             returns true, the game will keep going until the user types quit. 
        // output: none 
        public Main() {
            gameState = newGame();
            while(gameState) {
                if (!game.checkShiftState()) {
                    game.resetShift();
                }
                Console.Write(">");
                string input = Console.ReadLine();
                gameState = commandLine(input);
            }
        }

        // description: The main command line function for the game. This function allows
        //				the user to manually call functions using commands.
        // input: Line of input given by the user
        // processing: Matches input cmd with the correct if statement, calling
        //             the appropriate class.
        // output: Returns a boolean flag (true/false) of whether the command line
        //			function should still be running or not. As long as the bool
        //			that is returned is true, the command line will keep asking the
        //			user for input. 
        public bool commandLine(string cmd) {
            
            /* Check through list of commands */
            if (cmd == "help") {
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

        // description: Displays a list of helpful commands that can be used with the
        //				command line function.
        // input: none
        // processing: Uses Console.WriteLine to display the command list. 
        // output:Prints out command list.
        private void helpMsg() {
            Console.WriteLine("rules - Lists out the basic rules of the game.");
            Console.WriteLine("reset - Resets the whole game, including the statistics " +
                    "that were gathered so far.");
            Console.WriteLine("encrypt - Returns an encryted version of a " +
                "word that is not less than 4 characters.");
            Console.WriteLine("guess - Guess the current shift value.");
            Console.WriteLine("stats - Prints out the accumlated " +
                "statistics for the current game.");
            Console.WriteLine("decode - returns the original form of " +
                "the lastly entered word.");
            Console.WriteLine("test - Automated testing command for " +
                "faster testing.");
            Console.WriteLine("quit - Quits the game.");
        }

        // description: This function returns the original version of the lastly
        //				encrypted word.
        // input: none
        // processing: Calls the decode() function from EncryptWord, and then prints
        //				it out using Console.WriteLine. 
        // output: Prints out the decoded word.
        private void decodeWord() {
            //Get original version of the word
            string oldWord = game.decode();
            if (oldWord == "") {
                Console.WriteLine("No word has been entered yet");
            }
            else {
                Console.WriteLine("Decoded Word: " + oldWord);
            }
        }

        // description: Calls the statistics function from EncryptWord class,
        //				then prints it.
        // input: none
        // processing: Uses Console.WriteLine to print out the string from EncryptWord.
        // output:  Calls function, prints it.
        private void printStats() {
            string stats = game.printStats();
            Console.WriteLine(stats);
        }

        // description: Resets both the shift value and the statistics from 
        //				EncryptWord. Re-constructs the EncryptWord class.
        // input: none 
        // processing: Re-Constructs EncryptWord. Calls the reset functions 
        //             in EncryptWord. Lets the user
        //			   know that the game has been reset.
        // output: none
        private bool newGame() {
            game = new EncryptWord();
            game.resetShift();
            game.resetStats();
            return true;
        }

        // description: Allows the user to guess what the current shift value is.
        // input: The value the user thinks the letters have shifted by.
        // processing: Compares the user's guess to the current shift value. Depending
        //				on the answer, the appropriate statistics are incremented,
        //				and the user is told if their guess was wrong or right.
        //				If the user guessed correctly, the game will automatically 
        //				switch into the OFF state, and reset the Caesar Shift number.
        //				If the user did not guess correctly, the appropriate message
        //				is displayed. In the case of invalid input, the appropriate
        //				message will be dislpayed out.
        //output: Depends on the users, input. Either an error message or a correct guess
        //        from winning the round.
        private void guessShiftNum(int guess) {
            //Check the shift-state
            if (!game.checkShiftState()) {
                game.resetShift();
            }

            //Check if guess is correct or not
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

        // description: Encrypts a word that the user inputs, prints out the encrypted
        //				version of that word depending on the current shift value.
        // input: String of word the user used as input
        // processing: The string is sent to the EncryptWord's encrypt function, and
        //				the new encrypted word is printed out to the user. It checks 
        //				the shift state first, to see if it was initilized.
        // output: none
        private void encryptUserWord(string word) {
            string encrytped = game.encryptInput(word);
            Console.WriteLine("Encrypted " + word + " is " + encrytped);
        }

        // description: Lists out the rules of the game for any beginner to understand
        //				how to play.
        // input: none
        // processing: Prints out list of rules.
        // output: none. 
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

        // description: Calls the statistics function from EncryptWord class,
        //				then prints it.
        // input: none
        // processing: Uses Console.WriteLine to print out the string from EncryptWord.
        // output:  Calls function, prints it.
        private void printStatistics() {
            Console.WriteLine(game.printStats());
        }

        // description: This method is used for testing purposes. It will run through
        //				all of the EncryptWord functions, testing them out. The result
        //				should be the same as playing the game yourself. This is just to
        //				save some time. 
        // input: none
        // processing: Will proccess through all of the EncryptWord functions to test
        //				them out. 
        // output: Any output included in the other functions will be included in this
        //			function as well. 
        public void testEncryptWord() {
            const int SHIFT_MAX = 11;
            Console.WriteLine("Welcome to EncryptWord Test! This process is " +
                "automated, no input is required.");
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
            Console.WriteLine("Encrypted " + word1 + " is " + 
                testGame1.encryptInput(word1));
            Console.WriteLine("Decoded: " + testGame1.decode());
            Console.WriteLine("Inputting the word " +  word2 + "...");
            Console.WriteLine("Encrypted " + word2 + " is " + 
                testGame1.encryptInput(word2));
            Console.WriteLine("Decoded: " + testGame1.decode());
            Console.WriteLine("Inputting the word " + word3 + "...");
            Console.WriteLine("Encrypted " + word3 + " is " + 
                testGame1.encryptInput(word3));
            Console.WriteLine("Decoded: " + testGame1.decode());
            Console.WriteLine("Inputting the word " + word4 + "...");
            Console.WriteLine("Encrypted " + word4 + " is " + 
                testGame1.encryptInput(word4));
            Console.WriteLine("Decoded: " + 
                testGame1.decode());

            testStats = testGame1.printStats();
            Console.WriteLine("Current stats so far: " + testStats);

            Console.WriteLine("Attempting to guess the shift, " +
                "will loop until correct...");
            for (int i = 0; i < SHIFT_MAX; i++) {
                if (testGame1.guessShift(i)) {
                    Console.WriteLine(i + " is correct!");
                }
                else {
                    Console.WriteLine(i + " was not correct");
                }
            }

            testStats = testGame1.printStats();
            Console.WriteLine("Current stats so far: " + testStats);
            Console.WriteLine("You can still play the user-input " +
                "version of the game.");
            Console.WriteLine("Use 'help' for a list of commands.");
        }
    }
}
