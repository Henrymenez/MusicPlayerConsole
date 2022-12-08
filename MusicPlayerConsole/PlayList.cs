using System.Security;

namespace MusicPlayerConsole
{
    public class PlayList
    {
        public static List<string> playlistindex = new List<string>();
        public static List<Song> playlistSongs { get; set; } = new List<Song>() {
            new Song(1, "Lust for life", "Lana del rey"),
             new Song(2, "Truth Hurts", "Lizzo"),
             new Song(3, "Without You", "Harry Nilsson")
        };

        public static Dictionary<string, List<Song>> myPlayLists { get; set; } = new()
        {
            {"Dope", playlistSongs},
        };


        public static void DisplayPlaylist()
        {
            try
            {
                Console.Clear();
                int count = 0;
                foreach (KeyValuePair<string, List<Song>> song in myPlayLists)
                {
                    count += 1;
                    Console.WriteLine(count + ". " + song.Key);
                    playlistindex.Add(song.Key);
                }
                Console.WriteLine("------------------ \n");
                Console.Write("Display song in playlist, Enter Playlist Id: ");
                int index = int.Parse(Console.ReadLine());
                DisplaySongInPlaylist(index);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public static void DisplaySongInPlaylist(int index)
        {
            try
            {
                int count = 0;
                string currentPlaylist = playlistindex[index - 1];
               
                foreach (var item in myPlayLists[currentPlaylist])
                {
                    count += 1;
                    Console.WriteLine($"{count}. {item.Name} by {item.ArtistName}");
                }
                Console.WriteLine("------------------ \n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static List<Song> createSongsList()
        {

            int count = 0;
            List<Song> playlistSongs = new List<Song>();
            try
            {
                while (true)
                {

                    Console.WriteLine("Song Name: ");
                    string? name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.Clear();
                        Console.WriteLine("Option can not be empty \n");
                        Console.WriteLine("Song Name: ");
                         name = Console.ReadLine();
                    }

                    Console.WriteLine("Artist Name: ");
                    string? artistName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(artistName))
                    {
                        Console.Clear();
                        Console.WriteLine("Option can not be empty \n");
                        Console.WriteLine("Artist Name: ");
                        artistName = Console.ReadLine();
                    }
                    count += 1;
                    playlistSongs.Add(new Song(count, name, artistName));
                    Console.WriteLine("Do you want to continue? y/n");
                    string? continueLoop = Console.ReadLine();
                    if (continueLoop.ToLower() == "n")
                    {
                        break;
                    }

                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return playlistSongs;




        }

        public static void createPlaylist()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Playlist name: ");
                string playlistName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(playlistName))
                {
                    throw new InvalidInput("Invalid input");
                }
                myPlayLists.Add(playlistName, createSongsList());
                DisplayPlaylist();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("---------------------- \n");

        }



    }


}
