using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api.Models
{
    public class BorrowerModel
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string DOB { get; set; }

        public BorrowerModel()
        { }
    
        public BorrowerModel(int bid, string bsname, string bfname, string bdob)
        {
            ID = bid;
            Surname = bsname;
            Firstname = bfname;
            DOB = bdob;
        }
    }

    public class BookModel
    {
        public int ISBN { get; set; }
        public string Title { get; set; }


        public BookModel()
        { }

        public BookModel(int isbn, string title)
        {
            ISBN = isbn;
            Title = title;

        }
    }

    public class AuthorModel
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }

        public AuthorModel()
        { }

        public AuthorModel (int aid, string asname, string afname)
        {
            ID = aid;
            Surname = asname;
            Firstname = afname;
        }
    }
}

public class BorrowedBookModel
{
    public int ISBN { get; set; }
    public string Title { get; set; }
    public int Borrower { get; set; }

    public BorrowedBookModel()
    { }

    public BorrowedBookModel(int isbn, string title, int borrower)
    {
        ISBN = isbn;
        Title = title;
        Borrower = borrower;
    }
}

