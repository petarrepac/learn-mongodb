using System;
using MongoDbTestDrive.Domain;

namespace MongoDbTestDrive.Data.Test
{
    public static class MovieTestData
    {
        public static Movie GetNewMatrixInstance()
        {
            return new Movie
            {
                Description =
                    "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                Director = "Andy Wachowski",
                Duration = new TimeSpan(0, 0, 136, 0),
                Rating = 8.7,
                Title = "The Matrix",
                Year = 1999,
                Cast = new[]
                        {
                            new Role {Actor = "Keanu Reeves", Character = "Neo"},
                            new Role {Actor = "Laurence Fishburne", Character = "Morpheus"},
                            new Role {Actor = "Carrie-Anne Moss", Character = "Trinity"},
                            new Role {Actor = "Hugo Weaving", Character = "Agent Smith"},
                            new Role {Actor = "Gloria Foster", Character = "Oracle"},
                            new Role {Actor = "Joe Pantoliano", Character = "Cypher"},
                            new Role {Actor = "Marcus Chong", Character = "Tank"},
                            new Role {Actor = "Julian Arahanga", Character = "Apoc"},
                            new Role {Actor = "Matt Doran", Character = "Mouse"}
                        },
                UserReviews = new[]
                        {
                            new UserReview { 
                                ReviewText = "The Matrix...when I first heard about it, I expected just another sci-fi action thriller. Good and filled with insane stunts, but not terribly intelligent.", 
                                UserName = "SdrolionGM"}, 
                            new UserReview
                                {
                                    ReviewText = "Writing a review of The Matrix is a very hard thing for me to do because this film means a lot to me and therefore I want to do the film justice by writing a good review. To tell the truth the first time I saw the film I was enamored by the effects. I remember thinking to myself that this was one of the most visually stunning films I had ever seen in my life.", 
                                    UserName = "MinorityReporter"
                                }, 
                            new UserReview
                                {
                                    ReviewText = "It's been a while since a movie has generated enough interest in me for me to watch it. ''The Matrix'' looked exciting enough in the trailers, so I decided to give it a look. What I found was an amazing movie, with some of the greatest special effects I've ever seen.", 
                                    UserName = "Charles Kim"
                                }
                        }
            };
        }

        public static Movie GetNewCasablancaInstance()
        {
            return new Movie
                {
                    Description =
                        "Set in unoccupied Africa during the early days of World War II: An American expatriate meets a former lover, with unforeseen complications.",
                    Director = "Michael Curtiz",
                    Duration = new TimeSpan(0, 0, 102, 0),
                    Rating = 8.7,
                    Title = "Casablanca",
                    Year = 1942,
                    Cast = new[]
                        {
                            new Role {Actor = "Humphrey Bogart", Character = "Rick Blaine"},
                            new Role {Actor = "Ingrid Bergman", Character = "Ilsa Lund"},
                            new Role {Actor = "Paul Henreid", Character = "Victor Laszlo"},
                            new Role {Actor = "Claude Rains", Character = "Captain Louis Renault"},
                            new Role {Actor = "Conrad Veidt", Character = "Major Heinrich Strasser"}
                        },
                    UserReviews = new[]
                        {
                            new UserReview
                                {
                                    ReviewText =
                                        "Casablanca is a film about the personal tragedy of occupation and war. It speaks to the oppression of the one side - and the heroism and self-deprecation of the other.",
                                    UserName = "Rob Stewart"
                                },
                            new UserReview
                                {
                                    ReviewText =
                                        "The Petrified Forest convinced the world Bogart was a bad guy. And for years he shocked and awed the audience with roles fitting that image. The Maltese Falcon showed a new kind hero, one with an edge.",
                                    UserName = "JFHunt"
                                },
                            new UserReview
                                {
                                    ReviewText =
                                        "It's one of the great Hollywood legends how George Raft helped make Humphrey Bogart a leading man by turning down in succession, High Sierra, The Maltese Falcon, and Casablanca. Maybe Raft showed some good sense in letting a better actor handle those roles. In any event we've got some proof in the case of Casablanca.",
                                    UserName = "bkoganbing"
                                }
                        }
                };
        }
    }
}
