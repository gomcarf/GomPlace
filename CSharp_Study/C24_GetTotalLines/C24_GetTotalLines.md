# [C24_GetTotalLines](../CsharpStudy_List.md)

- 폴더 경로를 탐색하는 재귀 함수와 파일을 읽고 라인 수를 세는 파일 입출력(I/O) 기능을 다루는 C# 프로그램

```csharp
namespace C24_GetTotalLines //재귀2
{
    class Program
    {   
        private static void GetDirectory(string path) //path의 하위 디렉토리 순회 출력
        {
            string[] directories = Directory.GetDirectories(path);

            foreach (string d in directories)
            {
                Console.WriteLine(d);

                GetDirectory(d);
            }
        }

        private static void ViewSourceFile(string filePath)
        {
            FileStream filestream = new FileStream(filePath,FileMode.Open); //파일을 가져와서 열기
            StreamReader streamReader = new StreamReader(filestream); //filestream의 파일 내용을 보여주기

            string line;

            while (true)
            {
                line = streamReader.ReadLine()!; //파일의 한줄씩 읽어서 대입

                if (line == null) //대입한 내용이 null이면 반복문 탈출
                    break;

                Console.WriteLine(line);
            }

            streamReader.Close(); //스트림 열었으니 닫기
            filestream.Close(); //파일 열었으니 닫기
        }

        private static int GetLineCount(string filePath) //파일 내용이 몇줄인지 세는 함수
        {
            FileStream filestream = new FileStream(filePath, FileMode.Open); //파일을 가져와서 열기
            StreamReader streamReader = new StreamReader(filestream); //filestream의 파일 내용을 보여주기

            string? line;
            int count=0;

            while ((line = streamReader.ReadLine()) != null) //파일의 한줄씩 읽어서 line 대입했을 때 null이 아닌 동안 반복
                count++;
                       

            streamReader.Close(); //스트림 열었으니 닫기
            filestream.Close(); //파일 열었으니 닫기

            return count;
        }

        private static void Main(string[] args)
        {
            Console.Write("\\Test\'Test\"Test\tTest\n");
            string currentFolder = Directory.GetCurrentDirectory(); 
            Console.WriteLine(currentFolder); //실행파일 기준 현재 폴더 출력 //C:\leejuyoung\C2606\C24_GetTotalLines\bin\Debug\net8.0

            string path = Path.GetFullPath(Directory.GetCurrentDirectory()+ "\\..\\..\\..");
            Console.WriteLine(path); //C:\leejuyoung\C2606\C24_GetTotalLines

            Console.WriteLine(); //한줄띄기

            GetDirectory(path); //C:\leejuyoung\C2606\C24_GetTotalLines 의 하위 디렉토리 탐방 함수 호출

            ViewSourceFile(path + "\\Program.cs"); //C:\leejuyoung\C2606\C24_GetTotalLines\Program.cs 집어넣고 ViewSourceFile 함수 호출

            int lineCount = GetLineCount(path+"\\Program.cs"); //C:\leejuyoung\C2606\C24_GetTotalLines\Program.cs를 집어넣고 GetLineCount 호출
            Console.WriteLine($"Program.cs : {lineCount}");

            string path2 = Path.GetFullPath(Directory.GetCurrentDirectory() + "\\..\\..\\..\\.."); //path2 = C:\leejuyoung\C2606
            Console.WriteLine(path);

            GetDirectory(path2);
        }//Main
    }
}
/*
 ../ 상위폴더로 이동
  ./ 최상위 폴더로이동
 */
```

```csharp
private static void GetDirectory(string path) //path의 하위 디렉토리 순회 출력
{
      string[] directories = Directory.GetDirectories(path);

      foreach (string d in directories)
      {
            Console.WriteLine(d);

            GetDirectory(d);
      }
}
```

- `GetDirectory(string path)` : 하위 폴더 전체 탐색 (재귀 함수)
    - 특정 폴더(`path`) 안에 있는 하위 폴더 목록을 가져옴 (`Directory.GetDirectories`).
    - 폴더 이름을 출력한 뒤, 자기 자신(`GetDirectory(d)`)을 다시 호출.
    - 하위 폴더의 하위 폴더까지 끝까지 찾아 들어가며 모든 폴더 경로를 출력. (폴더 구조를 훑는 트리 탐색)

