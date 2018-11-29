using NewDictionary.Entity;
using NewDictionary.Interfaces;

namespace NewDictionary.DataAccess{
     public class NotesRepository: RepositoryBase<Note>, INotesRepository
    {
        public NotesRepository(RepositoryContext repositoryContext) :base(repositoryContext)
        {
        }
    }
}