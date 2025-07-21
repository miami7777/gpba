using Microsoft.EntityFrameworkCore;
using testGPBA.Domain.Repositories.Abstract;
using testGPBA.Models;

namespace testGPBA.Domain.Repositories.EntityFramework
{
    public class OfferRepositories : IOfferRepositories
    {
        private readonly AppDbContext _context;

        public OfferRepositories(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Offer> CreateOfferAsync(Offer offer)
        {
            offer.RegistrationDate = DateTime.Now;
            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();
            return offer;
        }

        public async Task<(IEnumerable<Offer>,int)> SearchOffersAsync(string searchTerm)
        {
            var query = _context.Offers
                .Include(o => o.Supplier)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(o =>
                    o.Brand.ToLower().Contains(searchTerm) ||
                    o.Model.ToLower().Contains(searchTerm) ||
                    o.Supplier.Name.ToLower().Contains(searchTerm)
                );
            }

            var totalCount = await query.CountAsync();
            var offers = await query.ToListAsync();

            return (offers,totalCount);
        }

        public async Task<IEnumerable<SupplierStats>> GetPopularSuppliersAsync(int count = 3)
        {
            return await _context.Suppliers
                .Select(s => new SupplierStats(
                    s.Name,
                    s.Offers.Count()
                ))
                .Take(count)                
                .ToListAsync();
                
        }
    }
}
