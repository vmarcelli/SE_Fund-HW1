/* 
 * AUTHOR: Valerio Marcelli
 * FILENAME: encryptWord.cs
 * DATE: 4/10/2018
 * REVISION HISTORY: Last revised 4/15/2018
 * REFERENCES: None
 */
using System;

namespace Assignment1 {

    /* Description:
     * The EncryptWord class is the main method through which the guessing 
     * game is played. The class can randomly generate a number by which it can
     * shift each letter of a word. A scoreboard of the user's guesses is kept
     * which the user may then call upon to check their progress. The class 
     * also allows for the user to call upon the scoreboard and have it 
     * printed out.The class relies mainly on the driver class for protection 
     * against illegal input. Except for the encryption function, which checks 
     * to see if the shift state has been initialized or not, there is no other 
     * defensive programming that is done on EncryptWord. Without the main 
     * driver file, EncryptWord relies on the user to use only legal input, 
     * as doing otherwise would most likely cause a crash. Incorrect, or 
     * illegal input, without the intended defensively programmed driver file 
     * cannot guarantee intended outcomes. Legal input, in this case, meaning 
     * numbers for guessing the correct shift value, and words for the encryption 
     * method. Depending on the function, different sorts of data types can be 
     * returned.The decryption function returns a string, while most of the other 
     * functions return Booleans to check whether the input was correct or not.
     */

    /* Assumptions:
     * The main assumption is that the user is primarly using this class to only
     * play the guessing game, and nothing else. The class assumes that the main 
     * driver file is protecting it from faulty input, and doesn't have to worry
     * about that itself. Illegal input in this case would be trying to pass
     * anything that isnt a word through the encryption. The user should also
     * be able to figure out what the Caesar Shift is on their own without any
     * more help from the class, other than being provided with the encrypted
     * word.
     *  When a word is encrypted from the driver file it is sent through 
     * several processes of the encryption function. Firstly, the original
     * word, before it's encrypted, is stored as the decoded word. The 
     * original, or 'decoded', word can then be called by the user at any time.
     * A char array was used for the encrypt class, because it seemed like the
     * best way to handle each individual letter from a word one at a time.
     * The word is converted into a lowercase version, in case of upper-case
     * letters being input. The array would replace each letter with its 
     * shifted version in the array, and then it would build a new string 
     * by going through the array in a for loop. The array adapts its size 
     * accord to the word length it receives. The array is created through a 
     * the first for loop. The second for loop is used right after to replace each
     * letter in the array with the corresponding lower-case char depending on the 
     * value of the Caesar Shift. The second for loop slowly builds a new string
     * out of the newly shifted char array and then returns the newly encrypted
     * word to the driver file.
     *  The encryption part of the program assumes that the user
     * understands that they are encrypting a word.If the user
     * inserts the wrong input, the outcome of what is shifted
     * cannot be guaranteed.If, for example, the user inserts
     * something like 1234, the encrypt function will still shift the
     * value of 1234, despite it not being a word.
     * Each letter in the array is shifted by taking the letter's
     * value, adding the Caesar shift value, subtracting the
     * maximum value of the ascii lower - case letters(122), and
     * adding the minimum value(96).
     *  The global variables chosen are things that seemed like they would 
     * need to have a recurring value throughout the file, such as statistics or
     * the state of the Caesar Shift. The value of the Caesar shift changes
     * randomly from 1-10 every time it is called. The range was picked because
     * it seemed an appropriate to the game, with enough difference to not become
     * too confusing or cause too many issues. The Caesar Shift state starts off as
     * false when the program first begins. Once the user encrypts a word, the state
     * changes from a false (OFF state), to a true (ON state). It is not in the 
     * program's nature to let the user turn this state on or off during the use
     * of the program. The state goes back to an OFF state during the use off the
     * program if the user correctly guesses the Caesar Shift value.
     *  The implementation for guessing is done through simple comparisons
     * of the user's guess and the current value of the Caesar Shift. If the user
     * guesses correctly the shift value is reset and the Boolean flag is returned
     * True; it's returned False if the guess doesn't match.In all instances, whether
     * True or False, the appropriate statistics are then updated.
     *  The guess function assumes that the user knows that the value they are 
     * guessing for is a number.The outcome of trying to guess "ABC" as the 
     * Caesar Shift value will not guarantee a successful outcome for the program.
     * There are several reset functions in the EncryptWord class.
     *  Some of the reset functions are publicly available to be used by the user.
     * The goal was to let the user decide when they would like to either reset the
     * Caesar Shift value, or both the shift and the statistics.This would allow 
     * them to start a fresh session of the Encryption game whenever they want to.
     * The implementation is a simple one, the user can call the appropriate
     * function with the respective command from the driver file, and the reset
     * function will reset the value of either the accumulated statistics or the
     * Caesar Shift.With the statistics, the counters are reset to 0. For
     * the Caesar Shift, on the other hand, the value is simply a new one.The
     * newShift() function is the same function that is called when a user first
     * starts the game, as well as the function that is called if the shift state 
     * is not ON.
     */

    public class EncryptWord {
         
<<<<<<< HEAD
    /* Global variables */
    //Statistics for user guesses
    private int shiftNum, totalQueries, highGuesses, lowGuesses;
=======
        /* Global variables */
        //Statistics for user guesses
        private int shiftNum, totalQueries, highGuesses, lowGuesses;
>>>>>>> ea42d53d99debc20944a48f2997d84449ad1a67e
        private double avgGuesses;  //Average number of guess
        private bool shiftState;    //The current 'state' of the program
                                    //A boolean value that checks whether some
                                    //functions may or may not execute
        private string lastEnteredWord; //A space to store the last word entered
        
