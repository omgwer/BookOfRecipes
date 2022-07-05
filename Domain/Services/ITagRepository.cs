
namespace Domain.Services
{
    public interface ITagRepository
    {
        Tag? GetTag(string name);
    }
}
