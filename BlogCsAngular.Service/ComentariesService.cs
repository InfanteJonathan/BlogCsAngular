using BlogCsAngular.Data.Models;
using BlogCsAngular.Data.ViewModels;
using BlogCsAngular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogCsAngular.Service
{
    public class ComentariesService
    {
        private readonly ContextDB _context;

        public ComentariesService(ContextDB context)
        {
            _context = context;
        }

        public async Task<List<ComentaryViewModel>> GetAll()
        {
            var lista = _context.Commentaries
                .Where(l => l.Active)
                .Select(l => new ComentaryViewModel
                {
                    ComentaryId = l.ComentaryId,
                    Content = l.Content,
                    UserId = l.UserId,
                    Likes = l.Likes
                })
                .ToList();

            return lista;
        }

        public async Task<ComentaryViewModel> GetComentary(int idPost)
        {
            var post = await _context.Commentaries
                .Where(i => i.ComentaryId == idPost)
                .Select(p => new ComentaryViewModel
                {
                    ComentaryId = p.ComentaryId,
                    Likes = p.Likes,
                    Content = p.Content,
                    UserId = p.UserId
                })
                .FirstOrDefaultAsync();

            return post;
        }


        public async Task AddComentary(ComentaryViewModel model)
        {
            var post = new comentario();
            post.Content = model.Content;
            post.UserId = model.UserId;
            post.Likes = model.Likes;
            post.Active = true;
            post.FechaRegistro = DateTime.Now;

            _context.Commentaries.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task EditComentary(int idc, ComentaryViewModel model)
        {
            var post = await _context.Commentaries.FirstOrDefaultAsync(p => p.ComentaryId == idc);
           

            // Actualizar solo los campos necesarios
            post.ComentaryId = model.ComentaryId;
            post.Content = model.Content;
            post.UserId = model.UserId;
            post.FechaEdicion = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteComentary(int idP)
        {
            var post = await _context.Commentaries.Where(id => id.ComentaryId == idP).FirstOrDefaultAsync();

            post.Active = false;
            await _context.SaveChangesAsync();
        }
    }
}
