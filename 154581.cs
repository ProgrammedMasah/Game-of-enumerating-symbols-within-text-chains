using System;

namespace BPG401_H.W
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read  max number of questions 
            Console.Write("Please enter the maximum number of question : ");
            int numQuestion = int.Parse(Console.ReadLine());
            //Test if the Max Questions is less than or Equal to Zero 
            while (numQuestion <= 0)
            {
                Console.Write("Error, The value should be greater than Zero, Please enter the maximum number of question : ");
                numQuestion = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("==========================================================");

            //create an array to generate random numbers from it 
            string[] allchar = {"0","1", "2", "3", "4", "5", "6", "7", "8", "9",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};

            //create arrays :
            string[] question = new string [numQuestion]; //to store the generate random numbers
            string[] symbol = new string [numQuestion]; //to store the question
            int[] userAnswer = new int[numQuestion]; //to store the userAnswer
            int[] correctAnswer = new int[numQuestion]; //to store the correctAnswer 
            int[] evaluation = new int[numQuestion]; //to store the evaluation 

            Random number = new Random(); //generate random numbers
            //definition of variables
            string sum = " ";
            string get;
            int run;
            int rightAnswer = 0;
            string choose;

            //create loop
            for (int l = 0; l < numQuestion; l++)
            {
                //write question number 
                Console.WriteLine("Question : {0} ", l < 1 ? 1 : l + 1);
                //Read max number of random number 
                Console.Write("please entar an integer value between 3 and 100 (the number of charecters from which to enumerate certain symboly == Degrre of difficulty) : ");
                int numRandom = int.Parse(Console.ReadLine());

                //Test if the Max Questions is less than or Equal to Zero
                while (numRandom < 3 || numRandom > 100)
                {
                    Console.Write("Error, The value should be in between [3, 100] \nPlease enter the max number of random number  : ");
                    numRandom = int.Parse(Console.ReadLine());
                }

                //create an arrays to store random chars, one by one 
                string[] chars = new string[numRandom];
                //create an loop to generate random numbers
                for (int j = 0; j < numRandom; j++)
                {
                    int index = number.Next(0, 61);
                    chars[j] = allchar[index];
                    sum += chars[j];
                }
                question[l] = sum; //storing the random string within the array

                //generate random char from random string array
                run = number.Next(0, numRandom);
                get = chars[run];
                symbol[l] = get;

                //write the question 
                Console.WriteLine("How many times the symbol {0} has been repeated in the following characters", symbol[l]);
                Console.WriteLine(question[l]);
                Console.WriteLine("To ignore the question typy Ignore ");
                //read user answer
                string read = (Console.ReadLine());

                //store the user's answer in an array
                if (read != "Ignore")
                    userAnswer[l] = int.Parse(read); 
                else userAnswer[l] = 0;
                Console.WriteLine("==========================================================");

                //create a loop to cacalculate the correct answer
                for (int k = 0; k < chars.Length; k++)
                {
                    if (symbol[l] == chars[k])
                        rightAnswer += 1;
                }
                correctAnswer[l] = rightAnswer; //store the correct answer in an array

                //store the values in the evaluation array
                if (userAnswer[l] == correctAnswer[l])
                    evaluation[l] = 1;
                else
                    evaluation[l] = 0;

                //value emptying
                sum = " ";
                rightAnswer = 0;
            } 
                
            //create a loop to present choices to the user
            do
            {
                //write options
                Console.WriteLine("To get the number of right answers , type 1");
                Console.WriteLine("To get the number of worng answers , type 2");
                Console.WriteLine("To view all the questions with correct and answered responses , type 3");
                Console.WriteLine("To exit , type exit");
                //read user choice
                choose = Console.ReadLine();
                //execute the command
                if (choose == "1")
                    Console.WriteLine(" The number of right answers is : " + numCorrect(numQuestion, evaluation) );
                if (choose == "2")
                    Console.WriteLine(" The number of worng answers is : " + numWrong(numQuestion, evaluation) );
                if (choose == "3")
                    all(question, symbol, userAnswer, correctAnswer);
            } while (choose != "exit");

        }


        //create a function to return the number of correct answers
        static int numCorrect(int numQuestion, int[] evaluation)
        {
            int total = 0;
            //create a loop to cacalculate the number of correct answer
            for (int i = 0; i < numQuestion; i++)
            {
                if (evaluation[i] == 1)
                    total += 1;
            }
            return total;
        }
        //create a function to return the number of wrong answers
        static int numWrong(int numQuestion, int[] evaluation)
        {
            int total = 0;
            //create a loop to cacalculate the number of wrong answer
            for (int i = 0; i < numQuestion; i++)
            {
                if (evaluation[i] == 0)
                    total += 1;
            }
            return total;
        }
        //create a function to return all : Question, Symbol, User Answer and  correct answer 
        static void all(string[] question, string[] symbol, int[] userAnswer, int[] correctAnswer)
        {
            Console.WriteLine("Question  \t  Symbol  \t  User Answer  \t  Correct Answer");
            Console.WriteLine("============================================================================================================");
            //create a loop to write all : Question, Symbol, User Answer and  correct answer  
            for (int i = 0; i < question.Length; i++)
            {
                 Console.WriteLine(question[i] + ", \t " + symbol[i] + " \t " + userAnswer[i] + " \t " + correctAnswer[i]);
            }
        }  
    }
}
