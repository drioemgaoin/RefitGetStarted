using System.Threading.Tasks;
using Refit;
using RefitGetStarted.Models;

namespace RefitGetStarted.Services
{
    public interface IJsonPlaceHolderApiService
    {
        [Get("/posts/{id}")]
        Task<Post> GetPost(int id);

        [Post("/posts")]
        Task<Post> CreatePost([Body] Post post);

        [Put("/posts/{id}")]
        Task<Post> UpdatePost(int id, [Body] Post post);
    }
}