using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.DAL;
using System.Data.Entity;

namespace Collection.Repository
{
    public class CommentRepo
    {
        private invoicesystemEntities context;
        public CommentRepo()
        {
            context = new invoicesystemEntities();
        }
        public IEnumerable<Comment> GetComments()
        {
            return context.Comments.Include(i => i.User).ToList();
            //return context.Comments.Select(i => new Comment()
            //{
            //    ID = i.ID,
            //    Comment1 = i.Comment1,
            //    Date = i.Date,
            //    User = i.User,
            //    Invoice_ID = i.Invoice_ID,
            //    User_ID = i.User_ID,
            //    Invoice = i.Invoice
            //}).ToList();
        }
        public Comment GetCommentByID(int id)
        {
            var z = context.Comments.SingleOrDefault(m => m.ID == id);
            return z;
        }

        public void InsertComment(Comment c)
        {
            context.Comments.Add(c);
        }

        public void DeleteComment(int id)
        {
            Comment c = context.Comments.Find(id);
            context.Comments.Remove(c);
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
