using System;
using System.Collections.Generic;
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

                        AddNewRoom(roomsList);

                        break;

                    case ConsoleKey.D2: // List rooms
                        ListRooms(roomsList);

                        Console.WriteLine("\n\nPress any key to go back to menu.");

                        Console.ReadKey(true);

                        break;

                    case ConsoleKey.D3: // Remove room

                        ListRooms(roomsList);

                        Room removeRoom = new Room();

                        while (true)
                        {
                            Console.Write("\nType room ID to remove: ");

                            removeRoom.roomId = Console.ReadLine();

                            Console.Write("You sure you want to delete this room? [Y]es or [N]o: ");
                            string userConfirm = Console.ReadLine();
                            if (userConfirm == "Y")
                            {

                                Console.WriteLine(roomsList.Count);
                                for (int i = 0; i <= roomsList.Count; i++)
                                {
                                    Console.WriteLine(roomsList.Count);

                                    // TODO: Out of range if trying to delete something that doesnt exist. Try catch might solve it ?
                                    try { 
                                    if (removeRoom.roomId == roomsList[i].roomId)
                                    {
                                        roomsList.RemoveAt(i);
                                        Console.WriteLine("Room deleted: {0}", removeRoom.roomId);
                                        Thread.Sleep(2000);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("There is nothing to delete.");
                                            Thread.Sleep(2000);
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Exception has been caught.");
                                        Thread.Sleep(2000);
                                    }
                                }
                                break;
                            }
                            else if(userConfirm == "N")
                            {
                                Console.WriteLine("Going back to menu.");
                                Thread.Sleep(2000);
                                break;
                            }
                        }

                        //if (roomsList.Exists(x => string.Equals(x.roomId, removeRoom.roomId, StringComparison.OrdinalIgnoreCase)))
                        //{
                        //    Console.Write("You sure you want to delete this room? [Y]es or [N]o: ");
                        //    string userConfirm = Console.ReadLine();
                        //    if(userConfirm == "Y")
                        //    {
                        //        Console.WriteLine("Room removed: {0}", removeRoom.roomId);
                        //        //roomsList.Remove(removeRoom);
                        //        roomsList.Remove(removeRoom);
                        //        Thread.Sleep(2000);
                        //        //removeRoom.roomId.Remove(;
                        //    }
                        //    //else if()
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Somethin went wrong.");
                        //}

                       // Console.ReadKey(true);
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

        private static void AddNewRoom(List<Room> roomsList)
        {
            Console.Clear();

            Room newRoom = new Room();

            Console.Write("Type room ID: ");

            newRoom.roomId = Console.ReadLine();

            Console.Write("Enter room description: ");

            newRoom.roomDescription = Console.ReadLine();

            // Compares string ID from user input and list and evaluates if it already exists

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
        }

        private static void ListRooms(List<Room> roomsList)
        {
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