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
            return context.Comments.ToList();
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
