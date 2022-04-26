using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflowProject.DomainModels;

namespace StackOverflowProject.Repositories
{
    public interface IVotesRepository
    {
        void UpdateVote(int aid, int uid, int value);

    }

    public class VotesRepository : IVotesRepository
    {
        StackOverflowDatabaseDbContext db;

        public VotesRepository()
        {
            db = new StackOverflowDatabaseDbContext();
        }

        public void UpdateVote(int aid, int uid, int value)
        {
            int UpdateValue;
            if (value > 0)
            {
                UpdateValue = 1;
            }
            else if (value < 0)
            {
                UpdateValue = -1;
            }
            else
            {
                UpdateValue = 0;
            }

            Vote v = db.Votes.Where(temp => temp.AnswerID == aid && temp.UserID == uid).FirstOrDefault();

            if (v != null)
            {
                v.VoteValue = UpdateValue;
            }
            else
            {
                Vote newvote = new Vote()
                {
                    AnswerID = aid,
                    UserID = uid,
                    VoteValue = UpdateValue
                };
                db.Votes.Add(newvote);
            }
            db.SaveChanges();
        }
    }
}
