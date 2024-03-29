﻿using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.App.Models;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class BarCommentVMMapper : IDTOMapper<CommentViewModel, CommentDTO>,
                                             IViewModelMapper<CommentDTO, CommentViewModel>
    {
        public CommentViewModel MapFromDTO(CommentDTO dto)
        {
            return new CommentViewModel()
            {
                Comment = dto.Comment,
                UserId = dto.UserId,
                Id = dto.BarId,
                Username = dto.Username,
                CreatedOn = dto.CreatedOn
            };
        }

        public CommentDTO MapFromViewModel(CommentViewModel viewModel)
        {
            return new CommentDTO()
            {
                BarId = viewModel.Id,
                UserId = viewModel.UserId,
                Comment = viewModel.Comment,
                CreatedOn = viewModel.CreatedOn
            };
        }
    }
}
