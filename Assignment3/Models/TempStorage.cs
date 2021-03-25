using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class TempStorage
    {
        private static List<AddMoviesModel> movies = new List<AddMoviesModel>();

        public static IEnumerable<AddMoviesModel> Movies => movies;

        public static void AddApplication(AddMoviesModel addmovie)
        {
            movies.Add(addmovie);
        }
    }
}
