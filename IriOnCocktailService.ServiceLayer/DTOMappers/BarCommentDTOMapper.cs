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
                CreatedOn = DateTime.Parse(barCommentDTO.CreatedOn)
            };
        }

        public CommentDTO MapFrom(BarComment entity)
        {
            return new CommentDTO()
            {
                Name=entity.Bar.Name,
                BarId=entity.BarId,
                Comment=entity.Description,
                UserId=entity.UserId,
                Username=entity.User.UserName,
                CreatedOn = entity.CreatedOn.ToString()
            };
        }

    }
}
