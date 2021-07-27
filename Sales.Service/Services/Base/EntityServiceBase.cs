using AutoMapper;
using Sales.CrossCutting.Helpers;
using Sales.Infrastructure.Repositories.Base.Interfaces;
using Sales.Service.Services.Base.Interfaces;
using Sales.Service.ViewModels.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.Service.Services.Base
{
    public abstract class EntityServiceBase<TEntity, TDto, TViewModel> : 
        IEntityServiceBase<TEntity, TDto, TViewModel>, IViewModelServiceBase<TViewModel>
        where TEntity : class
        where TDto : class
        where TViewModel : class
    {
        #region Fields

        protected readonly IMapper _mapper;
        private readonly IEntityRepositoryBase<TEntity, TDto> _repository;

        #endregion

        #region Constructor

        public EntityServiceBase(
            IMapper mapper,
            IEntityRepositoryBase<TEntity, TDto> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #endregion

        #region Entity Methods

        /// <summary>
        /// Adiciona uma nova entidade ao repositório
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async virtual Task<TEntity> AddAsync(TEntity entity)
        {
            return await _repository.AddAsync(entity);
        }

        /// <summary>
        /// Inclui vários itens do repositório
        /// </summary>
        /// <param name="entities"></param>
        public async virtual Task<IList<TEntity>> AddAsync(IList<TEntity> entities)
        {
            return await _repository.AddAsync(entities);
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
            return _repository.Update(entity);
        }

        /// <summary>
        /// Atualiza vários itens do repositório
        /// </summary>
        /// <param name="entities"></param>
        public virtual bool Update(IList<TEntity> entities)
        {
            return _repository.Update(entities);
        }

        /// <summary>
        /// Atualiza itens do repositório de forma asyncrona
        /// </summary>
        /// <param name="list"></param>
        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        /// <summary>
        /// Remove a entidade do repositório
        /// </summary>
        /// <param name="entity"></param>
        public virtual bool Delete(TEntity entity)
        {
            return _repository.Delete(entity);
        }

        /// <summary>
        /// Remove várias entidades do repositório 
        /// </summary>
        /// <param name="entity"></param>
        public virtual bool Delete(IList<TEntity> entity)
        {
            return _repository.Delete(entity);
        }

        /// <summary>
        /// Deletes or Removes an Entity do repositório conforme o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        /// <summary>
        /// Deletes or Removes an Entity do repositório conforme o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(long id)
        {
            return await _repository.DeleteAsync(id);
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

        #region DTO Methods

        /// <summary>
        /// Adiciona uma nova entidade recebendo uma DTO
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async Task<TDto> AddAsync(TDto dto)
        {
            return _mapper.Map<TEntity, TDto>(
                await AddAsync(_mapper.Map<TDto, TEntity>(dto)));
        }

        /// <summary>
        /// Adiciona uma lista de entidades por uma lista de DTOs
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public virtual async Task<IList<TDto>> AddAsync(IList<TDto> dtos)
        {
            return _mapper.Map<IList<TEntity>, IList<TDto>>(
                await AddAsync(_mapper.Map<IList<TDto>, IList<TEntity>>(dtos)));
        }

        /// <summary>
        /// Deletes or Removes an Entity por uma DTO
        /// </summary>
        /// <param name="dto"></param>
        public virtual bool Delete(TDto dto)
        {
            return Delete(_mapper.Map<TDto, TEntity>(dto));
        }

        /// <summary>
        /// Remove uma lista de entidades por uma lista de DTOs
        /// </summary>
        /// <param name="dtos"></param>
        public virtual bool Delete(IList<TDto> dtos)
        {
            return Delete(_mapper.Map<IList<TDto>, IList<TEntity>>(dtos));
        }

        /// <summary>
        /// Desacopla a entidade do contexto por meio da DTO
        /// </summary>
        /// <param name="dto"></param>
        public virtual void DetachEntity(TDto dto)
        {
            DetachEntity(_mapper.Map<TDto, TEntity>(dto));
        }

        /// <summary>
        /// Retorna uma entidade convertida em DTO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TDto> GetDtoAsync(int id)
        {
            return _mapper.Map<TEntity, TDto>(await GetEntityAsync(id));
        }

        /// <summary>
        /// Retorna uma entidade convertida em DTO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TDto> GetDtoAsync(long id)
        {
            return _mapper.Map<TEntity, TDto>(await GetEntityAsync(id));
        }

        /// <summary>
        /// Retorna uma lista de DTOs
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IList<TDto>> ListDtoAsync()
        {
            return _mapper.Map<IList<TEntity>, IList<TDto>>(await ListEntityAsync());
        }

        /// <summary>
        /// Atualiza uma lista de entidades por uma lista de DTOs
        /// </summary>
        /// <param name="dtos"></param>
        public virtual bool Update(IList<TDto> dtos)
        {
            return Update(_mapper.Map<IList<TDto>, IList<TEntity>>(dtos));
        }

        /// <summary>
        /// Atualiza uma entidade por uma DTO
        /// </summary>
        /// <param name="dto"></param>
        public virtual bool Update(TDto dto)
        {
            return Update(_mapper.Map<TDto, TEntity>(dto));
        }

        /// <summary>
        /// Atualiza uma entidade por uma DTO
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync(TDto dto)
        {
            return await UpdateAsync(_mapper.Map<TDto, TEntity>(dto));
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
            return _mapper.Map<TEntity, TViewModel>(
                await AddAsync(_mapper.Map<TViewModel, TEntity>(viewModel)));
        }

        /// <summary>
        /// Adds new Entities from a List
        /// </summary>
        /// <param name="viewModels"></param>
        /// <returns></returns>
        public virtual async Task<IList<TViewModel>> AddAsync(IList<TViewModel> viewModels)
        {
            return _mapper.Map<IList<TEntity>, IList<TViewModel>>(
                await AddAsync(_mapper.Map<IList<TViewModel>, IList<TEntity>>(viewModels)));
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
