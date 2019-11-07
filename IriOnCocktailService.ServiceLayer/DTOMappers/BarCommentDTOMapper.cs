using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class BarCommentDTOMapper : IDTOServiceMapper<BarComment, BarCommentDTO>,
                                       IDTOServiceMapper< BarCommentDTO, BarComment>
    {
        public BarComment MapFrom(BarCommentDTO barCommentDTO)
        {
            return new BarComment()
            {
                BarId = barCommentDTO.BarId,
                Description = barCommentDTO.Comment,
                UserId = barCommentDTO.UserId,
            };
        }

        public BarCommentDTO MapFrom(BarComment entity)
        {
            throw new NotImplementedException();
        }

    }
}
