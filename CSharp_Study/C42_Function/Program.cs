class Program
{
    struct MinString
    {
        public float value;
        public float Compare;
        public string Text;

    }

    private static bool Print(params MinString[] minString) //params : 가변 파라미터
    {
        for(int i = 0; i< minString.Length; i++)
        {
            MinString item = minString[i];

            if(item.value < item.Compare)
            {
                Console.WriteLine(item.Text);
                return true;
            }
        }

        return false;
    }

    struct MaxString
    {
        public float value;
        public string Text;
    }

    private static void Main(string[] args)
    {
        MinString minString = new MinString()
        {
            value = 5.0f,
            Compare = 5.0f,
            Text = "입력한 값은 10 이상이어야 합니다"
        };

        MinString minString2 = new MinString()
        {
            value = 2.0f,
            Compare = 5.0f,
            Text = "입력한 값은 10 이상이어야 합니다"
        };

        while (true)
        {
            if (Print(minString, minString2) == false)
                break;
        }
    }
}