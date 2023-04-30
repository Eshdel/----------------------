SimpleStateMachineStringParser.Start();

public static class SimpleStateMachineStringParser {
    private const string START_MESSAGE = "Enter string";
    private const string ERROR_MESSAGE = "Error";
    
    private static string? _inputString;
    private static uint _indexSymbolInInputString = 0;

    private static char? NextSymbol() {
        try {
            return GetSymbolAtIndex(_indexSymbolInInputString++);
        } 

        catch(Exception e){
            return null;
        }
    }

    private static char? nextSymbol => NextSymbol();

    public static void Start() {
        Console.WriteLine(START_MESSAGE);
        _inputString = Console.ReadLine();

        if(State0(nextSymbol)) {
            Console.WriteLine("true");
        }
        else {
            Console.WriteLine("false");
        }
    }

    private static bool State0(char? symbol) {
        switch(symbol) {
            case '0':
                return State1(nextSymbol);
            default: 
                return false;
        }
    }

    private static bool State1(char? symbol) { 
        switch(symbol) {
            case '1':
                return State2(nextSymbol);

            default: 
                return false;
        }
    }

    private static bool State2(char? symbol) { 
        switch(symbol) {
            case '1':
                return State4(nextSymbol);
            case '2':
                return State3(nextSymbol);
            case '3':
                return State5(nextSymbol);

            default: 
               return false;
        }
    }

    private static bool State3(char? symbol) { 
        if(nextSymbol == null)
            return true;

        return false;
    }

    private static bool State4(char? symbol) { 
        switch(symbol) {
            case '2':
                return State6(nextSymbol);

            default: 
               return false;
        }
    }
    
    private static bool State5(char? symbol) { 
        switch(symbol) {
            case null: 
                return true;
            case '2':
                return State5(nextSymbol);

            default: 
               return false;
        }
    }
    
    private static bool State6(char? symbol) { 
        switch(symbol) {
            case '1': 
                return State4(nextSymbol);
            case '3':
                return State5(nextSymbol);

            default: 
               return false;
        }
    }

    private static char GetSymbolAtIndex(uint index) {
        return _inputString[(int) index];
    }
}