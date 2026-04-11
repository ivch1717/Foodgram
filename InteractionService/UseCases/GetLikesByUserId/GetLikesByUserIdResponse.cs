namespace UseCases.GetLikesByUserId;

public sealed record GetLikesByUserIdResponse(IReadOnlyCollection<GetLikesByUserIdResponseObj> Likes);
