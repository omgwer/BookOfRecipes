using Application.Models.Dto;
using Domain;
using Domain.Services;

namespace Application.Services
{
    public class TagListBuilder : ITagListBuilder
    {
        private readonly ITagRepository _tagRepository;

        public TagListBuilder( ITagRepository tagRepository )
        {
            _tagRepository = tagRepository;
        }

        public List<Tag> Build( List<TagDto> tagDto )
        {
            var list = new List<Tag>();
            foreach ( var item in tagDto )
            {
                var tag = _tagRepository.GetTag( item.Name );
                if ( tag == null )
                {
                    tag = new Tag
                    {
                        Name = item.Name
                    };
                }
                if ( !list.Any( x => x.Name == item.Name ) )
                {
                    //проверять имя на уникальность
                    list.Add( tag );
                }
            }
            return list;
        }
    }
}
