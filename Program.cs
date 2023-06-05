namespace building_planner;

class Building
{
    private string _name;
    private int _floors;
    private double _height;
    
    public Building(string name, int floors, double height){
        _name = name;
        _floors = floors;
        _height = height;
    }

    public Building(string name,int floors){
        _name = name;
        _floors = floors;
        _height = 3 * floors;
    }

    public double GetFloorMaxSize(){
        return (_height / _floors);
    }

    public string GetName(){
        return _name;
    }

    public int GetFloorCount(){
        return _floors;
    }

    public double GetSize(){
        return _height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string input;
        Building[] myBuildings = new Building[10];
        int nbBuildings = 0;
        string navigation = "main menu";
        
        Console.WriteLine("Outil de modélisation de batiment");

        while(true){
            Console.WriteLine("");
            switch(navigation){
                case "main menu":
                    navigation = MainMenu();
                    break;

                case "voir":
                    Display(myBuildings, nbBuildings);
                    navigation = "main menu";
                    break;

                case "creer":
                    myBuildings = Create(myBuildings, nbBuildings);
                    nbBuildings++;
                    navigation = "main menu";
                    break;

                case "fin":
                return;
                // break;
            }
        }
    }

    static string MainMenu(){

        Console.WriteLine("voir --> visualiser les batiments modelisés");
        Console.WriteLine("creer --> modeliser un nouveau batiment");
        Console.WriteLine("fin --> fermer le programme");
        string input = Console.ReadLine();

        if(input == "voir" || input == "creer" || input == "fin"){
            return input;
        } else {
            Console.WriteLine("Erreur : Saisie non reconnue");
            return "main menu";
        }

    }
    

    static Building[] Create(Building[] myBuildings, int nbBuildings){

        if(nbBuildings < myBuildings.Length){

            Console.Write("Comment doit s'appeler le batiment ? ");
            string inputName = Console.ReadLine();
            Console.Write("Combien d'étages doit avoir le batiment ? ");
            string input = Console.ReadLine();

            if(Int32.Parse(input) > 0){

                Console.Write("Quelle hauteur totale doit faire le batiment ? (x --> skip) ");
                string inputHeight = Console.ReadLine();

                if(inputHeight == "x"){
                    myBuildings[nbBuildings] = new Building(inputName, Int32.Parse(input));
                } else if(Double.Parse(inputHeight) > 0){
                    myBuildings[nbBuildings] = new Building(inputName, Int32.Parse(input), Double.Parse(inputHeight));
                }
                

            } else {
                Console.WriteLine("Erreur : Saisie non reconnue");
            }
            
        }
        else {
            Console.Write("Erreur : Memoire pleine");
        }

        return myBuildings;

    }


    static void Display(Building[] myBuildings, int nbBuildings){

        Console.WriteLine("Liste des batiments :");

        for(int i = 0; i < nbBuildings; i++){
            Console.WriteLine( i+1 + " - " + myBuildings[i].GetName() );
        }


        while(true){

            Console.WriteLine("");
            Console.Write("Entrez le numero du batiment que vous voulez examiner (x --> retour)");
            string input = Console.ReadLine();
            
            if(input == "x"){
                break;
            }
            else if(Int32.Parse(input) > 0){
                for(int i = 0; i < nbBuildings; i++){
                    Console.WriteLine(myBuildings[i].GetName());
                    Console.WriteLine("nb etages : " + myBuildings[i].GetFloorCount());
                    Console.WriteLine("hauteur totale : " + myBuildings[i].GetSize());
                    Console.WriteLine("hauteur par etage : " + myBuildings[i].GetFloorMaxSize());
                }
            }

        }

    }
}
