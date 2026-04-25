namespace UseCases.CreateComment;

public class CreateCommentRequestHandle : ICreateCommentRequestHandle
{
    ICreateCommentRepository _repository;

    public CreateCommentRequestHandle(ICreateCommentRepository repository)
    {
        _repository = repository;
    }
    public CreateCommentResponse Handle(CreateCommentRequest request)
    {
        var comment = CreateCommentMapper.ToEntities(request, Guid.NewGuid());
        _repository.AddComment(comment);
        return new CreateCommentResponse(comment.Id);
    }
}
