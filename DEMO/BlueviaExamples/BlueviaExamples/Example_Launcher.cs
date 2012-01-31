using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueviaExamples
{
    class Example_Launcher
    {
        //*********************************************************************************
        /*
         * TO RUN THE EXAMPLES PRESS : "F5"
         * This is just a launcher, so you can ignore the code of this class.
         * The code of the examples are in the "Example_... .cs" CLASSES
         */
        //*********************************************************************************
        static void Main(string[] args)
        {
            Console.Title = "BLUEVIA'S .NET EXAMPLE LAUNCHER";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            ConsoleKeyInfo enter;
            bool end = false;
            //Array to contain an instance of every Bluevia example:
            Example[] examples = new Example[]{
                new Example_Advertising(),
                new Example_Directory_Access(),
                new Example_Directory_Profile(),
                new Example_Directory_Terminal(),
                new Example_Location(),
                new Example_MMS_MO(),
                new Example_MMS_MT(),
                new Example_MMS_Notifications(),
                new Example_OAuth(),
                new Example_Payment(),
                new Example_SMS_MO(),
                new Example_SMS_MT(),
                new Example_SMS_Notifications()
            };


                //Example Selection:
                do{
                    bool requestDone=false;
                    int length = examples.Length;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("\t*************************************");
                        Console.WriteLine("\t** BLUEVIA'S .NET EXAMPLE LAUNCHER **");
                        Console.WriteLine("\t*************************************");
                        Console.WriteLine("\n\tSelect an example to make the call:");
                        Console.WriteLine("\n\tOr Type \"end\" to exit.\n");
                        //Printing the examples list
                        Console.WriteLine("**********************************************************\n");
                        for (int i = 0; i < length; i++)
                        {
                            Console.WriteLine(" "+(i+1) + "\t: " + examples[i].GetType());
                        }
                        Console.WriteLine(" end\t: to exit.");
                        Console.WriteLine("\n**********************************************************\n");

                        //Capturing the example selection
                        String selection_String = Console.ReadLine();
                        int selection_int = 0;
                        bool selectionIsNumber = int.TryParse(selection_String, out selection_int);

                        if (selectionIsNumber)
                        {
                            selection_int--;
                            if ((0<= selection_int)&&(selection_int < length))
                            {
                                requestDone = true;
                                Console.Clear();
                                Console.WriteLine("\nYou have selected: " + examples[selection_int].GetType().Name + ".\n");
                                Console.WriteLine("----------------------------------------------------------\n");
                                Console.WriteLine(examples[selection_int].getDescription());
                                Console.WriteLine("\n----------------------------------------------------------\n");
                                Console.WriteLine("Press any key to continue.");
                                enter = Console.ReadKey();
                                //A valid number has been selected, launching the example:
                                examples[selection_int].call();

                                //Console.
                                Console.WriteLine("Press any key to continue.");
                                enter = Console.ReadKey();
                            }
                            else
                            {
                                requestDone = false;
                                Console.WriteLine("The selection must be a number between 1 and " + length);
                                Console.WriteLine("Press any key to retry.");
                                enter = Console.ReadKey();
                            }
                        }
                        else
                        {
                            if(selection_String.StartsWith("end")){
                                requestDone = true;
                                end = true;
                            }else{
                            requestDone = false;
                            Console.WriteLine("The selection must be a number between 1 and " + length);
                            Console.WriteLine("Press any key to retry.");
                            enter = Console.ReadKey();
                            }
                        }
                    } while (!requestDone);

                } while (!end);


        }
    }
}
