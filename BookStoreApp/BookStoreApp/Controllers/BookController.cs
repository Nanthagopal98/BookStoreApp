using Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IBookBL bookBL;

        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }


        [Authorize (Roles = Role.Admin)]
        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook(BookModel bookModel)
        {
            try
            {
                var result =  bookBL.AddBook(bookModel);
                if(result != false)
                {
                    return Ok(new { success = true, message = "Book Added SuccessFully" });
                }
                return BadRequest(new {success = false, message = "Book Failed To Add"});
            }
            catch(System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var result = bookBL.GetAllBook();
                if(result != null)
                {
                    return Ok(new { succes = true, message = "Get Books SuccessFul", data = result});
                }
                return BadRequest(new { success = false, message = "Get All Book Falied" });
            }
            catch(System.Exception)
            {
                throw;
            }
        }
    }
}
