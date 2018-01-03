namespace FreeChat.Models.Enums
{
    public enum TopicDeletionVerdictEnum
    {
        TopicNotFound = -1,
        TopicSuccesfullyDeleted = 1,
        UserDontHaveTheRightsToDelete = 2
    }
}