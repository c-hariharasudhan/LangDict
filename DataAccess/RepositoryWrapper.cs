using NewDictionary.Interfaces;

namespace NewDictionary.DataAccess{
    public class RepositoryWrapper : IRepositoryWrapper{
        private RepositoryContext _repoContext;
        private INotesRepository _notesRepository;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public INotesRepository NotesRepository
        {
            get
            {
                if (_notesRepository == null)
                {
                    _notesRepository = new NotesRepository(_repoContext);
                }

                return _notesRepository;
            }
        }

    }
}