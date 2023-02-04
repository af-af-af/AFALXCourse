using HttpClientShowcase.Models;
using Newtonsoft.Json;

namespace HttpClientShowcase
{
    public class SerializationDemo
    {
        public BookJsonSamplesHolder RunSerialization()
        {
            var book = new Book
            {
                Id = 1,
                Title = "The Hogfather",
                Author = "Terry Prachett",
                Genre = "Fantasy"
            };

            var bookJson = JsonConvert.SerializeObject(book);
            Console.WriteLine(bookJson);

            var bookBox = new BookBox 
            {
                Id = 120,
                Book= book
            };

            var bookBoxJson = JsonConvert.SerializeObject(bookBox);
            Console.WriteLine(bookBoxJson);

            var book2 = new Book
            {
                Id = 2,
                Title = "The Godfather",
                Author = "Mario Puzo",
                Genre = "Drama"
            };

            var shelf = new List<Book>();
            shelf.Add(book);
            shelf.Add(book2);

            var bookShelf = new BookShelf
            {
                Id = 3,
                Books = shelf
            };

            var bookShelfJson = JsonConvert.SerializeObject(bookShelf);
            Console.WriteLine(bookShelfJson);

            return new BookJsonSamplesHolder
            {
                BookJson = bookJson,
                BookBoxJson = bookBoxJson,
                BookShelfJson = bookShelfJson
            };
        }

        public void RunDeserialization(BookJsonSamplesHolder jsonStrings)
        {
            var book = JsonConvert.DeserializeObject<Book>(jsonStrings.BookJson);
            var bookBox = JsonConvert.DeserializeObject<BookBox>(jsonStrings.BookBoxJson);
            var bookShelf = JsonConvert.DeserializeObject<BookShelf>(jsonStrings.BookShelfJson);
            var book1 = JsonConvert.DeserializeObject(jsonStrings.BookShelfJson);
        }
    }
}
