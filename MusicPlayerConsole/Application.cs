namespace MusicPlayerConsole
{
    public class Application
    {
        public static string? selectedChoice;
        public static void SelectOption()
        {
            Console.WriteLine("1. Show All Songs");
            Console.WriteLine("2. Add Song");
            Console.WriteLine("3. Edit Song");
            Console.WriteLine("4. Remove song");
            Console.WriteLine("5. Display Playlists");
            Console.WriteLine("6. Create A playlist");
            Console.WriteLine("7. Exit");
        }
        public static void Start()
        {
            Console.Title = "My Music Player";
            Console.WriteLine("*****Welcome to my Music Player App*****");
            Console.WriteLine("What would you like to do ");
            
            bool IsAlive = true;
            while (IsAlive)
            {
                SelectOption();
                selectedChoice = Console.ReadLine();
                try
                {
                    if (string.IsNullOrWhiteSpace(selectedChoice))
                    {
                        throw new InvalidInput("Invalid Input");
                    }

                }
                catch (InvalidInput ex)
                {
                    Console.WriteLine(ex.Message + "Please select a valid option \n");
                }

                switch (selectedChoice)
                {
                    case "1":
                        MusicPlayer.ShowSongs();
                        break;
                    case "2":
                        MusicPlayer.AddSong();
                        break;
                    case "3":
                        MusicPlayer.EditSong();
                        break;
                    case "4":
                        MusicPlayer.RemoveSong();
                        break;
                    case "5":
                        PlayList.DisplayPlaylist();
                        break;
                    case "6":
                        PlayList.createPlaylist();
                        break;
                    case "7":
                        Console.WriteLine("Thank you, bye");
                        IsAlive = false;
                        Thread.Sleep(2000);
                       Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select valid option");
                        break;
                }


            }




        }

    }


}
