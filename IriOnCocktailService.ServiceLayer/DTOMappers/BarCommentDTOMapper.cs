using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class BarCommentDTOMapper : IDTOServiceMapper<BarComment, CommentDTO>,
                                       IDTOServiceMapper<CommentDTO, BarComment>
    {
        public BarComment MapFrom(CommentDTO barCommentDTO)
        {
            return new BarComment()
            {
                BarId = barCommentDTO.BarId,
                Description = barCommentDTO.Comment,
                UserId = barCommentDTO.UserId,
            };
        }

        public CommentDTO MapFrom(BarComment entity)
        {
            return new CommentDTO()
            {
                BarId=entity.BarId,
                Comment=entity.Description,
                UserId=entity.UserId,
            };
        }

    }
}
