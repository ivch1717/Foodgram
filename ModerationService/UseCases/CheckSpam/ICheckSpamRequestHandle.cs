namespace UseCases.CheckSpam;

public interface ICheckSpamRequestHandle
{
    CheckSpamResponse Handle(CheckSpamRequest request);
}