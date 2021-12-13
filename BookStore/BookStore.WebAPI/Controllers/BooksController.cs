using BookStore.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}",Name ="GetBook")]
        public IActionResult GetBook(string id)
        {
            return Ok(_bookService.GetBook(id));
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks()); 
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookService.AddBook(book);
            return CreatedAtRoute("GetBook",new { id=book.Id }, book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            _bookService.DeleteBook(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            return Ok(_bookService.UpdateBook(book));
        }
    }
}
