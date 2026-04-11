namespace UseCases.PutLike;

public interface IPutLikeRequestHandle
{
    public PutLikeResponse Handle(PutLikeRequest request);
}