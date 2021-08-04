using AutoMapper;
using Sales.CrossCutting.Helpers;
using Sales.Model.Repositories.Base.Interfaces;
using Sales.Model.UoW.Interfaces;
using Sales.Service.Services.Base.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Service.Services.Base
{
    public abstract class EntityServiceBase<TEntity, TViewModel> : 
        IEntityServiceBase<TEntity, TViewModel>, IViewModelServiceBase<TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        #region Fields

        protected readonly IMapper _mapper;
        private readonly IEntityRepositoryBase<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public EntityServiceBase(
            IMapper mapper,
            IEntityRepositoryBase<TEntity> repository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Entity Methods

        /// <summary>
        /// Adiciona uma nova entidade ao repositório
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async virtual Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Inclui vários itens do repositório
        /// </summary>
        /// <param name="entities"></param>
        public async virtual Task AddAsync(IList<TEntity> entities)
        {
            await _repository.AddAsync(entities);
            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Retorna a entidade conforme o ID passado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async virtual Task<TEntity> GetEntityAsync(int id)
        {
            return await _repository.GetEntityAsync(id);
        }

        /// <summary>
        /// Retorna a entidade conforme o ID passado
        /// </summary>
        /// <param name="id">DataType Long</param>
        /// <returns></returns>
        public async virtual Task<TEntity> GetEntityAsync(long id)
        {
            return await _repository.GetEntityAsync(id);
        }

        /// <summary>
        /// Retorna uma lista de todos os itens do repositório
        /// </summary>
        /// <returns></returns>
        public async virtual Task<IList<TEntity>> ListEntityAsync()
        {
            return await _repository.ListEntityAsync();
        }

        /// <summary>
        /// Marca para atualização a entidade passada
        /// </summary>
        /// <param name="entity"></param>
        public virtual bool Update(TEntity entity)
        {
            _repository.Update(entity);
            return _unitOfWork.Commit();
        }

        /// <summary>
        /// Atualiza vários itens do repositório
        /// </summary>
        /// <param name="entities"></param>
        public virtual bool Update(IList<TEntity> entities)
        {
            _repository.Update(entities);
            return _unitOfWork.Commit();
        }

        /// <summary>
        /// Atualiza itens do repositório de forma asyncrona
        /// </summary>
        /// <param name="list"></param>
        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Remove a entidade do repositório
        /// </summary>
        /// <param name="entity"></param>
        public virtual bool Delete(TEntity entity)
        {
            _repository.Delete(entity);
            return _unitOfWork.Commit();
        }

        /// <summary>
        /// Remove várias entidades do repositório 
        /// </summary>
        /// <param name="entity"></param>
        public virtual bool Delete(IList<TEntity> entity)
        {
            _repository.Delete(entity);
            return _unitOfWork.Commit();
        }

        /// <summary>
        /// Deletes or Removes an Entity do repositório conforme o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Deletes or Removes an Entity do repositório conforme o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Desacopla a entidade do contexto
        /// </summary>
        /// <param name="entity"></param>
        public virtual void DetachEntity(TEntity entity)
        {
            _repository.DetachEntity(entity);
        }

        #endregion

        #region ViewModel Methods

        /// <summary>
        /// Adds a new Entity
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual async Task<TViewModel> AddAsync(TViewModel viewModel)
        {
            var result = _mapper.Map<TViewModel, TEntity>(viewModel); 
            await AddAsync(result);
            return _mapper.Map<TEntity, TViewModel>(result);
        }

        /// <summary>
        /// Adds new Entities from a List
        /// </summary>
        /// <param name="viewModels"></param>
        /// <returns></returns>
        public virtual async Task<IList<TViewModel>> AddAsync(IList<TViewModel> viewModels)
        {
            var result = _mapper.Map<IList<TViewModel>, IList<TEntity>>(viewModels);
            await AddAsync(result);
            return _mapper.Map<IList<TEntity>, IList<TViewModel>>(result);
        }

        /// <summary>
        /// Deletes or Removes an Entity por uma ViewModel
        /// </summary>
        /// <param name="viewModel"></param>
        public virtual bool Delete(TViewModel viewModel)
        {
            return Delete(_mapper.Map<TViewModel, TEntity>(viewModel));
        }

        /// <summary>
        /// Deletes or Removes Entities from a List
        /// </summary>
        /// <param name="viewModels"></param>
        public virtual bool Delete(IList<TViewModel> viewModels)
        {
            return Delete(_mapper.Map<IList<TViewModel>, IList<TEntity>>(viewModels));
        }

        /// <summary>
        /// Desacopla a entidade do contexto por meio da ViewModel
        /// </summary>
        /// <param name="viewModel"></param>
        public virtual void DetachEntity(TViewModel viewModel)
        {
            DetachEntity(_mapper.Map<TViewModel, TEntity>(viewModel));
        }

        /// <summary>
        /// Returns one
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TViewModel> GetAsync(int id)
        {
            return _mapper.Map<TEntity, TViewModel>(await GetEntityAsync(id));
        }

        /// <summary>
        /// Returns one
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TViewModel> GetAsync(long id)
        {
            return _mapper.Map<TEntity, TViewModel>(await GetEntityAsync(id));
        }

        /// <summary>
        /// Retorna uma lista de ViewModels
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IList<TViewModel>> ListAsync()
        {
            return _mapper.Map<IList<TEntity>, IList<TViewModel>>(await ListEntityAsync());
        }

        /// <summary>
        /// Atualiza uma lista de entidades por uma lista de ViewModels
        /// </summary>
        /// <param name="viewModels"></param>
        public virtual bool Update(IList<TViewModel> viewModels)
        {
            return Update(_mapper.Map<IList<TViewModel>, IList<TEntity>>(viewModels));
        }

        /// <summary>
        /// Atualiza uma entidade por uma ViewModel
        /// </summary>
        /// <param name="viewModel"></param>
        public virtual bool Update(TViewModel viewModel)
        {
            return Update(_mapper.Map<TViewModel, TEntity>(viewModel));
        }

        /// <summary>
        /// Atualiza uma entidade por uma ViewModel
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync(TViewModel viewModel)
        {
            return await UpdateAsync(_mapper.Map<TViewModel, TEntity>(viewModel));
        }

        /// <summary>
        /// Returns a Paged List
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public virtual PagedViewModel<TViewModel> GetPagedList(int page, int pageSize)
        {
            return _mapper.Map<PagedList<TEntity>, PagedViewModel<TViewModel>>(
                _repository.GetPagedList<TEntity>(page, pageSize));
        }

        /// <summary>
        /// Returns a Paged List conforme um parâmetro de busca
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchId"></param>
        /// <returns></returns>
        public virtual PagedViewModel<TViewModel> GetPagedList(int page, int pageSize, int searchId)
        {
            return _mapper.Map<PagedList<TEntity>, PagedViewModel<TViewModel>>(
                _repository.GetPagedList(_repository.List<TEntity>(), page, pageSize));
        }

        /// <summary>
        /// Returns a Paged List conforme uma lista de parâmetros
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchParams"></param>
        /// <returns></returns>
        public abstract PagedViewModel<TViewModel> GetPagedList(int page, int pageSize, Dictionary<string, int> searchParams);

        #endregion
    }
}
