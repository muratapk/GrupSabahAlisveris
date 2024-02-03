namespace GrupSabahAlisveris.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        
        public string UserName { get; set;} = string.Empty;
        public string Message { get; set;} = string.Empty;
        public  int ProductId  { get; set; }

    }
}
