namespace UseCases.IsRecipeLiked;

public interface IIsRecipeLikedRequestHandle
{
    public IsRecipeLikedResponse Handle(IsRecipeLikedRequest request);
}
