using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SQLReviewRepository : IReviewRepository
    {
        private readonly MyDbContext dbContext;

        public SQLReviewRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await dbContext.Reviews
                .Include(r => r.User)
                .Include(r => r.Movie)
                .ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await dbContext.Reviews
                .Include(r => r.User)
                .Include(r => r.Movie)
                .FirstOrDefaultAsync(r => r.ReviewId == id);
        }

        public async Task<Review> CreateAsync(Review review)
        {
            await dbContext.Reviews.AddAsync(review);
            await dbContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review?> UpdateAsync(int id, Review review)
        {
            var existingReview = await dbContext.Reviews.FirstOrDefaultAsync(r => r.ReviewId == id);
            if (existingReview == null) return null;

            existingReview.UserId = review.UserId;
            existingReview.MovieId = review.MovieId;
            existingReview.Rating = review.Rating;

            await dbContext.SaveChangesAsync();
            return existingReview;
        }

        public async Task<Review?> DeleteAsync(int id)
        {
            var existingReview = await dbContext.Reviews.FirstOrDefaultAsync(r => r.ReviewId == id);
            if (existingReview == null) return null;

            dbContext.Reviews.Remove(existingReview);
            await dbContext.SaveChangesAsync();
            return existingReview;
        }
    }
}
