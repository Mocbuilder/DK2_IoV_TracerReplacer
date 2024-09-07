namespace DK2_IOV_TracerReplacer
{
    internal class Program
    {
        public static string modFolderPath = "";
        public static List<string> riflePaths = new List<string>();
        public static List<string> pistolPaths = new List<string>();
        public static string stringDecision = "";
        public static int decision = 0;

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
            SetPaths();

            do
            {
                Console.WriteLine("\nEnter the path to your mods folder:");
                modFolderPath = Console.ReadLine();
                Console.WriteLine("Do you want to (1) fix rifles and pistols (2) only rifles (3) only pistols or (4) exit");
                stringDecision = Console.ReadLine();
            
            }while (modFolderPath == null || modFolderPath == "" && stringDecision == null || stringDecision == "");

            decision = Convert.ToInt32(stringDecision);
            if(decision < 1 || decision > 4)
            {
                Console.WriteLine("An Error occured. Invalid decision. Please restart.");
                Environment.Exit(0);
            }

            switch (decision) {
                case 1:
                    ReplaceXmlRifles(modFolderPath);
                    ReplaceXmlPistols(modFolderPath);
                    break;
                case 2:
                    ReplaceXmlRifles(modFolderPath);
                    break;
                case 3:
                    ReplaceXmlPistols(modFolderPath);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("An Error occured. Please restart the application.");
                    break;
            }

            Console.ReadLine();
        }

        public static void Prep()
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(logo);
            Console.WriteLine("BY MOCBUILDER \nRun as administrator if you run into problems \nNot affiliated with DK2 or IOV Teams");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void SetPaths()
        {
            //Rifles
            riflePaths.Add("IoV_!base\\equipment\\firearms_rifles_iov.xml");
            riflePaths.Add("IoV_AIM\\equipment\\firearms_rifles_aim.xml");
            riflePaths.Add("IoV_CHN\\equipment\\firearms_rifles_chn.xml");
            riflePaths.Add("IoV_Delta\\equipment\\firearms_rifles_delta.xml");
            riflePaths.Add("IoV_GunslingerGirl\\equipment\\firearms_rifles_gsg.xml");
            riflePaths.Add("IoV_Russian\\equipment\\firearms_rifles_OMON.xml");
            riflePaths.Add("IoV_Russian\\equipment\\firearms_rifles_ALFA.xml");
            riflePaths.Add("IoV_SEALs\\equipment\\firearms_rifles_NamSeals.xml");
            riflePaths.Add("IoV_SEALs\\equipment\\firearms_rifles_VBSS.xml");
            riflePaths.Add("IoV_SPETsNAZ\\equipment\\firearms_rifles_SPNZ.xml");

            //Pistols
            pistolPaths.Add("IoV_!base\\equipment\\firearms_pistols_iov.xml");
            pistolPaths.Add("IoV_AIM\\equipment\\firearms_pistols_aim.xml");
            pistolPaths.Add("IoV_CHN\\equipment\\firearms_pistols_chn.xml");
            pistolPaths.Add("IoV_Delta\\equipment\\firearms_pistols_delta.xml");
            pistolPaths.Add("IoV_GunslingerGirl\\equipment\\firearms_pistols_gsg.xml");
            pistolPaths.Add("IoV_Russian\\equipment\\firearms_pistols_OMON.xml");
            pistolPaths.Add("IoV_Russian\\equipment\\firearms_pistols_ALFA.xml");
            pistolPaths.Add("IoV_SEALs\\equipment\\firearms_pistols_NamSeals.xml");
            pistolPaths.Add("IoV_SEALs\\equipment\\firearms_pistols_VBSS.xml");
            pistolPaths.Add("IoV_SPETsNAZ\\equipment\\firearms_pistols_SPNZ.xml");

        }

        public static void ReplaceXmlRifles(string modDirectory)
        {
            foreach (string file in riflePaths)
            {
                string fullPath = Path.Combine(modDirectory, file);
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
            
            Console.WriteLine("Finished bugfixing Tracer_Rifles_Gr_IoV");
            if(decision != 1)
            {
                Console.WriteLine("Thanks for using my software. Press any key to exit...");
            }
        }

        public static void ReplaceXmlPistols(string modDirectory)
        {
            foreach (string file in pistolPaths)
            {
                string fullPath = Path.Combine(modDirectory, file);
                if (Path.Exists(fullPath))
                {
                    Console.WriteLine(fullPath + " found. Template Name replaced.");
                    string xmlContent = File.ReadAllText(fullPath);

                    string oldString = "Tracer_Pistol_Gr_IoV";
                    string newString = "Tracer_Pistol";

                    string modifiedXmlContent = xmlContent.Replace(oldString, newString);

                    File.WriteAllText(fullPath, modifiedXmlContent);
                }

            }

            Console.WriteLine("Thanks for using my software. Press any key to exit...");

        }
    }
}
