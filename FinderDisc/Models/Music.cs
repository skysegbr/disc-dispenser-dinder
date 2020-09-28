namespace FinderDisc.Models
{
    public class Music
    {
        public int MusicId { get; set; }
        public string MusicName { get; set; }
        public Band Band { get; set; }
        public int BandId { get; set; }
    }
}