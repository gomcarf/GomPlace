# [C35_File write, read](../CsharpStudy_List.md)

- TextFile(.txt)
    - 형식이 없음
- CSV
    - Format(형식)이 존재
    - 콤마로 구분되어 있는 파일
- JSON
    - Format(형식)이 존재
    - { } 내의 트리 형식
    - 중첩이 가능

```csharp
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
```

### 데이터 구조

```csharp
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
```

- `WeaponData` :  일반 필드(`public float Power;` 등)를 가진 구조체. CSV 형식으로 저장/불러오기할 때 사용
- `PlayerData` : 프로퍼티(`public string Name { get; set; }` 등)를 가진 구조체. JSON 직렬화/역직렬화에 사용

### 1. 파일 경로 설정 및 일반 텍스트(.txt) 처리

```csharp
string path = Environment.CurrentDirectory; //현재 작업 중인 디렉토리 가져오기
path += "\\..\\..\\..\\"; //현재 작업 중인 디렉토리 상위 폴더로 이동
path = Path.GetDirectoryName(path)!; //path에 있는 디렉토리의 네임을 path에 저장
```

- 현재 실행 경로에서 상위 폴더로 이동하여 프로젝트 루트 경로를 확보
- `WriteTextFiles()` : `File.WriteAllText` 를 사용해 문자열을 `BaseballList.txt` 파일에 저장
- `ReadTextFile()` : `File.ReadAllText` 로 파일 전체 내용을 통째로 읽어와 출력

### 2. CSV(.csv) 포맷 처리(무기 데이터)

- 데이터 생성 : `GetNextSingle()` 및 `Random` 객체를 활용해 20~30개의 무기 데이터를 무작위로 생성하여 `List<WeaponData>`에 담음
- CSV 저장(`Write_CSV_File`)
    - 각 객체의 속성을 쉼표(`,`)로 구분하여 하나의 문자열 라인으로 이어 붙이고 `WeaponDatas.csv` 파일로 저장
- CSV 읽기(`Read_CSV_File`)
    - `File.ReadAllLines()`를 통해 파일 데이터를 줄 단위 배열로 읽어옴
    - `line.Split(”,”)`를 사용해 쉼표를 기준으로 값을 분리한 후 각 항목(Name, Number, Power 등)을 출력함

### 3. JSON(.json) 포맷 처리(플레이어 데이터)

#### 1) 수동 문자열 조합(`Write_Json_File`)

- `StringBuilder`를 사용해 `{”Name” : “Player”, …}` 형태의 JSON 문법 포맷을 직접 조립해서 `PlayerData.json`으로 저장

#### 2) `JsonSerializer`를 이용한 자동 직렬화(`Write_Json_File2`)

- `System.Text.Json` 라이브러리의 `JsonSerializer.Serialize()`를 사용하여 객체를 JSON 문자열로 자동 변환(직렬화)한 뒤 `PlayerData2.json`에 저장
- `PlayerData` 구조체의 필드들이 `{ get; set; }` 프로퍼티 형태로 선언되어 있어 `JsonSerializer`가 데이터를 올바르게 읽을 수 있음

#### 3) JSON 역직렬화(`Read_Json_File`)

- `File.ReadAllText()`로 JSON 파일을 읽은 뒤, `JsonSerializer.Deserialize<PlayerData>(str)`를 사용해 JSON 문자열을 다시 `PlayerData` C# 객체로 복원(역직렬화)

### 코드 흐름 요약

```
[Main 실행]
  ├── 1. 경로 탐색 (Path 지정)
  ├── 2. TXT 파일 생성 및 읽기 (BaseballList.txt)
  ├── 3. 랜덤 무기 데이터 20~30개 생성
  ├── 4. CSV 파일 생성 및 파싱 (WeaponDatas.csv)
  ├── 5. PlayerData 객체 생성 (playerData, playerData2)
  ├── 6. JSON 파일 저장 (수동 조합 vs JsonSerializer 직렬화)
  └── 7. JSON 파일 읽기 (JsonSerializer 역직렬화 및 출력)
```

- I/O > Byte 형태의 입출력을 다룸
- |   통로    | 통로를 순차적으로 지나감(통로 이름: Stream) > 바이트 형태라 바이트 스트림이라고 함)
- 데이터를 일정한 형식을 통해 Byte 형태의 배열로 변환: **직렬화**(통로에 연속적으로 하나씩 순차적으로 보내려고)

```csharp
CPU    |    GPU
 |     |     |
 V     |     V
RAM    |   VRAM
 |
 V
I/O
 |
 V
SSD
```

- 직렬화가 가능한 요소 : 변수

```csharp
public struct PlayerData{ //구조체도 public이어야 함

	public string Name {get; set;} //아래의 겟,셋을 줄여 씀 
	||
	private string name; //private은 직렬화 안하는 대상
	public string Name //public이어야함
	{
		get{ return name; } //직렬화 대상
		set{ name = value; }
	}
}
```

- 일정한 형식으로 저장을 해서 `deserialize`해서 불러옴