namespace CityMall.Dtos.Dtos.Files;
public sealed class UploadFileResultDto
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public string ContentType { get; set; }

    public bool Success { get; set; }
}
