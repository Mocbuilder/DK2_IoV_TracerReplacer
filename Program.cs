namespace DK2_IOV_TracerReplacer
{
    internal class Program
    {
        public static string modFolderPath = "";
        public static List<string> iovFolders = new List<string>();
        public static string logo = @"
  _____  _  _____    _____  __      __  _______                        ____              ______ _               
 |  __ \| |/ /__ \  |_   _| \ \    / / |__   __|                      |  _ \            |  ____(_)              
 | |  | | ' /   ) |   | |  __\ \  / /     | |_ __ __ _  ___ ___ _ __  | |_) |_   _  __ _| |__   ___  _____ _ __ 
 | |  | |  <   / /    | | / _ \ \/ /      | | '__/ _` |/ __/ _ \ '__| |  _ <| | | |/ _` |  __| | \ \/ / _ \ '__|
 | |__| | . \ / /_   _| || (_) \  /       | | | | (_| | (_|  __/ |    | |_) | |_| | (_| | |    | |>  <  __/ |   
 |_____/|_|\_\____| |_____\___/ \/        |_|_|  \__,_|\___\___|_|    |____/ \__,_|\__, |_|    |_/_/\_\___|_|   
                                                                                    __/ |                       
                                                                                   |___/                        
        ";


        static void Main(string[] args)
        {
            Prep();

            do
            {
                Console.WriteLine("\nEnter the path to your mods folder:");
                modFolderPath = Console.ReadLine();
            
            }while (modFolderPath == null || modFolderPath == "");

            CheckFiles(modFolderPath);
            Console.ReadLine();
        }

        public static void Prep()
        {
            iovFolders.Add("IoV_!base\\equipment\\firearms_rifles_iov.xml");
            iovFolders.Add("IoV_AIM\\equipment\\firearms_rifles_aim.xml");
            iovFolders.Add("IoV_CHN\\equipment\\firearms_rifles_chn.xml");
            iovFolders.Add("IoV_Delta\\equipment\\firearms_rifles_delta.xml");
            iovFolders.Add("IoV_GunslingerGirl\\equipment\\firearms_rifles_gsg.xml");
            iovFolders.Add("IoV_Russian\\equipment\\firearms_rifles_OMON.xml");
            iovFolders.Add("IoV_Russian\\equipment\\firearms_rifles_ALFA.xml");
            iovFolders.Add("IoV_SEALs\\equipment\\firearms_rifles_NamSeals.xml");
            iovFolders.Add("IoV_SEALs\\equipment\\firearms_rifles_VBSS.xml");
            iovFolders.Add("IoV_SPETsNAZ\\equipment\\firearms_rifles_SPNZ.xml");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(logo);
            Console.WriteLine("BY MOCBUILDER \nRun as administrator if you run into problems \nNot affiliated with DK2 or IOV Teams");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void CheckFiles(string modDirectory)
        {
            foreach (string folder in iovFolders)
            {
                string fullPath = Path.Combine(modDirectory, folder);
                if (Path.Exists(fullPath))
                {
                    Console.WriteLine(fullPath + " found. Template Name replaced.");
                    string xmlContent = File.ReadAllText(fullPath);

                    string oldString = "Tracer_Rifle_Gr_IoV";  
                    string newString = "Tracer_Rifle";  

                    string modifiedXmlContent = xmlContent.Replace(oldString, newString);

                    File.WriteAllText(fullPath, modifiedXmlContent);
                }
                
            }
            
            Console.WriteLine("Finished bugfixing. \n Thanks for using my software. Press any key to exit...");
        }
    }
}
