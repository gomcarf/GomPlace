using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    public enum WeaponType
    {
        Sword, Axe, Hammer, Bow, Staff, Dagger, Max, //인덱스 0번부터 순서대로(약간 배열 느낌) Max=6
    }

    public struct WeaponData
    {
        public WeaponType Type { get; set; }
        public float Power { get; set; }
        public float Speed { get; set; }
        public int Price { get; set; }
    }
    private static void Main(string[] args)
    {
        string path = Environment.CurrentDirectory;
        path += "\\..\\..\\..\\";
        path = Path.GetDirectoryName(path)!;

        WriteBinaryFile(path);
        ReadBinaryFile(path);

        WriteSerializeFile(path);
        ReadSerializedFile(path);
    }//Main

    private static void WriteBinaryFile(string path)
    {
        WeaponData data = new WeaponData()
        {
            Type = WeaponType.Sword,
            Power = 10.5f,
            Speed = 1.2f,
            Price = 50,
        };

        string filePath = Path.Combine(path, "weaponData.bin");//보통 바이너리 파일은 .bin을 쓰지만 때에 따라 다르게 쓰기도 함. .data나

        FileMode fileMode = FileMode.CreateNew; //기본 파일 모드는 무조건 새로 생성하는 CreateNew로 설정
        if (File.Exists(filePath)) //filePath에 파일이 존재하는지 여부 반환
            fileMode = FileMode.Create; //존재하면 파일 모드를 Create로 변경(안그럼 예외생겼다고 에러남)

        FileStream fileStream = new FileStream(filePath, fileMode);
        {
            BinaryWriter writer = new BinaryWriter(fileStream);
            {
                writer.Write((int)data.Type); //type은 열거형으로 만들어준 변수이기 때문에 Write함수가 알아먹지 못함. 그러니 int형으로 형변환해서 매개변수에 집어넣어줌
                writer.Write(data.Power);
                writer.Write(data.Speed);
                writer.Write(data.Price);
            }
            writer.Close(); //얘도 열었으면 닫아야 함.
        }
        fileStream.Close(); //stream은 열게되면 반드시 닫아줘야함.
    }

    private static void ReadBinaryFile(string path)
    {
        string filePath = Path.Combine(path, "weaponData.bin"); //보통 바이너리 파일은 .bin을 쓰지만 때에 따라 다르게 쓰기도 함. .data나
        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        {
            BinaryReader reader = new BinaryReader(fileStream);
            {
                string str = "";
                str += "Type  : " + (WeaponType)reader.ReadInt32() + "\n"; //generic에서 int로 변환해서 저장했으니 읽을때는 다시 WeaponType으로 변환해서 읽기
                str += "Power : " + reader.ReadSingle() + "\n";
                str += "Speed : " + reader.ReadSingle() + "\n";
                str += "Price : " + reader.ReadInt32() + "\n";

                Console.WriteLine(str);
            }
            reader.Close(); //얘도 열었으면 닫아야 함.
        }
        fileStream.Close(); //stream은 열게되면 반드시 닫아줘야함.
    }

    private static void WriteSerializeFile(string path)
    {
        List<WeaponData> dataList = new List<WeaponData>();

        Random random = new Random();
        int count = random.Next(5, 10);
        for (int i = 0; i < count; i++)
        {
            WeaponData data = new WeaponData()
            {
                Type = (WeaponType)random.Next(0, (int)WeaponType.Max),
                Power = (float)(random.NextDouble() * 20.0),
                Speed = (float)(random.NextDouble() * 10.0),
                Price = random.Next(10, 60),
            };

            dataList.Add(data);
        }
        WeaponData[] datas = dataList.ToArray(); //리스트를 배열로 변환 (**리스트는 직렬화 불가, 반드시 배열로 변환해서 직렬화 해야함**)


        string filePath = Path.Combine(path, "weaponData2.bin");

        FileMode fileMode = FileMode.CreateNew;
        if (File.Exists(filePath))
            fileMode = FileMode.Create;

        FileStream fileStream = new FileStream(filePath, fileMode);
        {
            BinaryWriter writer = new BinaryWriter(fileStream);
            {
                writer.Write(datas.Length); //불러오는 데이터가 몇개인지 써줌

                //Marshal : 구조체나 클래스를 직렬화하기 위해 일정한 규칙으로 바꾸는 것
                Span<byte> bytes = MemoryMarshal.AsBytes<WeaponData>(datas); //Span: 바이트 배열을 관리하는 클래스
                writer.Write(bytes);
            }
            writer.Close();
        }
        fileStream.Close();
    }

    private static void ReadSerializedFile(string path)
    {
        string str = "";

        string filePath = Path.Combine(path, "weaponData2.bin");
        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        {
            BinaryReader reader = new BinaryReader(fileStream);
            {
                int count = reader.ReadInt32(); //배열의 길이부터 읽기
                int size = Marshal.SizeOf<WeaponData>(); //구조체의 크기

                int totalSize = count * size; //전체 크기(바이트)
                byte[] bytes = reader.ReadBytes(totalSize);

                Span<byte> span = bytes;
                Span<WeaponData> dataSpan = MemoryMarshal.Cast<byte, WeaponData>(span); //바이트를 WeaponData 타입으로 변환

                WeaponData[] datas = dataSpan.ToArray();

                foreach(WeaponData data in datas)
                {
                    str += "Type  : " + data.Type + "\n";
                    str += "Power : " + data.Power + "\n";
                    str += "Speed : " + data.Speed + "\n";
                    str += "Price : " + data.Price + "\n";
                    str += "\n";
                }
            }
            reader.Close();
        }
        fileStream.Close();

        Console.WriteLine(str);
    }
}