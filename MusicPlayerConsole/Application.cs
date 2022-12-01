﻿namespace MusicPlayerConsole
{
    public class Application
    {
        public void Start()
        {
            MusicPlayer.SongsDb();
            Console.Title = "My Music Player";
            Console.WriteLine("*****Welcome to my Music Player App*****");
            Console.WriteLine("What would you like to do ");
            Console.WriteLine("1. Add, Remove Or Edit Song");
            Console.WriteLine("2. Create A playlist ");
            string selectedChoice = Console.ReadLine();

            if (selectedChoice == "1")
            {
                Console.WriteLine("List of  avalible songs");
                Console.WriteLine("------------------------");
                MusicPlayer.ShowSongs();
                Console.WriteLine("------------------------");
                Console.WriteLine("1. To add new song");
                Console.WriteLine("2. Remove Song");
                Console.WriteLine("3. Edit Song");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Clear();
                    Console.Write("Song Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Artist Name: ");
                    string artistName = Console.ReadLine();
                    MusicPlayer.AddSong(name, artistName);
                    Console.WriteLine("-----------------------");
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Console.Write("Song Id you want to remove: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    MusicPlayer.RemoveSong(id);
                    Console.WriteLine("-----------------------");

                }else if(choice == "3") { 
                
                ''}
            }




        }

    }


}