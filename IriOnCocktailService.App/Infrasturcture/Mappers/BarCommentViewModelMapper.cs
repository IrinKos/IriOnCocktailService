﻿using IriOnCocktailService.App.Areas.Crawler.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class BarCommentViewModelMapper : IDTOMapper<CommentViewModel, CommentDTO>
    {
        public CommentDTO MapFromViewModel(CommentViewModel viewModel)
        {
            return new CommentDTO()
            {
                BarId=viewModel.Id,
                UserId=viewModel.UserId,
                Comment=viewModel.Comment
            };
        }
    }
}