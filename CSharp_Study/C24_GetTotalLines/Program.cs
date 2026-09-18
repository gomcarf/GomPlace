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

            int lineCount = GetLineCount(path + "\\Program.cs"); //C:\leejuyoung\C2606\C24_GetTotalLines\Program.cs를 집어넣고 GetLineCount 호출
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