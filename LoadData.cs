namespace FinanceProj
{
    public class LoadData
    {
        public static string GetOAuth(string file)
        {
            if (File.Exists(file))
            {
                // Reads file line by line 
                StreamReader Textfile = new StreamReader(file);
                string line;

                while ((line = Textfile.ReadLine()) != null)
                {
                    if (line.Contains("OAUTH = "))
                    {
                        int index = line.IndexOf("OAUTH = ");
                        string ouath = line.Substring(index + "OAUTH = ".Length);
                        return ouath;
                    }
                }

                Textfile.Close();
            }
            Console.WriteLine("Failed to find OAuth.");
            return "";
        }
    }
}
