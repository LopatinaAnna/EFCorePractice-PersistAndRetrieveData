using ContosoPizza.Models;
using ContosoPizza.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class PromotionsService
{
    private readonly PromotionsContext _context;

    public PromotionsService(PromotionsContext context)
    {
        _context = context;
    }

    public IEnumerable<Coupon> GetAll()
    {
        return _context.Coupons
            .AsNoTracking()
            .ToList();
    }

    public Coupon? GetById(int id)
    {
        return _context.Coupons
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }

    public Coupon? Create(Coupon newCoupon)
    {
        _context.Coupons.Add(newCoupon);
        _context.SaveChanges();

        return newCoupon;
    }

    public void DeleteById(int id)
    {
        var couponToDelete = _context.Coupons.Find(id);
        if (couponToDelete is not null)
        {
            _context.Coupons.Remove(couponToDelete);
            _context.SaveChanges();
        }
    }
}