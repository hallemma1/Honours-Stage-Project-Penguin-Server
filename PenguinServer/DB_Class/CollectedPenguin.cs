namespace PenguinServer.DB_Class
{
    public class CollectedPenguinDataObject
    {
        public CollectedPenguin[]? DataObject { get; set; }
    }
    public class CollectedPenguin
    {
        public int penguin_id { get; set; }
        public string penguin_name { get; set; }
        public int collected_count { get; set; }
        public int score { get; set; }

        public CollectedPenguin(int id, string name, int count, int score)
        {
            penguin_id = id;
            penguin_name = name;
            collected_count = count;
            this.score = score;
        }
    }
}
