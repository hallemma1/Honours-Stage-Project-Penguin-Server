using PenguinServer.DB_Class;

namespace PenguinServer.Services
{
    public class CollectedPenguinsControllerService
    {
        public CollectedPenguinDataObject GetCollectedPenguinsData()
        {
            List<CollectedPenguin> collectedPenguins = new List<CollectedPenguin>();
            string filePath = "./CollectedPenguins.csv";
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                // Skip the header line
                foreach (string line in lines.Skip(1))
                {
                    string[] parts = line.Split(',');
                    int penguinId = int.Parse(parts[0]);
                    string penguinName = parts[1];
                    int collectedCount = int.Parse(parts[2]);
                    int score = int.Parse(parts[3]);

                    CollectedPenguin penguin = new CollectedPenguin(penguinId, penguinName, collectedCount, score);
                    collectedPenguins.Add(penguin);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Put into CollectedPenguinDataObject
            CollectedPenguinDataObject collectedPenguinDataObject = new CollectedPenguinDataObject();
            collectedPenguinDataObject.DataObject = collectedPenguins.ToArray();
            // Return Array
            return collectedPenguinDataObject;
        }

        public string UpdateCollectedPenguinData(string name, int score)
        {
            List<CollectedPenguin> collectedPenguins = new List<CollectedPenguin>();
            string filePath = "./CollectedPenguins.csv";
            
                string[] lines = File.ReadAllLines(filePath);

                // Skip the header line
                foreach (string line in lines.Skip(1))
                {
                    string[] parts = line.Split(',');
                    int penguinId = int.Parse(parts[0]);
                    string penguinName = parts[1];
                    int collectedCount = int.Parse(parts[2]);
                    int fileScore = int.Parse(parts[3]);

                    CollectedPenguin penguin = new CollectedPenguin(penguinId, penguinName, collectedCount, fileScore);
                    collectedPenguins.Add(penguin);
                }
                CollectedPenguin penguinToUpdate = collectedPenguins.Find(p => p.penguin_name == name);

            if (penguinToUpdate != null)
            {
                // Increment the collected count
                penguinToUpdate.collected_count++;

                //update score
                if(penguinToUpdate.score == 0 || penguinToUpdate.score < score) { penguinToUpdate.score = score; }
                
            }
            else
            {
                return($"Penguin with name '{name}' not found.");
            }

            string filePathUpdate = "./CollectedPenguins.csv";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write header line
                writer.WriteLine("penguin_id,penguin_name,collected_count");

                // Write data for each penguin
                foreach (CollectedPenguin penguin in collectedPenguins)
                {
                    writer.WriteLine($"{penguin.penguin_id},{penguin.penguin_name},{penguin.collected_count},{penguin.score}");
                }
            }

            return "Collected Penguins file updated with "+name+" and "+score;
        }
    }
}



