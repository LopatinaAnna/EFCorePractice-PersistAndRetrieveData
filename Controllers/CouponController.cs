using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class CouponController : ControllerBase
{
    PromotionsService _service;

    public CouponController(PromotionsService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Coupon> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Coupon> GetById(int id)
    {
        var coupon = _service.GetById(id);

        if (coupon is not null)
        {
            return coupon;
        }
        else
        {
            return NotFound();
        }
    }


    [HttpPost]
    public IActionResult Create(Coupon newCoupon)
    {
        var coupon = _service.Create(newCoupon);
        return CreatedAtAction(nameof(GetById), new { id = coupon!.Id }, coupon);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var coupon = _service.GetById(id);

        if (coupon is not null)
        {
            _service.DeleteById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}