namespace MusicPlayerConsole
{
    public class Song
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }

        public Song(int id, string name, string artistName)
        {
            ID = id;
            Name = name;
            ArtistName = artistName;
        }
    }


}
