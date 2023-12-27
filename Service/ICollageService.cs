using Asp.netCoreMVCIntro.Models;
using Asp.netCoreMVCIntro.ViewModels;

namespace Asp.netCoreMVCIntro.Service
{
    public interface ICollageService
    {
        void Add(CollageViewModel collage);

        Collage Update(Collage collage);

        void Delete(int Id);

        Task<Collage> GetCollage(int Id);

        Task<IEnumerable<Collage>> GetAllCollage();
    }
}
