﻿using System;
using System.Collections.Generic;
using Health.API;
using Health.API.Entities;
using Health.API.Repository;
using Health.API.Services;
using Ninject;

namespace Health.Data.Repository.Fake
{
    public abstract class CoreFakeRepository<TEntity, TIEntity> : ICoreRepository<TIEntity>
        where TEntity : class, TIEntity, new()
        where TIEntity : IEntity
    {
        protected static IList<TIEntity> _entities;

        protected CoreFakeRepository()
        {
            _entities = new List<TIEntity>();
        }

        public IDIKernel DIKernel { get; set; }
        public ICoreKernel CoreKernel { get; set; }
        public TInstance Instance<TInstance>()
            where TInstance : IEntity
        {
            return DIKernel.Get<TInstance>();
        }

        public void SetKernelAndCoreService(IDIKernel di_kernel, ICoreKernel core_kernel)
        {
            DIKernel = di_kernel;
            CoreKernel = core_kernel;
            InitializeData();
        }

        public virtual void InitializeData() { return; }

        public virtual IEnumerable<TIEntity> GetAll()
        {
            return _entities;
        }

        public virtual bool Save(TIEntity entity)
        {
            _entities.Add(entity);
            return true;
        }

        public virtual bool Delete(TIEntity entity)
        {
            _entities.Remove(entity);
            return true;
        }
    }
}