using System.Xml.Linq;

namespace MusicPlayerConsole
{
    public class MusicPlayer
    {

        public static List<Song> songs { get; set; }
        public static void SongsDb()
        {
            songs = new List<Song>() { 
             new Song(1, "Lust for life", "Lana del rey"),
             new Song(2, "Truth Hurts", "Lizzo"),
             new Song(3, "Without You", "Harry Nilsson"),
             new Song(4, "You’re So Vain", "Carly Simon"),
             new Song(5, "Where Is My Mind?", "The Pixies")
        };



        }

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
            ShowSongs();

        }
        public static void RemoveSong(int id)
        {
            var itemToRemove = songs.FirstOrDefault(item => item.ID == id);
            songs.Remove(itemToRemove);
            Console.WriteLine("Your Song Have been removed successfully");
            ShowSongs();
        }

        public static void EditSong(int id,string name, string artistName)
        {
            var itemToEdit = songs.FirstOrDefault(item => item.ID == id);
            itemToEdit.ArtistName = artistName;
            itemToEdit.Name = name;
            Console.WriteLine("Your Song Have been removed successfully");
            ShowSongs();
        }



    }


}
