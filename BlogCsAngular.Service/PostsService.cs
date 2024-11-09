using BlogCsAngular.Data;
using BlogCsAngular.Data.Models;
using BlogCsAngular.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCsAngular.Service
{
    public class PostsService
    {
        private readonly ContextDB _context;

        public PostsService(ContextDB context)
        {
            _context = context;
        }

        public async Task<List<PostsViewModel>> GetAll()
        {
            var lista = _context.Posts
                .Where(l => l.Active)
                .Select(l => new PostsViewModel
                {
                    IdPosts = l.IdPosts,
                    Title = l.Title,
                    Content = l.Content,
                    UserId = l.UserId
                })
                .ToList();

            return lista;
        }

        public async Task<PostsViewModel> GetPost(int idPost)
        {
            var post = await _context.Posts
                .Where(i => i.IdPosts == idPost)
                .Select(p => new PostsViewModel
                {
                    IdPosts = p.IdPosts,
                    Title = p.Title,
                    Content = p.Content,
                    UserId = p.UserId

                } )
                .FirstOrDefaultAsync();

            return post;
        }


        public async Task AddPost(PostsViewModel model)
        {
            var post = new Posts();
            post.Title = model.Title;
            post.Content = model.Content;
            post.UserId = model.UserId;
            post.Active = true;
            post.FechaRegistro = DateTime.Now;
            post.FechaEliminacion = DateTime.Now;
            post.FechaEdicion = DateTime.Now;

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Posts?> EditPost(int idp, PostsViewModel model)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.IdPosts == idp);

            if (post == null) return null;

            // Actualizar solo los campos necesarios
            post.Title = model.Title;
            post.Content = model.Content;
            post.UserId = model.UserId;
            post.FechaEdicion = DateTime.Now;

            await _context.SaveChangesAsync();

            return post;
        }

        public async Task DeletePost(int idP)
        {
            var post = await _context.Posts.Where(id => id.IdPosts == idP).FirstOrDefaultAsync();

            post.Active = false;
            await _context.SaveChangesAsync();
        }
    }
}
