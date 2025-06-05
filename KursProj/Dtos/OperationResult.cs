namespace KursProj.Dtos
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; } = false; // По умолчанию неуспех
        public List<string> Errors { get; set; } = new List<string>();
    }

}
