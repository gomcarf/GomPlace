using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Text.Json;

class Program
{
    public struct WeaponData
    {
        public string Name;
        public int Number;

        public float Power;
        public float Speed;
        public float Durability;
    }
    
    public struct PlayerData
    {
        public string Name { get; set; }
        public float HP { get; set; }
        public bool Alive { get; set; }
        public int Level { get; set; }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine();

        string path = Environment.CurrentDirectory; //현재 작업 중인 디렉토리 가져오기
        path += "\\..\\..\\..\\"; //현재 작업 중인 디렉토리 상위 폴더로 이동
        path = Path.GetDirectoryName(path)!; //path에 있는 디렉토리의 네임을 path에 저장
        //Console.WriteLine(path); //디렉토리 이름 출력

        //TextFile
        {
            PrintFiles(path); //path에 있는 파일 이름 출력
            WriteTextFiles(path); //path에 텍스트 파일 생성

            Console.WriteLine("\n--- Baseball List.txt ---");
            ReadTextFile(path); //path에 위치한 텍스트 파일 읽기
        }

        List<WeaponData> datas = new List<WeaponData>(); //무기 정보 리스트 생성

        Random random = new Random(); //랜덤 함수 생성
        int count = random.Next(20, 30); //20~~30개 랜덤 난수 발생

        string[] weaponNames = new string[] //문자열 배열에 무기 이름 초기화
        {
            "Sword", "Bow", "Hammer", "Axe", "Spear", "Gun",
        };

        for (int i = 0; i < count; i++)
        {
            WeaponData data = new WeaponData();
            data.Name = weaponNames[random.Next(0, weaponNames.Length)];
            data.Number = i + 1;

            data.Power = GetNextSingle(random, 10.0f, 30.0f);
            data.Speed = GetNextSingle(random, 0.5f, 3.0f);
            data.Durability = GetNextSingle(random, 0.25f, 5.0f);

            datas.Add(data); //데이터 생성
        }

        //CSV 파일 저장
        WeaponData[] weaponDatas = datas.ToArray();
        Write_CSV_File(path, weaponDatas);
        PrintFiles(path);
        //CSV 파일 읽기
        Read_CSV_File(path);

        Console.WriteLine();
        Console.WriteLine();

        //player 데이터 생성
        PlayerData playerData = new PlayerData()
        {
            Name = "Player",
            HP = 100,
            Alive = true,
            Level = 99,
        };
        

        PlayerData playerData2 = new PlayerData() 
        {
            Name = "Sword Man",
            HP = 150,
            Alive = false,
            Level = 255,
        };
        

        //Json 파일 저장
        Write_Json_File(path, playerData);
        Write_Json_File2(path, playerData2);//직렬화
        PrintFiles(path);

        Read_Json_File(path, "PlayerData");
        Read_Json_File(path, "PlayerData2");
    }//Main

    private static float GetNextSingle(Random random, float min, float max) //랜덤 수치 반환
    {
        return (random.NextSingle() * (max - min)) + min;
    }

    private static void PrintFiles(string path) //파일 출력 함수
    {
        string[] files = Directory.GetFiles(path); //디렉토리 내의 파일들을 string 배열에 입력

        foreach (string file in files)
            Console.WriteLine(Path.GetFileName(file)); //파일명만 출력
    }

    private static void WriteTextFiles(string path) //path에 텍스트 파일 생성
    {
        string str = "";
        str += "엔씨다이노스\n";
        str += "한화이글스\n";
        str += "케이티위즈";


        string fileName = Path.Combine(path, "BaseballList.txt"); //파일 이름은 path랑 문자열이랑 합쳐서

        File.WriteAllText(fileName, str); //fileName으로 된 str을 입력한 txt 파일 생성
    }

    private static void ReadTextFile(string path) //path에 위치한 텍스트 파일 읽기 함수
    {
        string fileName = Path.Combine(path, "BaseballList.txt"); //읽을 파일 이름 저장

        string str = File.ReadAllText(fileName); //fileName을 읽어서 str에 저장
        Console.WriteLine(str);
    }

    private static void Write_CSV_File(string path, WeaponData[] datas)//콤마 , 로 구분되는 데이터 저장하기 좋은 csv
    {
        string str = "";
        foreach (WeaponData data in datas)
        {
            str += data.Name + ",";
            str += data.Number + ",";
            str += data.Power + ",";
            str += data.Speed + ",";
            str += data.Durability + "\n";

        }

        //Console.WriteLine("\n-- Weapon Datas -- ");
        //Console.WriteLine(str);

        string fileName = Path.Combine(path, "WeaponDatas.csv");
        File.WriteAllText(fileName, str);
    }
    private static void Read_CSV_File(string path) //path에 위치한 텍스트 파일 읽기 함수
    {
        string fileName = Path.Combine(path, "WeaponDatas.csv"); //읽을 파일 이름 저장

        //string str = File.ReadAllText(fileName); //fileName을 읽어서 str에 저장
        string[] lines = File.ReadAllLines(fileName); //전체 라인을 읽어오겠다


        Console.WriteLine();
        Console.WriteLine("\n-- WeaponList.csv --");
        

        foreach (string line in lines)
        {
            //Console.WriteLine(line);

            string[] members = line.Split(",");
            Console.WriteLine($" Name : {members[0]}");
            Console.WriteLine($" Number : {members[1]}");
            Console.WriteLine($" Power : {members[2]}");
            Console.WriteLine($" Speed : {members[3]}");
            Console.WriteLine($" Durability : {members[4]}");
            Console.WriteLine();
        }
        Console.WriteLine($"전체 무기 개수 : {lines.Length}");
    }

    private static void Write_Json_File(string path, PlayerData data)
    {
        string alive = data.Alive ? "true" : "false";

        StringBuilder builder = new StringBuilder();
        builder.AppendLine("{");
        builder.AppendLine($"    \"Name\": \"{data.Name}\",");
        builder.AppendLine($"    \"HP\": {data.HP},");
        builder.AppendLine($"    \"Alive\": {alive},");
        builder.AppendLine($"    \"Level\": {data.Level}");
        builder.AppendLine("}");

        string fileName = Path.Combine(path, "PlayerData.json");
        File.WriteAllText(fileName, builder.ToString());
    }

    private static void Write_Json_File2(string path, PlayerData data)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;

        string text = JsonSerializer.Serialize(data);

        Console.WriteLine("Json 직렬화 결과");
        Console.WriteLine(text);

        string fileName = Path.Combine(path, "PlayerData2.json");
        File.WriteAllText(fileName, text);
    }

    private static void Read_Json_File(string path, string name)
    {
        string fileName = Path.Combine(path, name + ".json");
        
        string str = File.ReadAllText(fileName);
        PlayerData data = JsonSerializer.Deserialize<PlayerData>(str);

        Console.WriteLine("\n-- 플레이어 데이터 --");
        Console.WriteLine($"이름: : {data.Name}");
        Console.WriteLine($"HP: : {data.HP}");
        Console.WriteLine($"Alive: : {data.Alive}");
        Console.WriteLine($"Level: : {data.Level}");
    }
}