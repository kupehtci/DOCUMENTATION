using System; 


//This class allow the buffer 
public class Buffer
{
    public int[] buff;
    public int capacity; 
    public int count;
    public int inputPosition;
    public int outPosition; 

    public Buffer()
    {
        this.buff = new int[10];

        // Initializate the array with 0´s
        for(int i = 0; i < buff.Length; i++)
        {
            buff[i] = 0; 
        }

        // Initialize buffer values
        this.capacity = 10;
        this.count = 0;
        this.inputPosition = 0;
        this.outPosition = -1;
    }

    public bool Insert(int newValue)
    {
        if (inputPosition >= capacity) return false;

        buff[inputPosition] = newValue;
        inputPosition++;
        outPosition++;
        count++; 
        return true; 
    }

    public int? Pop()
    {
        if (outPosition <= -1) return null;

        Console.WriteLine("Poping from position " + outPosition);
        int? popValue = buff[outPosition];
        outPosition--;
        inputPosition--;
        count--; 
        return popValue; 
    }

    public bool IsFull()
    {
        return (inputPosition >= capacity); 
    }

    public void PromptBuffer(){
    	string resultantString = ""; 
    	int i = 0; 

    	foreach(int value in buff){
			resultantString += ("buff[" + i + "] " + value); 
			i++; 
    	}

    	Console.WriteLine("Buffer: " + resultantString);
    }
}

internal class Program{

	static void Main(string args){

	}
}