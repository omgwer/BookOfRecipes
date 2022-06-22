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
                var t = _tagRepository.GetTag( item.Name );
                if ( t == null )
                {
                    t = new Tag {
                       Name = item.Name
                    };
                }

                //проверять имя на уникальность
                list.Add( t );
            }
            return list;
        }
    }
}
