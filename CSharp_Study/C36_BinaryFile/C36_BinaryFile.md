# [C36_Binary File](../CsharpStudy_List.md)

```csharp
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
```

## 1. 기본 개념 정리

- `BinaryWriter` / `BinaryReader`: 데이터를 텍스트가 아닌 원시 바이너리 형태(Int32 = 4byte, Float = 4byte 등)로 파일에 직접 쓰고 읽음.
- `MemoryMarshal` & `Span<T>`: C#의 고급 메모리 관리 기술. 데이터를 하나씩 복사하지 않고, 메모리에 저장된 데이터 블록 전체를 `byte` 배열로 간주하여 한 번에 파일로 내보내거나 들여올 때 사용

## 2. 코드 부문별 상세 설명

### ① 기본 바이너리 파일 입출력 (`WriteBinaryFile`, `ReadBinaryFile`)

단일 `WeaponData` 객체의 데이터를 각 필드 단위로 순서대로 입출력.

- 저장 (`WriteBinaryFile`):
    1. `writer.Write((int)data.Type)`: Enum 타입은 `BinaryWriter`가 직접 쓰지 못하므로 `int`(4byte)로 캐스팅하여 기록
    2. `Power`(float 4byte), `Speed`(float 4byte), `Price`(int 4byte)를 순서대로 기록.
- 불러오기 (`ReadBinaryFile`):
    1. 저장할 때 썼던 정확한 순서와 타입대로 읽어와야 함.
    2. `reader.ReadInt32()`로 정수를 읽은 후 다시 `(WeaponType)`으로 형변환(Casting).
    3. `reader.ReadSingle()`로 float 값을 읽음.

### ② 메모리 통째로 직렬화하기 (`WriteSerializeFile`, `ReadSerializedFile`)

반복문으로 필드를 하나씩 쓰지 않고, 배열 전체의 메모리 데이터를 한 번에 파일로 저장하고 복원하는 고성능 입출력 방식.

#### 저장 과정 (`WriteSerializeFile`)

1. 개수 기록 : `writer.Write(datas.Length)`로 배열에 데이터가 몇 개 들어있는지 먼저 저장(복원할 때 개수를 알아야 하기 때문).
2. `MemoryMarshal.AsBytes`: `WeaponData[]` 배열의 메모리 영역을 통째로 바이트 단위의 `Span<byte>`로 바라봄
3. 한 번에 쓰기 : `writer.Write(bytes)`를 호출해 모든 무기 데이터 메모리를 파일에 한 번에 씀

#### 불러오기 과정 (`ReadSerializedFile`)

1. 개수 읽기 : `reader.ReadInt32()`로 저장된 무기 데이터 개수(`count`)를 읽음
2. 바이트 계산 및 읽기 : `Marshal.SizeOf<WeaponData>()`로 구조체 1개의 바이트 크기를 구한 뒤, `count * size`만큼 파일에서 바이트를 한 번에 읽어옴 (`reader.ReadBytes`)
3. `MemoryMarshal.Cast`: 읽어온 바이트 배열(`Span<byte>`)을 다시 원래의 `WeaponData` 타입(`Span<WeaponData>`)으로 메모리 해석(Reinterpret)을 수행
4. `ToArray()`를 호출해 C# 구조체 배열로 손쉽게 복원

## 3. 코드 관련 주요 팁 및 피드백

1. `using` 구문 활용 권장
    - 현재 코드에서는 `fileStream.Close()`, `writer.Close()`를 직접 호출. `using` 문을 사용하면 예외(에러)가 발생하더라도 리소스가 자동으로 안전하게 해제됨.
    
    ```csharp
    using FileStream fileStream = new FileStream(filePath, fileMode);
    using BinaryWriter writer = new BinaryWriter(fileStream);
    // Close()를 직접 부르지 않아도 구문을 벗어나면 자동 해제됨
    ```
    
2. 메모리 통 통째로 쓰기(Marshal)의 주의점
    - `MemoryMarshal.AsBytes` 방식은 구조체가 값 타입(Value Type)으로만 이루어져 있고 참조 타입(string, class 등)이 포함되지 않았을 때만 안전. (`WeaponData` 내부에 `string` 등이 포함되면 메모리 주소값만 저장이 되어 파일이 깨짐.)
    - 리스트가 힙(Heap) 메모리에 불연속적으로 주소를 참조할 수 있기 때문에 연속된 메모리 공간을 보장하는 배열(`ToArray()`)이나 `Span`으로 변환해야 통째로 바이트 변환이 가능

### byte[] bytes = reader.ReadBytes(Size)

```csharp
int totalSize = count * size; //전체 크기(바이트)
byte[] bytes = reader.ReadBytes(totalSize);
```

- 전체 바이트 계산 및 읽기 : `(데이터 개수 × 구조체 크기)`를 계산하여 파일에 저장된 실제 데이터들의 총 바이트 크기를 구함.
- 그 크기만큼 `reader.ReadBytes(totalSize)`를 통해 파일의 데이터 부분을 한 번에 통째로 메모리(`bytes` 배열)로 읽어옴. (성능을 높이기 위해 일일이 하나씩 읽지 않고 덩어리로 읽는 방식)

### Span<T>

```csharp
Span<byte> span = bytes;
Span<WeaponData> dataSpan = MemoryMarshal.Cast<byte, WeaponData>(span); //바이트를 WeaponData 타입으로 변환
```

- `Span<T>` 활용 : `Span`은 메모리를 안전하고 빠르게 다룰 수 있게 해주는 C#의 고성능 구조체. 복사 과정을 거치지 않고 기존 메모리를 그대로 참조
- `MemoryMarshal.Cast`: 읽어온 순수 바이트 배열(`bytes`)의 메모리 형태를 그대로 유지한 채, "이 바이트들은 사실 `WeaponData` 구조체 배열이야"라고 컴파일러에게 해석 방식을 강제(Cast).
    - 예를 들어 16바이트짜리 데이터가 있으면, 과거에는 이를 하나씩 구조체로 변환했어야 하지만, 이 함수를 쓰면 메모리 재할당 없이 곧바로 구조체 뷰(View)로 바라볼 수 있게 됨.

### ToArray()

```csharp
WeaponData[] datas = dataSpan.ToArray();
    }
    reader.Close();
}
fileStream.Close();
```

- 최종 배열 변환: `Span<WeaponData>` 형태를 우리가 흔히 다루는 일반 배열인 `WeaponData[]`로 변환하여 `datas` 변수에 담습니다. 이제 이 `datas`를 게임 로직에서 자유롭게 사용할 수 있습니다.
- 자원 해제: 사용이 끝난 `BinaryReader`와 `FileStream`을 닫아 파일 점유를 해제합니다. (참고로 이 코드는 실무에서 `using` 문을 사용해 자동으로 자원을 해제하도록 작성하는 것이 더 안전합니다.)