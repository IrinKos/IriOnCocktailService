using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class CocktailCommentDTOMapper : IDTOServiceMapper<CommentDTO, CocktailComment>,
                                            IDTOServiceMapper<CocktailComment, CommentDTO>
    {
        public CocktailComment MapFrom(CommentDTO cocktailCommentDTO)
        {
            return new CocktailComment()
            {
                CocktailId = cocktailCommentDTO.BarId,
                Description = cocktailCommentDTO.Comment,
                UserId = cocktailCommentDTO.UserId,
            };
        }

        public CommentDTO MapFrom(CocktailComment entity)
        {
            return new CommentDTO()
            {
                BarId = entity.CocktailId,
                Comment = entity.Description,
                UserId = entity.UserId,
            };
        }
    }
}
