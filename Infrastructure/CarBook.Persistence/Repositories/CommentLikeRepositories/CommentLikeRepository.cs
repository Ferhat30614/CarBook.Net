using CarBook.Application.Interfaces.CommentLikeInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories.CommentLikeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentLikeRepositories
{
    public class CommentLikeRepository : ICommentLikeRepository
    {

        private readonly CarBookContext _context;

        public CommentLikeRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetDislikeCountByCommentId(int CommentId)
        {
            return _context.CommentLikes.Where(a => a.CommentID == CommentId && a.IsLike == false).Count();
        }

        public int GetLikeCountByCommentId(int CommentId)
        {
            return _context.CommentLikes.Where(a => a.CommentID == CommentId && a.IsLike == true).Count();
        }

        public bool? GetUserLikeStatus(int CommentId, int AppUserId)
        {
            var values = _context.CommentLikes.Where(a => a.CommentID == CommentId && a.AppUserID == AppUserId).FirstOrDefault();

            return values?.IsLike;
        }

        public void CreateCommentLike(CommentLike CommentLike)
        {
            _context.CommentLikes.Add(CommentLike);
            _context.SaveChanges();
        }

        public CommentLike? GetCommentLikeByFilter(int CommentId, int appUserId)
        {
            return _context.CommentLikes.Where(a => a.CommentID == CommentId && a.AppUserID == appUserId).FirstOrDefault();
        }

        public void UpdateCommentLike(CommentLike CommentLike)
        {
            _context.CommentLikes.Update(CommentLike);
            _context.SaveChanges();
        }

        public void RemoveCommentLike(CommentLike CommentLike)
        {
            _context.Remove(CommentLike);
            _context.SaveChanges();
        }

    }
}
