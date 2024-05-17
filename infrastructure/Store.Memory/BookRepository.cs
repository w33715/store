
namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1,"ISBN 12312-31231", "D. Knuth", "Art of Programming", "Описание1",7.19m),
            new Book(2,"ISBN 12312-31232", "M. Fowler","Refactoring","Описание2", 8m),
            new Book(3,"ISBN 12312-31233", "B. Kernighan, D. Ritchie", "C Programming Language", "Описание3", 20m),
        };

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            return foundBooks.ToArray();
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        //public Book[] GetAllByTitle(string titlePart)
        //{
        //    return books.Where(book => book.Title.Contains(titlePart))
        //                .ToArray();
        //}

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
           || book.Title.Contains(query))
                       .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