```csharp
private static void ViewSourceFile(string filePath)
{
      FileStream filestream = new FileStream(filePath,FileMode.Open); //파일을 가져와서 열기
      StreamReader streamReader = new StreamReader(filestream); //filestream의 파일 내용을 보여주기

      string line;

      while (true)
      {
          line = streamReader.ReadLine()!; //파일의 한줄씩 읽어서 대입

          if (line == null) //대입한 내용이 null이면 반복문 탈출
              break;

          Console.WriteLine(line);
      }

      streamReader.Close(); //스트림 열었으니 닫기
      filestream.Close(); //파일 열었으니 닫기
}
```

- `ViewSourceFile(string filePath)` : 파일 내용 출력
    - 지정된 경로의 파일(`filePath`)을 열어 한 줄씩 읽은 뒤 콘솔에 출력
    - 더 이상 읽을 내용이 없으면(`line == null`) 반복문을 빠져나옴
    - 파일 작업을 마친 뒤 `streamReader`와 `filestream`의 `.Close()`로 안전하게 닫아줌!

```csharp
private static int GetLineCount(string filePath) //파일 내용이 몇줄인지 세는 함수
{
    FileStream filestream = new FileStream(filePath, FileMode.Open); //파일을 가져와서 열기
    StreamReader streamReader = new StreamReader(filestream); //filestream의 파일 내용을 보여주기

    string? line;
    int count=0;

    while ((line = streamReader.ReadLine()) != null) //파일의 한줄씩 읽어서 line 대입했을 때 null이 아닌 동안 반복
        count++;
               

    streamReader.Close(); //스트림 열었으니 닫기
    filestream.Close(); //파일 열었으니 닫기

    return count;
}
```

- `GetLineCount(string filePath)` : 파일의 총 줄 수 계산
    - `ViewSourceFile`과 동일하게 파일을 한 줄씩 읽지만 출력하는 대신 줄 수(`count`)만 누적하여 셈.
    - 읽기가 끝나면 파일의 총 줄 수를 반환(`return count;`)

```csharp
private static void Main(string[] args)
{
    Console.Write("\\Test\'Test\"Test\tTest\n");
    string currentFolder = Directory.GetCurrentDirectory(); 
    Console.WriteLine(currentFolder); //실행파일 기준 현재 폴더 출력 //C:\leejuyoung\C2606\C24_GetTotalLines\bin\Debug\net8.0

    string path = Path.GetFullPath(Directory.GetCurrentDirectory()+ "\\..\\..\\..");
    Console.WriteLine(path); //C:\leejuyoung\C2606\C24_GetTotalLines

    Console.WriteLine(); //한줄띄기

    GetDirectory(path); //C:\leejuyoung\C2606\C24_GetTotalLines 의 하위 디렉토리 탐방 함수 호출

    ViewSourceFile(path + "\\Program.cs"); //C:\leejuyoung\C2606\C24_GetTotalLines\Program.cs 집어넣고 ViewSourceFile 함수 호출

    int lineCount = GetLineCount(path+"\\Program.cs"); //C:\leejuyoung\C2606\C24_GetTotalLines\Program.cs를 집어넣고 GetLineCount 호출
    Console.WriteLine($"Program.cs : {lineCount}");

    string path2 = Path.GetFullPath(Directory.GetCurrentDirectory() + "\\..\\..\\..\\.."); //path2 = C:\leejuyoung\C2606
    Console.WriteLine(path);

    GetDirectory(path2);
}//Main
```

**① 탈출 문자(Escape Sequence) 및 경로 탐색**

- `Console.Write("\\Test\'Test\"Test\tTest\n");`: `\`, `'`, `"`, 탭(`\t`), 줄바꿈(`\n`) 등의 특수문자를 출력하는 법을 보여줌.
- `Directory.GetCurrentDirectory()`: 현재 실행 중인 파일의 위치(보통 `bin\Debug\net8.0`)를 가져옴.
- `Path.GetFullPath(... + "\\..\\..\\..")`: `..`은 상위 폴더로 이동. 세 번 올라가서 프로젝트 루트 폴더(`C24_GetTotalLines`) 경로를 얻음.

**② 폴더 탐색 및 파일 읽기 실행**

1. `GetDirectory(path)`: 프로젝트 루트 폴더 안의 모든 하위 폴더들을 재귀적으로 출력.
2. `ViewSourceFile(path + "\\Program.cs")`: 프로젝트 안의 `Program.cs` 소스 코드 내용을 콘솔 화면에 보여줌.
3. `GetLineCount(path + "\\Program.cs")`: `Program.cs` 파일이 몇 줄로 이루어져 있는지 계산해 `Program.cs : XX` 형태로 출력.
4. `path2`: 한 단계 더 위인 솔루션/작업 폴더 상위 경로로 이동해 해당 폴더의 모든 하위 폴더 구조를 다시 탐색.