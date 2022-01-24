using BooksMVC.API.DTOs;
using BooksMVC.API.Mappers;
using BooksMVC.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            var allBooks = await _booksRepository.GetAllBooksAsync(cancellationToken);
            return Ok(allBooks.Select(x => x.ToVm()));
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default)
        {
            var book = await _booksRepository.GetBookAsync(id, cancellationToken);
            if (book == null)
                return NotFound();

            return Ok(book.ToVm());
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewBookDTO dto, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                ModelState.AddModelError(nameof(dto.Title), "Title is required");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = dto.ToApplicationModel();
            return Ok(await _booksRepository.AddBookAsync(book, cancellationToken));
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBookDTO dto, CancellationToken cancellationToken = default)
        {
            var currentBook = await _booksRepository.GetBookAsync(id, cancellationToken);
            if (currentBook == null)
                return NotFound();

            if (string.IsNullOrWhiteSpace(dto.Title))
                ModelState.AddModelError(nameof(dto.Title), "Title is required");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedBook = dto.ToApplicationModel();
            updatedBook.Id = id;
            await _booksRepository.UpdateBookAsync(updatedBook, cancellationToken);

            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var currentBook = await _booksRepository.GetBookAsync(id, cancellationToken);
            if (currentBook == null)
                return NotFound();

            await _booksRepository.DeleteBookAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
