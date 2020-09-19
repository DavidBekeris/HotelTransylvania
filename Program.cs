using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace HotelTransylvania
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Room> roomsList = new List<Room>();
            int nextRoomInList = 0;
            bool invalidInput = false;
            string correctUserName = ""; // TODO: Add back username and password, empty for easier testing // Hard coded username and password bellow
            string correctUserPassword = "";
            string userNameInput;
            string userPasswordInput;
            bool notLoggedIn = true; // Not logged in, changes to false once correct information is entered
            bool insideMenu = true;
            int roomAmount = 0; // To limit array from crashing

            Console.WriteLine("Welcome to reservation manager.");
            Console.WriteLine("You need to log in to access the menu. Press any key to continue..");
            Console.CursorVisible = false;
            Console.ReadKey(true); // Just to get the user to continue to log in.
            Console.CursorVisible = true;

            // TODO: Hårdkodad loggin == DONE

            while (notLoggedIn)
            {
                Console.Clear();

                Console.Write("Username: \nPassword: ");

                Console.CursorTop--;

                userNameInput = Console.ReadLine();

                Console.SetCursorPosition(10, 1);

                userPasswordInput = Console.ReadLine();

                if (userNameInput == correctUserName && userPasswordInput == correctUserPassword)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.WriteLine("You've successfully logged in.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.CursorVisible = true;
                    notLoggedIn = false;
                }
                else
                {
                    Console.CursorVisible = false;
                    Console.Clear();
                    Console.WriteLine("Access denied!");
                    Thread.Sleep(2000);
                    Console.CursorVisible = true;
                }
            }

            ConsoleKeyInfo menuChoice;

            while (insideMenu)
            {
                Console.Clear();
                Console.WriteLine("Press the respective number from the menu to enter.\n");
                Console.WriteLine("1. Add room");
                Console.WriteLine("2. List rooms");
                Console.WriteLine("3. Remove room");
                Console.WriteLine("4. Make reservations");
                Console.WriteLine("5. List reservations");
                Console.WriteLine("9. Log out");

                menuChoice = Console.ReadKey(true);

                switch (menuChoice.Key)
                {
                    case ConsoleKey.D1: // Add room

                        Console.Clear();

                        Room newRoom = new Room();

                        Console.Write("Type room ID: ");

                        newRoom.roomId = Console.ReadLine();

                        Console.Write("Enter room description: ");

                        newRoom.roomDescription = Console.ReadLine();

                        if (roomsList.Exists(x => string.Equals(x.roomId, newRoom.roomId, StringComparison.OrdinalIgnoreCase)))
                        {
                            Console.Clear();
                            Console.WriteLine("Room id already exists, you need to enter a different id number.");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Console.Clear();
                            roomsList.Add(newRoom);
                            Console.WriteLine("Room added successfully.");
                            Thread.Sleep(2000);
                        }

                            // TODO: Add unique rooms id's only - DONE

                            // if(roomsList = newRoom.roomId)

                        //roomsList[nextRoomInList++] = newRoom;

                        //nextRoomInList++;

                        Console.WriteLine("Room has been added.");

                        break;

                    case ConsoleKey.D2: // List rooms
                        Console.Clear();
                        Console.WriteLine("ID       Occupied        Description");
                        Console.WriteLine("----------------------------------------------------");
                        foreach (Room room in roomsList)
                        {
                            if (room == null)
                            {
                                continue;
                            }
                            Console.WriteLine("{0}       {1}        {2}", room.roomId, room.roomStatus, room.roomDescription); // TODO: Check text output when occupied function is in.
                        }
                        Console.WriteLine(roomsList.Count); // TODO: Remove this line, testing purposes
                        Console.WriteLine("\n\nPress any key to go back to menu.");
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.D3: // Remove room
                        Console.WriteLine("Type room ID to remove the room.");
                        //string removeRoomUserInput;
                        //removeRoomUserInput = Console.ReadLine();

                        //for(int i = 0; i < roomAmount; i++)
                        //{
                        //    if(roomsArray[i].GetIdName() == removeRoomUserInput)
                        //    {
                        //        roomsArray[i] = 
                        //    }
                        //}

                        break;

                    case ConsoleKey.D4: // Make reservation

                        break;

                    case ConsoleKey.D5: // List reservation

                        break;

                    case ConsoleKey.D9: // Exit program
                        Console.WriteLine("You've chosen to exit. Press enter to close it completely.");
                        insideMenu = false;
                        break;
                }
            }
        }
        class Room
        {
            public string roomId;
            public string roomDescription;
            public DateTime roomStartDate;
            public DateTime roomEndDate;
            public string customer;
            public string roomStatus; // TODO: Might need to be a bool

            public override string ToString()
            {
                return $"Room ID: {roomId} \nDescription: {roomDescription} \nFrom: {roomStartDate} \nTo: {roomEndDate}\n\n"; // TODO: Might need to change how the output looks
            }

            public string GetIdName()
            {
                return roomId;
            }

        }

    }
}

/*Beskrivning	2
Inlämning	3
User stories	4
Som receptionist vill jag logga in i applikationen	4
Som receptionist vill jag lägga till ett rum	5
Som receptionist vill jag lista alla rum	6
Som receptionist vill jag ta bort ett rum	7
Som receptionist vill jag reservera ett rum	8
Som receptionst vill jag lista alla reservationer	10
Som receptionst vill jag logga ut ur applikationen	11
Självstudier	12

*/