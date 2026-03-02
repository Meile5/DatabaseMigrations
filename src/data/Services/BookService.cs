namespace api.Controllers;

public class BookService (BookRepo repo)
{
    
    public async Task SaveComment(CreateCommentDto createCommentDto)
    {
        var comment = new Comment
        {
            CommentId = Guid.NewGuid().ToString(),
            Text = createCommentDto.Comment,
            ArticleId =  createCommentDto.ArticleId
        };
        var hasProfanity = await profanityClient.FilterComment(comment.Text);
        if (hasProfanity)
        {
            throw new Exception("Comment contains forbidden words");
        }
        await commentsRepo.SaveComment(comment,  createCommentDto.UserId);
    }

    public async Task RetrieveBook()
    {
        
    }
    
    
}