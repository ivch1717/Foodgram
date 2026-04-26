namespace UseCases.CheckContentForModeration;

public interface ICheckContentForModerationRequestHandle
{
    CheckContentForModerationResponse Handle(CheckContentForModerationRequest request);
}