/*
AUTHOR: Valerio Marcelli
FILENAME: encryptWord.cs
DATE: 4/10/2018
REVISION HISTORY: Last revised 4/11/2018


*/
using System;

namespace Assignment1 {
    class Program {

        static void Main(string[] args) {
            Console.WriteLine("Hello, world!");


        }
    }

    public class EncryptWord {
         
        /* Global variables */
        private int shiftNum, totalQueries, highGuesses, lowGuesses;
        private double avgGuesses;
        private bool shiftState;
        private string lastEnteredWord;
        

        public EncryptWord() {
            shiftState = false;
            shiftNum = 0;
            totalQueries = 0;
            highGuesses = 0;
            lowGuesses = 0;
            avgGuesses = 0;
            lastEnteredWord = "";
        }

        public void encryptInput(string word) {

        }

        private void decodeWord(string oldWord) {

        }

        private bool isShifted() {
            return shiftState;
        }

        private void shiftStateAfterCorrect() {

        }

        private void newShift() {

        }

        private void newStats() {

        }

        private char findNewLetter(char letter) {
            char c = 'a';
            return c;
        }
        public bool guessShift(int guess) {
            bool b = false;
            return b;
        }

        public void resetShift() {

        }

        public string printStats() {
            string str = "";
            return str;
        }

        public bool checkShiftState() {
            bool chk = true;
            return chk;
        }

        public string decode() {
            string code = "";
            return code;
        }



    }
}
