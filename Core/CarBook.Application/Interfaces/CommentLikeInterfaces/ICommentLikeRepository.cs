using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CommentLikeInterfaces
{
    public interface ICommentLikeRepository
    {
        int GetLikeCountByCommentId(int CommentId);
        int GetDislikeCountByCommentId(int CommentId);
        bool? GetUserLikeStatus(int CommentId, int AppUserId);
        void CreateCommentLike(CommentLike CommentLike);
        void UpdateCommentLike(CommentLike CommentLike);
        void RemoveCommentLike(CommentLike CommentLike);

        CommentLike? GetCommentLikeByFilter(int CommentId, int appUserId);
    }
}
