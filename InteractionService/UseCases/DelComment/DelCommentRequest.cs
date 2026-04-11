namespace UseCases.DelComment;

public sealed record DelCommentRequest(Guid CommentId, Guid UserId);
