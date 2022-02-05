using MXPSQL.TextPager;

// See https://aka.ms/new-console-template for more information


if(args.Length > 0){
    String file = args[0];
    String text = "";
    int maxdispline = 10;

    for(int i = 0; i < args.Length; i++){
        if(args[i] == "-h" || args[i] == "--help"){
            Console.WriteLine("textpg, MXPSQL.TextPager implemented as an application.");
            Console.WriteLine("Usage: textpg.exe <file> [maxdispline] [-h|--help]");
            Console.WriteLine("\tfile: File to display.");
            Console.WriteLine("\tmaxdispline: Max number of lines to display. (optional)");
            Console.WriteLine("\t-h, --help: Prints this help message. (optional if you need to know it again)");
            Environment.Exit(0);
        }
    }

    if(args.Length > 1){
        bool status = int.TryParse(args[1], out maxdispline);
        if(!status){
            maxdispline = 10;
        }
    }

    if(File.Exists(file)){
        text = File.ReadAllText(file);
    }
    else{
        Console.WriteLine("File does not exist!");
        Environment.Exit(1);
    }


    TextPager.pager(text, maxdispline);
}
else{
    Console.WriteLine("No arguments provided!");
    Environment.Exit(1);
}