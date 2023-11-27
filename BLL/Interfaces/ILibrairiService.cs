using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILibrairiService
    {
        /// <summary>
        /// Ajoute un nouveau livre
        /// </summary>
        /// <param name="book">Le nouveau livre</param>
        /// <returns>Le livre</returns>
        public Book CreateBook(Book book);

        /// <summary>
        /// Récupère un livre avec son ID
        /// </summary>
        /// <param name="id">l'id du livre souhaiter</param>
        /// <returns>Le livre avec l'id voulu</returns>
        /// <exception cref="NotFoundException">Livre non trouvé</exception>
        public Book GetBookById(Guid? id);

        /// <summary>
        /// Récupère tout les livres
        /// </summary>
        /// <returns>La liste de tous les livres</returns>
        public List<Book> GetAllBooks();

        /// <summary>
        /// Update un livre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book UpdateBook(Guid id);

        /// <summary>
        /// Supprime un livre
        /// </summary>
        /// <param name="id">L'id du livre a supprimer</param>
        public bool DeleteBook(Guid id);
        
    }
}
