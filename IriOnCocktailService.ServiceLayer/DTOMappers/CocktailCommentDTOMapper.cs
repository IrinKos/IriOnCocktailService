using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class CocktailCommentDTOMapper : IDTOServiceMapper<CommentDTO, CocktailComment>
    {
        public CocktailComment MapFrom(CommentDTO barCommentDTO)
        {
            return new CocktailComment()
            {
                CocktailId = barCommentDTO.BarId,
                Description = barCommentDTO.Comment,
                UserId = barCommentDTO.UserId,
            };
        }
    }
}
