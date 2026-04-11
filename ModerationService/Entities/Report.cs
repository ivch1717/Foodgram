namespace Entities;

public sealed class Report
{
    public Guid Id{get;}
    public Guid TargetId { get; }
    public TargetType Type { get; }
    public Guid ReporterUserId { get; }
    public DateTime CreatedAt { get; }
    public string Reason { get; }

    public Report(Guid id, Guid targetId, TargetType type, Guid reporterUserId, DateTime createdAt, string reason)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }

        if (targetId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(targetId));
        }

        if (reporterUserId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(reporterUserId));
        }
        Id = id;
        TargetId = targetId;
        Type = type;
        ReporterUserId = reporterUserId;
        CreatedAt = createdAt;
        Reason = reason;
    }
}