using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.Repository;
using Collection.DAL;

namespace Collection.DSL
{
    public class CommentDSL
    {
        CommentRepo repo = new CommentRepo();

        public IEnumerable<Comment> GetComments()
        {
            var list = repo.GetComments();
            return list;
        }
        public Comment GetCommentByID(int id)
        {
            return repo.GetCommentByID(id);
        }

        public void InsertComment(Comment c)
        {
            c.Date = DateTime.Now;
            repo.InsertComment(c);

        }

        public void DeleteComment(int id)
        {
            repo.DeleteComment(id);
        }

        public void Commit()
        {
            repo.Commit();
        }
    }
}
