
namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByIds(IEnumerable<int> bookIds);
        Book[] GetAllByIsbn(string isbn);
        Book[] GetAllByTitleOrAuthor(string titleOrAuthor);
        Book GetById(int id);
    }
}
