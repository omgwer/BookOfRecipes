using Application.Models.Dto;
using Domain;

namespace Application.Services
{
    public interface ITagListBuilder
    {
        List<Tag> Build( List<TagDto> tagDto );
    }
}