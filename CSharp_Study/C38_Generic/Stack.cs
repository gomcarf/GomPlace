
using System.Diagnostics;

class Stack<DataType>
{
    private DataType[] datas; //카멜 표기법
    private int top = -1;
    
    public const int DefaultSize = 5;
    public readonly int MaxSize;

    public Stack(int maxSize = DefaultSize)
    {
        MaxSize = maxSize;
        datas = new DataType[MaxSize];
    }

    public void Push(DataType data)
    {
        if (IsFull())
        {
            Console.WriteLine("스택이 꽉 참");

            return;
        }

        datas[++top] = data;
    }

    public DataType Pop()
    {
        if (IsEmpty())
        {
            //Console.WriteLine("스택이 비워져 있음.");
            //return default(DataType)!; //default는 초기값 반환

            Debug.Assert(false, "스택이 비워져 있음.");
        }

        return datas[top--];
    }

    public bool IsFull()
    {
        return top >= MaxSize - 1;
    }

    public bool IsEmpty()
    {
        return top < 0;
    }
}
