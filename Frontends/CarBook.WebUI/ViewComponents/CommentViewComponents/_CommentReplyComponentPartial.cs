﻿using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentReplyComponentPartial : ViewComponent
    {
       
        public async Task<IViewComponentResult> InvokeAsync(int? commentId)
        {

            if (commentId == null || commentId == 0)
            {
                Console.WriteLine("COMMENTID NULL → BOŞ DÖNDÜM");
                return Content("");
            }

            var value = new CreateReplyCommentDto
            {
                ParentCommentId = commentId,
                BlogID = ViewBag.BlogID,
            };


            return View(value);
        }

    }
}
