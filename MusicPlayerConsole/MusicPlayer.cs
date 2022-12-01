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

        }
        public static void AddSong()
        {
            Console.Clear();
            Console.Write("Song Name: ");
            string name = Console.ReadLine();
            Console.Write("Artist Name: ");
            string artistName = Console.ReadLine();

            int newId = songs.Last().ID + 1;
            songs.Add(new Song(newId, name, artistName));
            Console.WriteLine("Your Song Have been added successfully ");
            Console.WriteLine("----------------------- \n");
        }
        public static void RemoveSong()
        {
            Console.Clear();
            Console.Write("Song Id you want to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var itemToRemove = songs.FirstOrDefault(item => item.ID == id);
            songs.Remove(itemToRemove);
            Console.WriteLine("Your Song Have been removed successfully");
            Console.WriteLine("----------------------- \n");
        }

        public static void EditSong()
        {
            Console.Clear();
            Console.Write("Song Id you want to Edit: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("New Song Name: ");
            string name = Console.ReadLine();
            Console.Write("New Artist Name: ");
            string artistName = Console.ReadLine();
            var itemToEdit = songs.FirstOrDefault(item => item.ID == id);
            itemToEdit.ArtistName = artistName;
            itemToEdit.Name = name;
            Console.WriteLine("Your Song Have been removed successfully");
            Console.WriteLine("----------------------- \n");
        }



    }


}
