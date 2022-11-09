using API.Repository.Data;
using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Repository,Entity> : ControllerBase
        where Repository : class,IRepository<Entity>
        where Entity : class
    {
        Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = repository.Get();
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCodes = 200,
                        Message = "data tidak ada"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCodes = 200,
                        Message = "Data Ditemukan",
                        Data = data

                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    StatusCodes = 400,
                    Message = ex.Message
                });
            }
           
         
        }

        [HttpGet("GetID")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = repository.GetById(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCodes = 200,
                        Message = "data tidak ada"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCodes = 200,
                        Message = "Data Ditemukan",
                        Data = data

                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    StatusCodes = 400,
                    Message = ex.Message
                });
            }
            
           
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = repository.Delete(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCodes = 200,
                        Message = "data tidak ada"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCodes = 200,
                        Message = "Data Ditemukan",
                        Data = data

                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    StatusCodes = 400,
                    Message = ex.Message
                });
            }
            
            
        }
        [HttpPost]
        public IActionResult Create(Entity entity)
        {
            try
            {
                var data = repository.Create(entity);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCodes = 200,
                        Message = "data tidak ada"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCodes = 200,
                        Message = "Data Ditemukan",
                        

                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    StatusCodes = 400,
                    Message = ex.Message
                });
            }

            
          
        }
        [HttpPut]
        public IActionResult Update(Entity entity)
        {
            try
            {
                var data = repository.Update(entity);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCodes = 200,
                        Message = "data tidak ada"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCodes = 200,
                        Message = "Data Ditemukan",


                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    StatusCodes = 400,
                    Message = ex.Message
                });
            }
            
           
        }
    }
}
