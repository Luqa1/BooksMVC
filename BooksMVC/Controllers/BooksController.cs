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
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksRepository _booksRepository;

        public BooksController(ILogger<BooksController> logger,
            IBooksRepository booksRepository)
        {
            _logger = logger;
            _booksRepository = booksRepository;
        }

        // GET: api/<BooksController>
        [HttpGet]
        [FormatFilter]
        //TODO still must be checked why 406
        [Route("{format?}")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Get all books request start");
            
            var allBooks = await _booksRepository.GetAllBooksAsync(cancellationToken);

            _logger.LogInformation("Get all books request end");

            return Ok(allBooks.Select(x => x.ToVm()));
        }

        // GET api/<BooksController>/5
        [HttpGet]
        [FormatFilter]
        [Route("{id}/{format?}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Get book by id = {id} request start");

            var book = await _booksRepository.GetBookAsync(id, cancellationToken);
            if (book == null)
                return NotFound();

            _logger.LogInformation($"Get book by id = {id} request end");

            return Ok(book.ToVm());
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewBookDTO dto, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Creating new book request start");

            if (string.IsNullOrWhiteSpace(dto.Title))
                ModelState.AddModelError(nameof(dto.Title), "Title is required");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = dto.ToApplicationModel();
            var newBookId = await _booksRepository.AddBookAsync(book, cancellationToken);

            _logger.LogInformation("Creating new book request end");

            return Ok(newBookId);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBookDTO dto, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Updating book id = {id} request start");

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

            _logger.LogInformation($"Updating book id = {id} request end");

            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Deleting book id = {id} request start");

            var currentBook = await _booksRepository.GetBookAsync(id, cancellationToken);
            if (currentBook == null)
                return NotFound();

            await _booksRepository.DeleteBookAsync(id, cancellationToken);

            _logger.LogInformation($"Deleting book id = {id} request end");

            return NoContent();
        }
    }
}
