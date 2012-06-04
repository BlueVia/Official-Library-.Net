// -------------------------------------------------------------------------- // 
// BlueVia is a global iniciative of Telefonica delivered by Movistar and O2. //
// Please, check out www.bluevia.com and if you need more information contact //
// us at support@bluevia.com"                                                 //
// -------------------------------------------------------------------------- // 

using System;

namespace BlueviaExamples
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <copyright file="Example_Launcher.cs" company="Telefónica R&D">GNU LPL v3.</copyright>
    /// <summary> Main class, loads the examples, and manages their execution through a console menu.</summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
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
            IExample[] examples = new IExample[]{
                new Example_Advertising(),
                new Example_Directory(),
                new Example_Directory_Access(),
                new Example_Directory_Personal(),
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


                //IExample Selection:
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
                                examples[selection_int].call("vw12012654505986", "WpOl66570544",
                                    "ad3f0f598ffbc660fbad9035122eae74",
                                    "4340b28da39ec36acb4a205d3955a853");

                                //Console.
                                Console.WriteLine("\nPress any key to continue.");
                                enter = Console.ReadKey();
                            }
                            else
                            {
                                requestDone = false;
                                Console.WriteLine("\nThe selection must be a number between 1 and " + length);
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
