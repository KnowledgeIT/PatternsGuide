using DimensionTrip.Infrastructure.Repositories.Base.Interfaces;
using DimensionTrip.Infrastructure.UoW.Interfaces;
using DimensionTrip.Service.Services.Base.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DimensionTrip.Service.Services.Base
{
    public abstract class GenericServiceBase: IGenericServiceBase
    {
        #region Fields
        
        protected readonly IMapper _mapper;
        private readonly IGenericRepositoryBase _repository;
        protected readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public GenericServiceBase(
            IMapper mapper,
            IGenericRepositoryBase repository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Generic Methods

        /// <summary>
        /// Adiciona uma nova entidade ao repositório
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async virtual Task AddAsync<T>(T entity) where T : class
        {
            await _repository.AddAsync(entity);
        }

        /// <summary>
        /// Inclui vários itens do repositório
        /// </summary>
        /// <param name="list"></param>
        public async virtual Task AddAsync<T>(IEnumerable<T> list)
        {
            await _repository.AddAsync(list);
        }

        /// <summary>
        /// Remove a entidade do repositório
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete<T>(T entity) where T : class
        {
            _repository.Delete(entity);
        }

        /// <summary>
        /// Remove várias entidades do repositório 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete<T>(IEnumerable<T> entity) where T : class
        {
            _repository.Delete(entity);
        }

        /// <summary>
        /// Remove uma entidade do repositório conforme o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync<T>(int id) where T : class
        {
            await _repository.DeleteAsync<T>(id);
        }

        /// <summary>
        /// Remove a Entidade do Context.
        /// Abre a possibilidade de ser utilizada para entidades de repositórios diferentes da Entidade principal
        /// </summary>
        /// <param name="entity"></param>
        public virtual T DetachEntity<T>(T entity) where T : class
        {
            return _repository.DetachEntity(entity);
        }

        /// <summary>
        /// Retorna a entidade conforme o ID passado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async virtual Task<T> GetAsync<T>(int id) where T : class
        {
            return await _repository.GetAsync<T>(id);
        }

        /// <summary>
        /// Retorna a entidade conforme o ID passado
        /// </summary>
        /// <param name="id">Long</param>
        /// <returns></returns>
        public async virtual Task<T> GetAsync<T>(long id) where T : class
        {
            return await _repository.GetAsync<T>(id);
        }

        /// <summary>
        /// Retorna uma lista de todos os itens de uma entidade passada como parâmetro para o repositório
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<T>> ListAsync<T>() where T : class
        {
            return await _repository.ListAsync<T>();
        }

        /// <summary>
        /// Marca para atualização a entidade passada
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update<T>(T entity)
        {
            _repository.Update(entity);
        }

        /// <summary>
        /// Atualiza vários itens do repositório
        /// </summary>
        /// <param name="list"></param>
        public virtual void Update<T>(IEnumerable<T> list)
        {
            _repository.Update(list);
        }

        /// <summary>
        /// Atualiza itens do repositório de forma asyncrona
        /// </summary>
        /// <param name="list"></param>
        public virtual async Task UpdateAsync<T>(T entity)
        {
            await _repository.UpdateAsync(entity);
        }

        #endregion
    }
}
