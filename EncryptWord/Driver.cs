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
        public static void Main(string[] args) {
            EncryptWord test = new EncryptWord();
            Console.WriteLine("Welcome to the EncryptWord game!");
            Console.WriteLine("This is just a simple driver, not the final version.");
            test.encryptInput("apples");
            for (int i = 0; i < 10; i++) {
                if (test.guessShift(i)) {
                    Console.WriteLine(i + " is correct!");
                }
                else {
                    Console.WriteLine(i + " was not correct");
                }
            }
            Console.WriteLine(test.printStats());
            Console.WriteLine("All done, bye!");
        }
    }
}
