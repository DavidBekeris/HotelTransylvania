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

            bool invalidInput = false; // TODO: Only accept certain keys
            string correctUserName = ""; // TODO: Add back username and password, empty for easier testing // Hard coded username and password bellow
            string correctUserPassword = "";
            string userNameInput;
            string userPasswordInput;
            bool notLoggedIn = true; // Not logged in, changes to false once correct information is entered
            bool insideMenu = true;
            int counter = 0;
            // Room newRoom = new Room();


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

                        counter = RemoveARoom(roomsList, counter);

                        break;

                    case ConsoleKey.D4: // Make reservation

                        Console.Clear();

                        ListRooms(roomsList);

                        Room reservation = new Room();

                        while (true)
                        {
                            Console.Write("\nType room ID to make an reservation: ");

                            reservation.roomId = Console.ReadLine();
                            //string reservationIdInput = Console.ReadLine();

                            for (int i = 0; i <= roomsList.Count; i++)
                            {
                                // TODO: Out of range if trying to delete something that doesnt exist. Try catch might solve it ?
                                try
                                {
                                    if (reservation.roomId == roomsList[i].roomId)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter date reservation starts for this id {0} (yyyy-mm-dd tt:hh): ", reservation.roomId);
                                        reservation.roomStartDate = DateTime.Parse(Console.ReadLine());
                                        //roomsList[counter++] = reservation;
                                        //roomsList.Add(reservation);

                                        Console.WriteLine("Enter date reservation ends for this id {0} (yyyy-mm-dd tt:hh): ", reservation.roomId);
                                        reservation.roomEndDate = DateTime.Parse(Console.ReadLine());
                                        //roomsList[counter++] = reservation;
                                        //roomsList.Add(reservation);
                                        roomsList.Insert(i, reservation);
                                        //roomsList.Insert();


                                        Console.WriteLine("Reservation successful");
                                        Thread.Sleep(2000);
                                        break;
                                    }
                                    //else // TODO: This else statement might be of no use because have a catch?
                                    //{
                                    //    Console.WriteLine("There is nothing to delete.");
                                    //    Thread.Sleep(2000);
                                    //}
                                }
                                catch
                                {
                                    Console.WriteLine("Exception has been caught.");
                                    Thread.Sleep(2000);
                                }
                            }
                            //roomsList.Add(reservation);
                            //roomsList[counter++] = reservation;
                            break;

                        }
                        // Annan kod jag försökte att reservera med, tyvärr samma sak. Jag lyckas inte länka nya tillägg med befintliga ID numret.

                        //Room bookReservation = new Room();

                        //// string roomIdReservation;

                        //Console.Clear();

                        //ListRooms(roomsList);

                        //Console.WriteLine("Enter room id: ");
                        //Console.WriteLine("Customer: ");
                        //Console.WriteLine("Enter date reservation starts for this id {0} (yyyy-MM-dd tt:hh): ");
                        //Console.WriteLine("Enter date reservation ends for this id {0} (yyyy-MM-dd tt:hh): ");

                        //Console.CursorTop--;
                        //bookReservation.roomId = Console.ReadLine();
                        //bookReservation.customerFullName = Console.ReadLine();
                        //Console.SetCursorPosition(10, 1);
                        //bookReservation.roomStartDate = DateTime.Parse(Console.ReadLine());
                        //roomsList.Add(bookReservation);
                        //Console.SetCursorPosition(10, 2);
                        ////roomsList.Add(bookReservation);
                        ////roomsList[counter++] = bookReservation;
                        ////bookReservationTo.roomEndDate = DateTime.Parse(Console.ReadLine());
                        //bookReservation.roomEndDate = DateTime.Parse(Console.ReadLine());
                        //Console.SetCursorPosition(10, 3);
                        ////roomsList.Add(bookReservation);
                        ////roomsList[counter++] = bookReservation;


                        //if (roomsList.Exists(x => string.Equals(x.roomId, bookReservation.roomId, StringComparison.OrdinalIgnoreCase)))
                        //{
                        //    roomsList.Add(bookReservation);
                        //    roomsList[counter++] = bookReservation;

                        //    //bookReservation.customerFullName = Console.ReadLine();
                        //    //Console.SetCursorPosition(10, 1);
                        //    //bookReservation.roomStartDate = DateTime.Parse(Console.ReadLine());
                        //    //roomsList.Add(bookReservation);
                        //    //Console.SetCursorPosition(10, 2);
                        //    ////roomsList.Add(bookReservation);
                        //    ////roomsList[counter++] = bookReservation;
                        //    ////bookReservationTo.roomEndDate = DateTime.Parse(Console.ReadLine());
                        //    //bookReservation.roomEndDate = DateTime.Parse(Console.ReadLine());
                        //    //Console.SetCursorPosition(10, 3);
                        //    ////roomsList.Add(bookReservation);
                        //    ////roomsList[counter++] = bookReservation;

                        //    Console.WriteLine("Reservation successful");
                        //    Thread.Sleep(2000);

                        //}
                        //else
                        //{
                        //    Console.Clear();

                        //    Console.WriteLine("Could not be added.");
                        //    Thread.Sleep(2000);
                        //}
                        //// roomsList.Add(bookReservation);
                        ////roomsList.Add(bookReservation);
                        ////roomsList[counter++] = bookReservation;
                        break;

                    case ConsoleKey.D5: // List reservation

                        Console.Clear();
                        Console.WriteLine($"{"ID",-5} {"Customer",-15} {"From",-25} {"To",-35}");
                        Console.WriteLine("--------------------------------------------------------------------------");
                        foreach (Room room in roomsList)
                        {
                            if (room == null)
                            {
                                continue;
                            }
                            Console.WriteLine("{0,-5} {1, -15} {2, -25} {3, -35}", room.roomId, room.customerFullName, room.roomStartDate, room.roomEndDate);
                        }

                        Console.WriteLine("\n\nPress any key to go back to menu.");

                        Console.ReadKey(true);

                        break;

                    case ConsoleKey.D9: // Exit program
                        Console.WriteLine("You've chosen to exit. Press enter to close it completely.");
                        insideMenu = false;
                        break;
                }
            }
        }

        private static int RemoveARoom(List<Room> roomsList, int counter)
        {
            Room removeRoom = new Room();

            while (true)
            {
                Console.Write("\nType room ID to remove: ");

                removeRoom.roomId = Console.ReadLine();

                Console.Write("You sure you want to delete this room? [Y]es or [N]o: ");
                string userConfirm = Console.ReadLine();
                if (userConfirm == "Y")
                {

                    // Console.WriteLine(roomsList.Count);
                    for (int i = 0; i <= roomsList.Count; i++)
                    {
                        // Console.WriteLine(roomsList.Count);

                        // TODO: Out of range if trying to delete something that doesnt exist. Try catch might solve it ?
                        try
                        {
                            if (removeRoom.roomId == roomsList[i].roomId)
                            {
                                roomsList.RemoveAt(i);
                                Console.WriteLine("Room deleted: {0}", removeRoom.roomId);
                                counter--;
                                Thread.Sleep(2000);
                                break;
                            }
                            else // TODO: This else statement might be useless
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
                else if (userConfirm == "N")
                {
                    Console.WriteLine("Going back to menu.");
                    Thread.Sleep(2000);
                    break;
                }
            }

            return counter;
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
            else if (!roomsList.Exists(x => string.Equals(x.roomId, newRoom.roomId, StringComparison.OrdinalIgnoreCase)))
            {
                Console.Clear();
                roomsList.Add(newRoom);
                // roomsList[counter++] = newRoom;
                Console.WriteLine("Room added successfully.");
                Console.WriteLine(roomsList.Count);
                Thread.Sleep(2000);
            }

            Console.Clear();

            //Console.WriteLine("Room has been added.");
            //Thread.Sleep(2000);
        }

        //private static void AddNewRoom(List<Room> roomsList)
        //{
        //    Console.Clear();

        //    Room newRoom = new Room();

        //    Console.Write("Type room ID: ");

        //    newRoom.roomId = Console.ReadLine();

        //    Console.Write("Enter room description: ");

        //    newRoom.roomDescription = Console.ReadLine();

        //    // Compares string ID from user input and list and evaluates if it already exists

        //    if (roomsList.Exists(x => string.Equals(x.roomId, newRoom.roomId, StringComparison.OrdinalIgnoreCase)))
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Room id already exists, you need to enter a different id number.");
        //        Thread.Sleep(2000);
        //    }
        //    else
        //    {
        //        Console.Clear();
        //        roomsList.Add(newRoom);
        //        // roomsList[counter++] = newRoom;
        //        Console.WriteLine("Room added successfully.");
        //        Thread.Sleep(2000);
        //    }


        //    Console.WriteLine(roomsList.Count);
        //    Console.WriteLine("Room has been added.");
        //}

        private static void ListRooms(List<Room> roomsList)
        {
            Console.Clear();
            Console.WriteLine($"{"ID",-5} {"Description",-15}");
            Console.WriteLine("-----------------------------------------------");
            foreach (Room room in roomsList)
            {
                if (room == null)
                {
                    continue;
                }
                Console.WriteLine("{0,-5} {1, -15}", room.roomId, room.roomDescription); // TODO: Check so output looks okey
            }
        }

        class Room
        {
            public string roomId;
            public string roomDescription;
            public DateTime roomStartDate;
            public DateTime roomEndDate;
            public string customerFullName;
            public string roomStatus; // TODO: Might need to be a bool

            //public Room(
            //    string roomId,
            //    string roomDescription,
            //    DateTime roomStartDate,
            //    DateTime roomEndDate,
            //    string customerFullName)
            //{
            //    this.roomId = roomId;
            //    this.roomDescription = roomDescription;
            //    this.roomStartDate = roomStartDate;
            //    this.roomEndDate = roomEndDate;
            //    this.customerFullName = customerFullName;
            //}

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











// TODO: Add unique rooms id's only - DONE

// if(roomsList = newRoom.roomId)

//roomsList[nextRoomInList++] = newRoom;

//nextRoomInList++;