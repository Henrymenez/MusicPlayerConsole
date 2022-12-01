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
            //  Songs();
            foreach (Song song in songs)
            {
                Console.WriteLine(song.ID + " " + song.Name);
            }

        }
        public static void AddSong(string name, string artistName)
        {
            int newId = songs.Last().ID + 1;
            songs.Add(new Song(newId, name, artistName));
            Console.WriteLine("Your Song Have been added successfully");
        }
        public static void RemoveSong(int id)
        {
            var itemToRemove = songs.FirstOrDefault(item => item.ID == id);
            songs.Remove(itemToRemove);
            Console.WriteLine("Your Song Have been removed successfully");
        }

        public static void EditSong(int id, string name, string artistName)
        {
            var itemToEdit = songs.FirstOrDefault(item => item.ID == id);
            itemToEdit.ArtistName = artistName;
            itemToEdit.Name = name;
            Console.WriteLine("Your Song Have been removed successfully");

        }



    }

    public class PlayList
    {
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
            foreach (KeyValuePair<string, List<Song>> song in myPlayLists)
            {
                Console.WriteLine(song.Key);
            }
            Console.WriteLine("------------------ \n");
        }

        public static List<Song> createSongsList()
        {
            int count = 0;
            List<Song> playlistSongs = new List<Song>();
            while (true)
            {
                Console.WriteLine("Song Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Artist Name: ");
                string artistName = Console.ReadLine();
                count += 1;
                playlistSongs.Add(new Song(count, name, artistName));
                Console.WriteLine("Do you want to continue? y/n");
                string continueLoop = Console.ReadLine();
                if (continueLoop.ToLower() == "n")
                {
                    break;
                }

            }
            return playlistSongs;

        }

        public static void createPlaylist()
        {
            Console.WriteLine("Playlist name: ");
            string playlistName = Console.ReadLine();
            myPlayLists.Add(playlistName, createSongsList());
            DisplayPlaylist();
        }



    }


}
