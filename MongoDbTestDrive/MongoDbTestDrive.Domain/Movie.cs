using System;
using System.Collections.Generic;

namespace MongoDbTestDrive.Domain
{
    public class Movie: DocumentBase
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public IEnumerable<Role> Cast { get; set; }
        public IEnumerable<UserReview> UserReviews { get; set; }
        public double Rating { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0}, Title: {1}, Year: {2}, Description: {3}, Director: {4}", Id, Title, Year, Description, Director);
        }
    }
}