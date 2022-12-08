using System;
using System.Collections.Generic;

namespace MusicPlayerConsole
{
    public class MusicPlayer
    {

        public static List<Song> songs { get; set; } = new List<Song>() {
             new Song(1, "Lust for life", "Lana del rey"),
             new Song(2, "Truth Hurts", "Lizzo"),
             new Song(3, "Without You", "Harry Nilsson"),
             new Song(4, "You’re So Vain", "Carly Simon"),
             new Song(5, "Where Is My Mind?", "The Pixies")
        };

        public static void ShowSongs()
        {
            int count = 0;
            Console.Clear();
            foreach (Song song in songs)
            {
                count += 1;
                Console.WriteLine($"{count} {song.Name} by {song.ArtistName}");
            }
            Console.WriteLine("----------------------- \n");
            Console.WriteLine("1: Play song  \n 0. Main Menu");
            string? playChoice = Console.ReadLine();
            bool IsAlive = true;
            while (IsAlive)
            {
                switch (playChoice)
                {
                    case "0":
                        Console.Clear();
                        IsAlive = false;
                        Application.Start();
                        break;
                    case "1":
                        PlaySong();
                        break;
                    default:
                        Console.WriteLine("Please select valid option \n");
                        Console.WriteLine("Play song: \n 1. In exact order \n 2. Alphabetical order \n 3. Shuffle \n 0. Main Menu");
                        playChoice = Console.ReadLine();
                        break;
                }
            }
        }
        public static void AddSong()
        {
            try
            {
                bool IsAlive = true;

                while (IsAlive)
                {
                    Console.Write("Song Name: ");
                    string? name = Console.ReadLine();
                    Console.Write("Artist Name: ");
                    string? artistName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(artistName))
                    {
                        throw new InvalidInput("Invalid Input");
                    }
                    int newId = songs.Last().ID + 1;
                    songs.Add(new Song(newId, name, artistName));
                    Console.WriteLine("Your Song Have been added successfully ");
                    Console.WriteLine("----------------------- \n");
                    IsAlive = false;
                }


            }
            catch (InvalidInput ex)
            {
                Console.WriteLine(ex.Message + "Please select valid imput");
            }


        }
        public static void RemoveSong()
        {
            Console.Clear();
            Console.Write("Song Id you want to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var itemToRemove = songs.FirstOrDefault(item => item.ID == id);
            if (itemToRemove != null)
            {
                songs.Remove(itemToRemove);
                Console.WriteLine("Your Song Have been removed successfully");
                Console.WriteLine("----------------------- \n");
            }
            Console.WriteLine("Invalid Id");
        }

        public static void EditSong()
        {
            try
            {
                Console.Clear();
                Console.Write("Song Id you want to Edit: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("New Song Name: ");
                string? name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new InvalidInput("Please Insert a valid input");

                }
                Console.Write("New Artist Name: ");
                string? artistName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(artistName))
                {
                    throw new InvalidInput("Please Insert a valid input");

                }

                var itemToEdit = songs.FirstOrDefault(item => item.ID == id);
                if (itemToEdit != null)
                {
                    itemToEdit.ArtistName = artistName;
                    itemToEdit.Name = name;
                    Console.WriteLine("Your Song Have been edited successfully");
                    Console.WriteLine("----------------------- \n");
                }
                throw new InvalidInput("Invalid Id");
            }
            catch (InvalidInput ex)
            {
                Console.WriteLine(ex.Message + " Please Insert a valid input");
            }
        }

        public static void PlaySong()
        {
            Console.WriteLine("\n \n1: Play in exact order:\n" +
                          "2:  Alphabetical order \n" +
                          "3: Shuffle \n" +
                          "0: To Return to Main Menu");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    Console.Clear();
                    Application.Start();
                    break;
                case "1":
                    PlaySongsInCorrectOrder();
                    break;
                case "2":
                    ShuffleSongs();
                    break;
                default:
                    PlaySongsInCorrectOrder();
                    break;
            }

        }

        public static void PlaySongsInCorrectOrder()
        {
            int index = 0;
            try
            {
                List<string> playMusic = new List<string>();
                while (true)
                {
                    foreach (Song song in songs)
                    {
                        playMusic.Add($"Now Playing {song.Name} by {song.ArtistName}");
                    }

                    if (index >= 0 && index < playMusic.Count())
                    {
                        Console.WriteLine(playMusic[index]);
                        Console.WriteLine("\n \nEnter No:\n" +
                     "1:  Next \n" +
                     "2: Previous \n" +
                     "0: To Return to Main Menu");
                        string? input = Console.ReadLine();

                        switch (input)
                        {
                            case "0":
                                Console.Clear();
                                Application.Start();
                                break;
                            case "1":
                                Console.Clear();
                                playMusic[index] = playMusic[index++];
                                break;
                            case "2":
                                Console.Clear();
                                playMusic[index] = playMusic[index--];
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Out of range");
                        PlaySongsInCorrectOrder();
                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static void ShuffleSongs()
        {
            int index = 0;
            var rnd = new Random();
            List<string> playMusic = new List<string>();
            while (true)
            {
                foreach (Song song in songs)
                {
                    playMusic.Add($"Now Playing {song.Name} by {song.ArtistName}");
                }
                var i = playMusic.Count();
                string val = default(string);
                while (i >= 1)
                {
                    i--;
                    var nextIndex = rnd.Next(i, playMusic.Count());
                    val = playMusic[nextIndex];
                    //start swapping values
                    playMusic[nextIndex] = playMusic[i];
                    playMusic[i] = val;
                }
                Console.WriteLine(playMusic[index]);
                Console.WriteLine("\n \nEnter No:\n" +
                   "1:  Next \n" +
                   "2: Previous \n" +
                   "0: To Return to Main Menu");
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.Clear();
                        Application.Start();
                        break;
                    case "1":
                        Console.Clear();
                        playMusic[index] = playMusic[index++];
                        break;
                    case "2":
                        Console.Clear();
                        playMusic[index] = playMusic[index--];
                        break;
                }
            }
                
           
        }

    }


}
