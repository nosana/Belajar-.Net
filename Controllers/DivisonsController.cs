using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisonsController : BaseController <DivisionRepository,Division>
    {
        private DivisionRepository _divisionRepository;

        public  DivisonsController(DivisionRepository divisionRepository) : base(divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        [HttpGet ("Name")]
        public IActionResult Get(string name)
        {
            var data = _divisionRepository.Get(name);
            return Ok(new
            {
                Message = "Data has been Retrieved",
                StatusCode = 200,
                data = data
            });

        }
       /* [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var data = _divisionRepository.Get();
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
            //var data = _divisionRepository.Get();
            //return Ok (data);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var data = _divisionRepository.GetById(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Ditemukan"
                    });
                }
                else
                {
                    return Ok (new
                    {
                        StatusCode = 200,
                        Message = "Data Ditemukan",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
            *//*var data = _divisionRepository.GetById(id);
            if (data == null)
            {
                return Ok ( new {Message = "data tidak di temukan"});
            }
            return Ok (data);*//*
        }

        [HttpPost]
        public ActionResult Create(Division division)
        {
            try
            {
                var result = _divisionRepository.Create(division);
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Dapat Disimpan"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Dapat Disimpan",
                        Result = result
                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
            *//*
                        var result = _divisionRepository.Create(division);
                        if (result == 0)
                        {
                            return Ok(new { Message = "data tidak dapat disimpan" });
                        }
                        return Ok(new { Message = "Data Berhasil Disimpan" });
                    }*//*

            [HttpPut]

            public ActionResult Update(Division division)
            {
                try
                {
                    var result = _divisionRepository.Update(division);
                    if (result == 0)
                    {
                        return Ok(new
                        {
                            StatusCode = 200,
                            Message = "Data Tidak Berhasil Di Update"
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            StatusCode = 200,
                            Message = "Data Berhasil Di Update",
                            Result = result
                        });
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = ex.Message

                    });
                }
            }
        
            
           *//* var result = _divisionRepository.Update(division);
           
            if (result == 0)
            {
                return Ok(new { Message = "data tidak berhasil di update" });
            }
            return Ok(new { Message = "data berhasil di update" });
*//*
        

        [HttpDelete]
        public ActionResult Delete (int id)
        {
            try
            {
                var result = _divisionRepository.Delete(id);
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Berhasil Di Delete"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Di Delete",
                        Result = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
            *//*var result = _divisionRepository.Delete(id);
            if (result == 0)
            {
                return Ok(new { Message = "data tidak berhasil di Delete" });
            }
            return Ok(new { Message = "Data Berhasil Di Delete" });*//*
        }*/

    }
    
}
