using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//this model displays the objects in the sqlite db
namespace Assignment3.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(AddMoviesModel movie)
        {
            CartLine line = Lines
                .Where(b => b.Movie.MovieID == movie.MovieID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Movie = movie
                });
            }
            else
            {
                
            }
        }

        public virtual void RemoveLine(AddMoviesModel movie) =>
            Lines.RemoveAll(b => b.Movie.MovieID == movie.MovieID);

        public virtual void Clear() => Lines.Clear();

        //public decimal ComputeTotalSum() => Lines.Sum(b => b.Book.Price * b.Quantity);

        public class CartLine
        {
            public int CartLineID { get; set; }
            public AddMoviesModel Movie { get; set; }
        }
    }
}