        /* Description: Default constructor for EncryptWord 
         * All values are intialized at either empty or 0.
         * The shiftState is set to false since no appropriate 
         * guesses were made at the start of the program.
         * precondition: Class has not been called
         * postcondition: Class may be called
         */
        public EncryptWord() {
            shiftState = false;
            shiftNum = 0;
            totalQueries = 0;
            highGuesses = 0;
            lowGuesses = 0;
            avgGuesses = 0;
            lastEnteredWord = "";
        }

        /* Description: Takes in a word supplied by the user and encrypts it
         * based on the value of the generated Caesar shift.
         * Calls the private method findNewLetter() to add the
         * Caesar Shift value to the encrypted word. Requires the
         * isShifted state to be true.
         * Automatically adds the original version of the word using decodeWord().
         * precondition: none
         * postcondition: none
         */
        public string encryptInput(string word) {
            //Check shift-state
            if (!checkShiftState()) {
                resetShift();
            }
            //Pass in old word
            decodeWord(word);
            int wordSize = word.Length;
            char newLetter;
            string decryptedWord = "";
            char[] charArray = new char[wordSize];

            //Decrypt
            for(int i=0; i < wordSize; i++) {
                newLetter = findNewLetter(charArray[i]);
                charArray[i] = newLetter;
                decryptedWord += charArray[i];
            }

            return decryptedWord;
        }

        /* Description: Helper function for encryptInput()
         * precondition: none
         * postcondition: none
         */
        private void decodeWord(string oldWord) {
            lastEnteredWord = oldWord;
        }

        /* Description: Helper function for checkShiftState()
         * precondition: none
         * postcondition: none
         */
        private bool isShifted() {
            return shiftState;
        }

        /* Description: Helper function for guessShift()
         * precondition: none
         * postcondition: none
         */
        private void shiftStateAfterCorrect() {
            shiftState = false;
        }

        /* Description: Helper function for resetShift()
         * precondition: none
         * postcondition: none
         */
        private void newShift() {
            Random rand = new Random();
            int randNum = rand.Next() % 10 + 1;
            shiftNum = randNum;
        }

        /* Description: Calls the newStats() function to reset all generic
         *              statistics and numbers back to 0. This doesn't mean
         *              that the shift has changed, because it remains the 
         *              same based off of user guesses, not statistics.
         * precondition: none
         * postcondition: none
         */
        public void resetStats() {
            newStats();
        }

        /* Description: Helper function for resetStats()
         * precondition: none
         * postcondition: none
         */
        private void newStats() {
            totalQueries = 0;
            highGuesses = 0;
            lowGuesses = 0;
            avgGuesses = 0;
        }

        /* Description: Helper function for encryptInput()
         * precondition: none
         * postcondition: none
         */
        private char findNewLetter(char letter) {
            //Constant values for ASCII library
            const int ASCII_LC_MAX = 122;
            const int ASCII_LC_MIN = 96;
            int sum = letter + shiftNum;

            //Adjust for going beyond ASCII limit
            if (sum > ASCII_LC_MAX) {
                sum = sum - ASCII_LC_MAX + ASCII_LC_MIN;
            }
            char newLetter = (char)sum;
            return newLetter;
        }

        /* Description: Checks to see if the guess input from the user 
         *              matches the current Caesar Shift value. Returns
         *              a boolean flag of true or false depending on whether
         *              the user was correct or not. If the guess is correct, 
         *              the function will call the shiftStateAfterCorrect()
         *              function to change the shiftState back to false
         *              (the OFF state).
         * precondition: Either a word was encrypted or the shift was reset
         *               already. Requires the isShifted state to be true.
         * postcondition: Statistics should have been updated depending on the 
         *                outcome.
         */
        public bool guessShift(int guess) {
            //If correct
            if (guess == shiftNum) {
                totalQueries++;
                avgGuesses += guess;
                shiftStateAfterCorrect();
                resetShift();
                return true;
            }
            //If too high
            else if(guess > shiftNum) {
                totalQueries++;
                avgGuesses += guess;
                highGuesses++;
                return false;
            }
            //If too low
            else {
                totalQueries++;
                avgGuesses += guess;
                lowGuesses++;
                return false;
            }
        }

        /* Description: Calls the private function newShift(). This will
         *              reset the Caesar Shift value to a new one.
         * precondition: none
         * postconditon: none
         */
        public void resetShift() {
            newShift();
        }

        /* Description: Creates a string of the currently accumulated
         *              statistics and then returns it to the main driver.
         * precondition: statistics global variables were initialized in the
         *               constructor.
         * postconditon: none
         */
        public string printStats() {
            double guessAvg;
            if(totalQueries == 0) {
                guessAvg = 0;
            }
            else {
                guessAvg = avgGuesses / totalQueries;
            }
            string stats = "\nTotal number of guesses: " + (totalQueries)
                            + "\nHigh guesses: " + (highGuesses)
                            + "\nLow guesses: " + (lowGuesses)
                            + "\nAverage guess value: " + (guessAvg);
            return stats;
        }

        /* Description: Calls the private function isShifted(). Checks if the
         *              state for the Caesar Shift has been initilized.
         * preconditon: Shift function has been initilized in the constructor.
         * postcondition: none
         */
        public bool checkShiftState() {
            return isShifted();
        }

        /* Description: Returns the lastly entered word in case the user
         *              forget what it was. Sends string to decodeWord()
         *              to set the decoded word to the most recently entered
         *              one.
         * precondition: A word must have been encrypted by the user already.
         * postcondition: none
         */
        public string decode() {
            return lastEnteredWord;
        }
    }
}
