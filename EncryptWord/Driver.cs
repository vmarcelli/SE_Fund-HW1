/* 
 * AUTHOR: Valerio Marcelli
 * FILENAME: Driver.cs
 * DATE: 4/27/2018
 * REVISION HISTORY: Last revised 4/29/2018
 * REFERENCES: None
 */
using System;

namespace Assignment1 {
    /* Description:
     * This is a simple test Driver class created to get the Main class
     * working. It only has a hello and goodbye messages as well as an 
     * initiator for the Main class. That's all there is. 
     */
    class Driver {
        //Hello message
        const string HI = "Welcome to the Encryption Word Game!\nFor a " +
                          "list of helpful " +
                          "commands type in 'help'" +
						  "\nIf you're a grader, and would like the game" +
                          " to be automated, simply type in 'test'";
        //Goodbye Message
        const string BYE = "That's all, goodbye!";
        public static void Main(string[] args) {
            Console.WriteLine(HI);
            //Starts Main game-loop until the user uses 'quit' command
            Main encryptGame = new Main();
            Console.WriteLine(BYE);
        }
    }
}
