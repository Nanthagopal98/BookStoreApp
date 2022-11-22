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

        [Authorize(Roles = Role.Users)]
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

        [Authorize]
        [HttpGet]
        [Route("GetBookById")]
        public IActionResult GetBookById(int bookId)
        {
            try
            {
                var result = bookBL.GetBookById(bookId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Get Book By Id Successful", data = result });
                }
                return BadRequest(new { success = false, message = "Failed to Get Book By ID" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult UpdateBook(BookModel model)
        {
            try
            {
                var result = bookBL.UpdateBook(model);
                if (result != false)
                {
                    return Ok(new { success = true, message = "Book Update Successful" });
                }
                return BadRequest(new { success = false, message = "Failed to Update Book" });
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize(Roles =Role.Admin)]
        [HttpDelete]
        [Route("DeleteBook")]
        public IActionResult DeleteBook(int bookId)
        {
            try
            {
                var result = bookBL.DeleteBook(bookId);
                if(result != false)
                {
                    return Ok(new { success = true, message = "Book Deleted Successfully" });
                }
                return BadRequest(new { success = false, message = "Failed To Delete" });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
