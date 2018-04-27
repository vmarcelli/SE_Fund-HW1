/* 
 * AUTHOR: Valerio Marcelli
 * FILENAME: Driver.cs
 * DATE: 4/15/2018
 * REVISION HISTORY: Last revised 4/15/2018
 * REFERENCES: None
 */
using System;

namespace Assignment1 {
    /* Description:
     * This is a simple test Driver class created to make sure that the
     * EncryptWord class is functioning correctly. Since this is the
     * first iteration of the driver, it is in a very infantile state;
     * it is unfinished currently, its only purpose to make sure that the
     * basic game is working.
     */
    class Driver {
        const string HI = "Welcome to the Encryption Word Game!\nFor a list of helpful commands type in 'help'" +
						   "\nIf you're a grader, and would like the game to be automated, simply type in 'test'";
        const string BYE = "That's all, goodbye!";
        public static void Main(string[] args) {
            Console.WriteLine(HI);
            Main encryptGame = new Main();
            Console.WriteLine(BYE);
        }
    }
}
