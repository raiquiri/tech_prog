namespace WindowsFormsApp1
{
    public interface IFilePacker
    {
        void Pack(string inputFilePath, string outputFilePath);
        void UnPack(string inputFilePath, string outputFilePath);
    }
}